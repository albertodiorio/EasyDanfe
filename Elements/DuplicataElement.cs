using EasyDanfe.Attributtes;
using EasyDanfe.Enums;
using EasyDanfe.Extensions;
using EasyDanfe.Graphics;
using EasyDanfe.Models;
using EasyDanfe.Utils;

namespace EasyDanfe.Elements;

[AlturaFixa]
internal class DuplicataElement(EstiloElement estilo, DuplicataModel viewModel) : ElementBase(estilo)
{
    public Fonte FonteA { get; private set; } = estilo.CriarFonteRegular(7.5F);
    public Fonte FonteB { get; private set; } = estilo.CriarFonteNegrito(7.5F);
    public DuplicataModel ViewModel { get; private set; } = viewModel;

    private static readonly string[] Chaves = { "Número", "Vencimento:", "Valor:" };

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);

        var r = BoundingBox.InflatedRetangle(Estilo.PaddingSuperior, Estilo.PaddingInferior, Estilo.PaddingHorizontal);

        string[] valores = { ViewModel.Numero, ViewModel.Vecimento.Formatar(), ViewModel.Valor.FormatarMoeda() };

        for (int i = 0; i < Chaves.Length; i++)
        {
            gfx.DrawString(Chaves[i], r, FonteA, AlinhamentoHorizontal.Esquerda);
            gfx.DrawString(valores[i], r, FonteB, AlinhamentoHorizontal.Direita);
            r = r.CutTop(FonteB.AlturaLinha);
        }

    }

    public override float Height
    {
        get => 3 * FonteB.AlturaLinha + Estilo.PaddingSuperior + Estilo.PaddingInferior;
        set => throw new NotSupportedException();
    }
}
