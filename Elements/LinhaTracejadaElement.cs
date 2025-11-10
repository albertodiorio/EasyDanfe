using EasyDanfe.Extensions;
using EasyDanfe.Graphics;
using System.Drawing;

namespace EasyDanfe.Elements;

internal class LinhaTracejadaElement(float margin) : DrawableBase
{
    public float Margin { get; set; } = margin;
    public double[] DashPattern { get; set; }

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);

        gfx.PrimitiveComposer.BeginLocalState();
        gfx.PrimitiveComposer.SetLineDash(new org.pdfclown.documents.contents.LineDash(new double[] { 3, 2 }));
        gfx.PrimitiveComposer.DrawLine(new PointF(BoundingBox.Left, Y + Margin).ToPointMeasure(), new PointF(BoundingBox.Right, Y + Margin).ToPointMeasure());
        gfx.PrimitiveComposer.Stroke();
        gfx.PrimitiveComposer.End();

    }

    public override float Height { get => 2 * Margin; set => throw new NotSupportedException(); }
}
