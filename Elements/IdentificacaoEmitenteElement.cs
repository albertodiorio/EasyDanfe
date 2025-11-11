using EasyDanfe.Enums;
using EasyDanfe.Extensions;
using EasyDanfe.Graphics;
using EasyDanfe.Models;
using org.pdfclown.documents.contents.xObjects;
using System.Drawing;

namespace EasyDanfe.Elements;

internal class IdentificacaoEmitenteElement : ElementBase
{
    public DanfeModel ViewModel { get; private set; }
    public XObject Logo { get; set; }

    public IdentificacaoEmitenteElement(EstiloElement estilo, DanfeModel viewModel) : base(estilo)
    {
        ViewModel = viewModel;
        Logo = null;
    }

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);

        var rp = BoundingBox.InflatedRetangle(0.75F);
        float alturaMaximaLogoHorizontal = 14F;

        Fonte f2 = Estilo.CriarFonteNegrito(12);
        Fonte f3 = Estilo.CriarFonteRegular(8);

        if (Logo == null)
        {
            var f1 = Estilo.CriarFonteRegular(6);
            gfx.DrawString("IDENTIFICAÇÃO DO EMITENTE", rp, f1, AlinhamentoHorizontal.Centro);
            rp = rp.CutTop(f1.AlturaLinha);
        }
        else
        {
            RectangleF rLogo;

            // Logo Horizontal
            if (Logo.Size.Width > Logo.Size.Height)
            {
                rLogo = new RectangleF(rp.X, rp.Y, rp.Width, alturaMaximaLogoHorizontal);
                rp = rp.CutTop(alturaMaximaLogoHorizontal);
            }
            // Logo Vertical / Quadrado
            else
            {
                float lw = rp.Height * Logo.Size.Width / Logo.Size.Height;
                rLogo = new RectangleF(rp.X, rp.Y, lw, rp.Height);
                rp = rp.CutLeft(lw);
            }

            gfx.ShowXObject(Logo, rLogo);

        }

        var emitente = ViewModel.Emitente;

        string nome = emitente.RazaoSocial;

        if (ViewModel.PreferirEmitenteNomeFantasia)
        {
            nome = !String.IsNullOrWhiteSpace(emitente.NomeFantasia) ? emitente.NomeFantasia : emitente.RazaoSocial;
        }

        var ts = new TextStackElement(rp) { LineHeightScale = 1 }
            .AddLine(nome, f2)
            .AddLine(emitente.EnderecoLinha1.Trim(), f3)
            .AddLine(emitente.EnderecoLinha2.Trim(), f3)
            .AddLine(emitente.EnderecoLinha3.Trim(), f3);

        ts.AlinhamentoHorizontal = AlinhamentoHorizontal.Centro;
        ts.AlinhamentoVertical = AlinhamentoVertical.Centro;
        ts.Draw(gfx);
    }
}
