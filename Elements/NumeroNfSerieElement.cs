using EasyDanfe.Enums;
using EasyDanfe.Extensions;
using EasyDanfe.Graphics;

namespace EasyDanfe.Elements;

class NumeroNfSerieElement(EstiloElement estilo, string nfNumero, string nfSerie) : ElementBase(estilo)
{
    public string NfNumero { get; private set; } = nfNumero;
    public string NfSerie { get; private set; } = nfSerie;

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);

        var r = BoundingBox.InflatedRetangle(1);

        var f1 = Estilo.CriarFonteNegrito(14);
        var f2 = Estilo.CriarFonteNegrito(11F);

        gfx.DrawString("NF-e", r, f1, AlinhamentoHorizontal.Centro);

        r = r.CutTop(f1.AlturaLinha);

        var ts = new TextStackElement(r)
        {
            AlinhamentoHorizontal = AlinhamentoHorizontal.Centro,
            AlinhamentoVertical = AlinhamentoVertical.Centro,
            LineHeightScale = 1F
        }
        .AddLine($"Nº.: {NfNumero}", f2)
        .AddLine($"Série: {NfSerie}", f2);

        ts.Draw(gfx);

    }
}