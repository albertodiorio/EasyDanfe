using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;
using EasyDanfe.Modules;
using EasyDanfe.Modules.ModuleLocalEntregaRetirada;
using org.pdfclown.documents;
using org.pdfclown.documents.contents.fonts;
using org.pdfclown.files;
using System.Reflection;
namespace EasyDanfe;

using File = org.pdfclown.files.File;

public sealed class Danfe : IDisposable
{
    public DanfeViewModel ViewModel { get; }
    public File File { get; }
    internal Document PdfDocument { get; }

    internal ModuleCanhoto Canhoto { get; }
    internal ModuleIdentificacaoEmitente IdentificacaoEmitente { get; }

    internal readonly List<ModuleBase> Modules = [];
    internal readonly EstiloElement EstiloPadrao;
    private readonly List<DanfePagina> Paginas = [];

    internal readonly StandardType1Font FonteRegular;
    internal readonly StandardType1Font FonteNegrito;
    internal readonly StandardType1Font FonteItalico;

    private org.pdfclown.documents.contents.xObjects.XObject? logoObject;
    private bool foiGerado;

    public Danfe(DanfeViewModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);
        ViewModel = viewModel;

        File = new File();
        PdfDocument = File.Document;

        var familia = StandardType1Font.FamilyEnum.Times;
        FonteRegular = new StandardType1Font(PdfDocument, familia, false, false);
        FonteNegrito = new StandardType1Font(PdfDocument, familia, true, false);
        FonteItalico = new StandardType1Font(PdfDocument, familia, false, true);

        EstiloPadrao = CriarEstilo();
        Canhoto = CriarBloco<ModuleCanhoto>();
        IdentificacaoEmitente = AdicionarBloco<ModuleIdentificacaoEmitente>();
        AdicionarBloco<ModuleDestinatarioRemetente>();

        if (viewModel.LocalRetirada is not null && viewModel.ExibirBlocoLocalRetirada)
            AdicionarBloco<ModuleLocalRetirada>();

        if (viewModel.LocalEntrega is not null && viewModel.ExibirBlocoLocalEntrega)
            AdicionarBloco<ModuleLocalEntrega>();

        if (viewModel.Duplicatas.Count > 0)
            AdicionarBloco<BlocoDuplicataFatura>();

        var estiloImposto = viewModel.Orientacao == Orientacao.Paisagem
            ? EstiloPadrao
            : CriarEstilo(4.75F);

        AdicionarBloco<ModuleCalculoImposto>(estiloImposto);
        AdicionarBloco<ModuleTransportador>();
        AdicionarBloco<ModuleDadosAdicionais>(CriarEstilo(tFonteCampoConteudo: 8));

        if (viewModel.CalculoIssqn.Mostrar)
            AdicionarBloco<ModuleCalculoIssqn>();

        AdicionarMetadata();
    }

    public void AdicionarLogoPdf(Stream stream)
    {
        ArgumentNullException.ThrowIfNull(stream);

        using var pdfFile = new File(new org.pdfclown.bytes.Stream(stream));
        logoObject = pdfFile.Document.Pages[0].ToXObject(PdfDocument);
    }

    public void AdicionarLogoPdf(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        AdicionarLogoPdf(fs);
    }

    public void AdicionarLogoImagem(Stream stream)
    {
        ArgumentNullException.ThrowIfNull(stream);

        var img = org.pdfclown.documents.contents.entities.Image.Get(stream)
            ?? throw new InvalidOperationException("O logotipo não pôde ser carregado. Certifique-se de que a imagem esteja em formato JPEG não progressivo.");

        logoObject = img.ToXObject(PdfDocument);
    }

    public void AdicionarLogoImagem(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        AdicionarLogoImagem(fs);
    }

    public void Gerar()
    {
        if (foiGerado)
            throw new InvalidOperationException("O DANFE já foi gerado.");

        IdentificacaoEmitente.Logo = logoObject;
        var tabela = new ModuleProdutosServicos(ViewModel, EstiloPadrao);

        while (true)
        {
            var pagina = CriarPagina();

            tabela.SetPosition(pagina.RetanguloCorpo.Location);
            tabela.SetSize(pagina.RetanguloCorpo.Size);
            tabela.Draw(pagina.Gfx);

            pagina.Gfx.Stroke();
            pagina.Gfx.Flush();

            if (tabela.CompletamenteDesenhada)
                break;
        }

        PreencherNumeroFolhas();
        foiGerado = true;
    }

    private DanfePagina CriarPagina()
    {
        var pagina = new DanfePagina(this);
        Paginas.Add(pagina);

        pagina.DesenharBlocos(Paginas.Count == 1);
        pagina.DesenharCreditos();

        if (ViewModel.TipoAmbiente == 2)
            pagina.DesenharAvisoHomologacao();

        return pagina;
    }

    private void AdicionarMetadata()
    {
        var info = PdfDocument.Information;
        info[new org.pdfclown.objects.PdfName("ChaveAcesso")] = ViewModel.ChaveAcesso;
        info[new org.pdfclown.objects.PdfName("TipoDocumento")] = "DANFE";
        info.CreationDate = DateTime.Now;
        info.Creator = $"DanfeSharp {Assembly.GetExecutingAssembly().GetName().Version} - https://github.com/SilverCard/DanfeSharp";
        info.Title = "DANFE (Documento Auxiliar da NFe)";
    }

    private EstiloElement CriarEstilo(float tFonteCampoCabecalho = 6, float tFonteCampoConteudo = 10)
        => new(FonteRegular, FonteNegrito, FonteItalico, tFonteCampoCabecalho, tFonteCampoConteudo);

    private T CriarBloco<T>() where T : ModuleBase
        => (T)Activator.CreateInstance(typeof(T), ViewModel, EstiloPadrao)!;

    private T CriarBloco<T>(EstiloElement estilo) where T : ModuleBase
        => (T)Activator.CreateInstance(typeof(T), ViewModel, estilo)!;

    private T AdicionarBloco<T>() where T : ModuleBase
    {
        var bloco = CriarBloco<T>();
        Modules.Add(bloco);
        return bloco;
    }

    private T AdicionarBloco<T>(EstiloElement estilo) where T : ModuleBase
    {
        var bloco = CriarBloco<T>(estilo);
        Modules.Add(bloco);
        return bloco;
    }

    private void PreencherNumeroFolhas()
    {
        var total = Paginas.Count;
        for (var i = 0; i < total; i++)
            Paginas[i].DesenhaNumeroPaginas(i + 1, total);
    }

    public void Salvar(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        File.Save(path, SerializationModeEnum.Incremental);
    }

    public void Salvar(Stream stream)
    {
        ArgumentNullException.ThrowIfNull(stream);
        File.Save(new org.pdfclown.bytes.Stream(stream), SerializationModeEnum.Incremental);
    }

    public void Dispose()
    {
        File.Dispose();
        GC.SuppressFinalize(this);
    }
}
