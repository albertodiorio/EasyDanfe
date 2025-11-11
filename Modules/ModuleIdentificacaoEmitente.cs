using EasyDanfe.Constants;
using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;
using NFe.Danfe.PdfClown.Tools;
using org.pdfclown.documents.contents.xObjects;
using System.Drawing;

namespace EasyDanfe.Modules;

internal class ModuleIdentificacaoEmitente : ModuleBase
{
    public const float LarguraCampoChaveNFe = 93F;
    public const float AlturaLinha1 = 30;

    private readonly NumeroNfSerie2Element ifdNfe;
    private readonly IdentificacaoEmitenteElement idEmitente;

    public ModuleIdentificacaoEmitente(DanfeModel viewModel, EstiloElement estilo) : base(viewModel, estilo)
    {

        var textoConsulta = new TextoSimplesElement(Estilo, Strings.TextoConsulta)
        {
            Height = 8,
            AlinhamentoHorizontal = AlinhamentoHorizontal.Centro,
            AlinhamentoVertical = AlinhamentoVertical.Centro,
            TamanhoFonte = 9
        };

        var campoChaveAcesso = new CampoElement("Chave de Acesso", Formatador.FormatarChaveAcesso(ViewModel.ChaveAcesso), estilo, AlinhamentoHorizontal.Centro) { Height = Constants.Constants.CampoAltura };
        var codigoBarras = new Barcode128CElement(viewModel.ChaveAcesso, Estilo) { Height = AlturaLinha1 - textoConsulta.Height - campoChaveAcesso.Height };

        var coluna3 = new VerticalStackElement();
        coluna3.Add(codigoBarras, campoChaveAcesso, textoConsulta);

        ifdNfe = new NumeroNfSerie2Element(estilo, ViewModel);
        idEmitente = new IdentificacaoEmitenteElement(Estilo, ViewModel);

        var fl = new FlexibleLineElement() { Height = coluna3.Height }
        .ComElemento(idEmitente)
        .ComElemento(ifdNfe)
        .ComElemento(coluna3)
        .ComLarguras(0, 15, 46.5F);

        MainVerticalStack.Add(fl);

        AdicionarLinhaCampos()
            .ComCampo("Natureza da operação", ViewModel.NaturezaOperacao)
            .ComCampo("Protocolo de autorização", ViewModel.ProtocoloAutorizacao, AlinhamentoHorizontal.Centro)
            .ComLarguras(0, 46.5F);

        AdicionarLinhaCampos()
            .ComCampo("Inscrição Estadual", ViewModel.Emitente.Ie, AlinhamentoHorizontal.Centro)
            .ComCampo("Inscrição Estadual do Subst. Tributário", ViewModel.Emitente.IeSt, AlinhamentoHorizontal.Centro)
            .ComCampo("Inscrição Municipal", ViewModel.Emitente.IM, AlinhamentoHorizontal.Centro)
            .ComCampo("Cnpj", Formatador.FormatarCnpj(ViewModel.Emitente.CnpjCpf), AlinhamentoHorizontal.Centro)
            .ComLargurasIguais();

    }

    public XObject Logo
    {
        get => idEmitente.Logo;
        set => idEmitente.Logo = value;
    }

    public override PosicaoBloco Posicao => PosicaoBloco.Topo;
    public override bool VisivelSomentePrimeiraPagina => false;
    public RectangleF RetanguloNumeroFolhas => ifdNfe.RetanguloNumeroFolhas;
}