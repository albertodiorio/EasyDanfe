using EasyDanfe.Enums;
using EasyDanfe.Extensions;
using EasyDanfe.Graphics;

namespace EasyDanfe.Elements;

class TextoSimplesElement(EstiloElement estilo, string texto) : ElementBase(estilo)
{
    public string Texto { get; private set; } = texto;
    public AlinhamentoHorizontal AlinhamentoHorizontal { get; set; } = AlinhamentoHorizontal.Esquerda;
    public AlinhamentoVertical AlinhamentoVertical { get; set; } = AlinhamentoVertical.Topo;
    public float TamanhoFonte { get; set; } = 6;

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);

        if (!string.IsNullOrWhiteSpace(Texto))
        {
            var r = BoundingBox.InflatedRetangle(0.75F);

            var tb = new TextBlockElement(Texto, Estilo.CriarFonteRegular(TamanhoFonte))
            {
                AlinhamentoHorizontal = AlinhamentoHorizontal,
                Width = r.Width
            };

            var y = r.Y;

            if (AlinhamentoVertical == AlinhamentoVertical.Centro)
                y += (r.Height - tb.Height) / 2F;

            tb.SetPosition(r.X, y);
            tb.Draw(gfx);
        }

    }
}
