using EasyDanfe.Enums;
using EasyDanfe.Graphics;

namespace EasyDanfe.Elements;

/// <summary>
/// Cabeçalho do bloco, normalmente um texto em caixa alta.
/// </summary>
internal class CabecalhoBlocoElement(EstiloElement estilo, string cabecalho) : ElementBase(estilo)
{
    public const float MargemSuperior = 0.8F;
    public string Cabecalho { get; set; } = cabecalho;

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);
        gfx.DrawString(Cabecalho.ToUpper(), BoundingBox, Estilo.FonteBlocoCabecalho,
            AlinhamentoHorizontal.Esquerda, AlinhamentoVertical.Base);
    }

    public override float Height { get => MargemSuperior + Estilo.FonteBlocoCabecalho.AlturaLinha; set => throw new NotSupportedException(); }
    public override bool PossuiContono => false;
}
