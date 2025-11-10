using EasyDanfe.Enums;
using EasyDanfe.Extensions;
using EasyDanfe.Graphics;
using EasyDanfe.Models;
using NFe.Danfe.PdfClown.Tools;
using System.Drawing;

namespace EasyDanfe.Elements;

class NumeroNfSerie2Element(EstiloElement estilo, DanfeViewModel viewModel) : ElementBase(estilo)
{
    public RectangleF RetanguloNumeroFolhas { get; private set; }
    public DanfeViewModel ViewModel { get; private set; } = viewModel;

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);

        float paddingHorizontal = ViewModel.Orientacao == Orientacao.Retrato ? 2.5F : 5F;

        var rp1 = BoundingBox.InflatedRetangle(1F, 0.5F, paddingHorizontal);
        var rp2 = rp1;

        var f1 = Estilo.CriarFonteNegrito(12);
        var f1h = f1.AlturaLinha;
        gfx.DrawString("DANFE", rp2, f1, AlinhamentoHorizontal.Centro);

        rp2 = rp2.CutTop(f1h + 0.5F);

        var f2 = Estilo.CriarFonteRegular(8F);
        var f2h = f2.AlturaLinha;

        var ts = new TextStackElement(rp2)
        {
            AlinhamentoVertical = AlinhamentoVertical.Topo
        }
        .AddLine("Documento Auxiliar da", f2)
        .AddLine("Nota Fiscal Eletrônica", f2);

        ts.Draw(gfx);

        rp2 = rp2.CutTop(2F * f2h + 1.5F);


        ts = new TextStackElement(rp2)
        {
            AlinhamentoVertical = AlinhamentoVertical.Topo,
            AlinhamentoHorizontal = AlinhamentoHorizontal.Esquerda
        }
        .AddLine("0 - ENTRADA", f2)
        .AddLine("1 - SAÍDA", f2);
        ts.Draw(gfx);

        float rectEsSize = 1.75F * f2h;
        var rectEs = new RectangleF(rp2.Right - rectEsSize, rp2.Y + (2F * f2h - rectEsSize) / 2F, rectEsSize, rectEsSize);

        gfx.StrokeRectangle(rectEs, 0.25F);

        gfx.DrawString(ViewModel.TipoNF.ToString(), rectEs, Estilo.FonteNumeroFolhas, AlinhamentoHorizontal.Centro, AlinhamentoVertical.Centro);


        var f4 = Estilo.FonteNumeroFolhas;
        var f4h = Estilo.FonteNumeroFolhas.AlturaLinha;

        rp2.Height = 2F * f4h * TextStackElement.DefaultLineHeightScale + f2h;
        rp2.Y = rp1.Bottom - rp2.Height;

        ts = new TextStackElement(rp2)
        {
            AlinhamentoVertical = AlinhamentoVertical.Topo,
            AlinhamentoHorizontal = AlinhamentoHorizontal.Centro
        }
        .AddLine("Nº.: " + ViewModel.NfNumero.ToString(Utils.Formatador.FormatoNumeroNF), f4)
        .AddLine($"Série: {ViewModel.NfSerie}", f4);

        ts.Draw(gfx);

        RetanguloNumeroFolhas = new RectangleF(rp1.Left, rp1.Bottom - Estilo.FonteNumeroFolhas.AlturaLinha, rp1.Width, Estilo.FonteNumeroFolhas.AlturaLinha);
    }
}