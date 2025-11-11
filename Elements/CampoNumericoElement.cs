using EasyDanfe.Enums;
using EasyDanfe.Graphics;

namespace EasyDanfe.Elements;

/// <summary>
/// Campo para valores numéricos.
/// </summary>
internal class CampoNumericoElement(string cabecalho, decimal? conteudoNumerico, EstiloElement estilo, int casasDecimais = 2) : CampoElement(cabecalho, null, estilo, AlinhamentoHorizontal.Direita)
{
    private decimal? ConteudoNumerico { get; set; } = conteudoNumerico;
    public int CasasDecimais { get; set; } = casasDecimais;

    protected override void DesenharConteudo(Gfx gfx)
    {
        base.Conteudo = ConteudoNumerico.HasValue ? ConteudoNumerico.Value.ToString($"N{CasasDecimais}", Utils.Formatter.Cultura) : null;
        base.DesenharConteudo(gfx);
    }
}
