using EasyDanfe.Elements;
using EasyDanfe.Models;
using EasyDanfe.Modules;
using EasyDanfe.Modules.ModuleLocalEntregaRetirada;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace EasyDanfe;

public class Danfe : IDocument
{
    public DanfeModel ViewModel { get; }

    public Danfe(DanfeModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);
        ViewModel = viewModel;
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public Danfe(string xmlPath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(xmlPath);
        ViewModel = DanfeModelCreator.CreateFromXmlString(xmlPath);
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public DocumentMetadata GetMetadata() => new()
    {
        Title = "DANFE (Documento Auxiliar da NFe)",
        Author = $"EasyDanfe {Assembly.GetExecutingAssembly().GetName().Version}",
        Subject = "Documento Auxiliar da Nota Fiscal Eletrônica",
        Keywords = "DANFE, NFe",
        CreationDate = DateTime.Now,
        ModifiedDate = DateTime.Now
    };

    private readonly EstiloElement _estiloPadrao = new();

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Size(ViewModel.Orientacao == Enums.Orientacao.Paisagem ? PageSizes.A4.Landscape() : PageSizes.A4);
                page.Margin(10);
                page.DefaultTextStyle(x => x.FontSize(5));

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
    }

    private void ComposeHeader(IContainer container)
    {

        container.Column(column =>
        {
            column.Spacing(5);
            column.Item().ShowIf(context => context.PageNumber == 1).Element(c => new ModuleCanhoto(ViewModel, _estiloPadrao).Compose(c));
            column.Item().Element(c => new ModuleIdentificacaoEmitente(ViewModel, _estiloPadrao).Compose(c));
            column.Item().Element(c => new ModuleDestinatarioRemetente(ViewModel, _estiloPadrao).Compose(c));

            if (ViewModel.LocalRetirada is not null && ViewModel.ExibirBlocoLocalRetirada)
                column.Item().Element(c => new ModuleLocalRetirada(ViewModel, _estiloPadrao).Compose(c));

            if (ViewModel.LocalEntrega is not null && ViewModel.ExibirBlocoLocalEntrega)
                column.Item().Element(c => new ModuleLocalEntrega(ViewModel, _estiloPadrao).Compose(c));

            if (ViewModel.Duplicatas.Count > 0)
                column.Item().Element(c => new ModuleDuplicataFatura(ViewModel, _estiloPadrao).Compose(c));

            column.Item().Element(c => new ModuleCalculoImposto(ViewModel, _estiloPadrao).Compose(c));
            column.Item().Element(c => new ModuleTransportador(ViewModel, _estiloPadrao).Compose(c));
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Element(c => new ModuleProdutosServicos(ViewModel, _estiloPadrao).Compose(c));
            if (ViewModel.CalculoIssqn.Mostrar)
                column.Item().Element(c => new ModuleCalculoIssqn(ViewModel, _estiloPadrao).Compose(c));

            column.Item().Element(c => new ModuleDadosAdicionais(ViewModel, _estiloPadrao).Compose(c));

        });
    }

    private void ComposeFooter(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().AlignLeft().Text($"Chave de Acesso: {ViewModel.ChaveAcesso}").Style(_estiloPadrao.CabecalhoStyle(TextStyle.Default));
            row.RelativeItem().AlignRight().Text(x =>
            {
                x.CurrentPageNumber();
                x.Span(" / ");
                x.TotalPages();
            });
        });
    }
    public void Salvar(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        GeneratePdf(path);
    }

    public void Salvar(Stream stream)
    {
        ArgumentNullException.ThrowIfNull(stream);
        GeneratePdf(stream);
    }

    public void GeneratePdf(string path)
    {
        QuestPDF.Fluent.Document
            .Create(container => Compose(container))
            .GeneratePdf(path);
    }

    public void GeneratePdf(Stream stream)
    {
        try
        {
            QuestPDF.Fluent.Document
                .Create(container => Compose(container))
                .GeneratePdf(stream);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao gerar o PDF do DANFE.", ex);
        }
    }

    public void AdicionarLogoImagem(Stream stream)
    {
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        ViewModel.Logo = ms.ToArray();
    }

    public void AdicionarLogoImagem(string path)
    {
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        AdicionarLogoImagem(fs);
    }
}