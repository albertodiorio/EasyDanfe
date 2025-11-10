using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;

namespace EasyDanfe.Modules;

internal class ModuleCanhoto : ModuleBase
{
    public const float TextoRecebimentoAltura = 10;
    public const float AlturaLinha2 = 9;

    public ModuleCanhoto(DanfeViewModel viewModel, EstiloElement estilo) : base(viewModel, estilo)
    {
        var textoRecebimento = new TextoSimplesElement(estilo, viewModel.TextoRecebimento) { Height = TextoRecebimentoAltura, TamanhoFonte = 8 };
        var nfe = new NumeroNfSerieElement(estilo, viewModel.NfNumero.ToString(Utils.Formatador.FormatoNumeroNF), viewModel.NfSerie.ToString()) { Height = AlturaLinha2 + TextoRecebimentoAltura, Width = 30 };

        var campos = new LinhaCamposElement(Estilo) { Height = AlturaLinha2 }
           .ComCampo("Data de Recebimento", null)
           .ComCampo("Identificação e assinatura do recebedor", null)
           .ComLarguras(50, 0);

        var coluna1 = new VerticalStackElement();
        coluna1.Add(textoRecebimento, campos);

        var linha = new FlexibleLineElement() { Height = coluna1.Height }
        .ComElemento(coluna1)
        .ComElemento(nfe)
        .ComLarguras(0, 16);

        MainVerticalStack.Add(linha, new LinhaTracejadaElement(2));

    }

    public override PosicaoBloco Posicao => PosicaoBloco.Topo;

}