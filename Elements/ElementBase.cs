using EasyDanfe.Graphics;

namespace EasyDanfe.Elements;

/// <summary>
/// Elemento básico no DANFE.
/// </summary>
internal abstract class ElementBase(EstiloElement estilo) : DrawableBase
{
    public EstiloElement Estilo { get; protected set; } = estilo;
    public virtual bool PossuiContono => true;

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);

        if (PossuiContono)
            gfx.StrokeRectangle(BoundingBox, 0.25f);
    }
}
