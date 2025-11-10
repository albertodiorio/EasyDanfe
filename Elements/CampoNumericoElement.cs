using EasyDanfe.Enums;
using EasyDanfe.Graphics;

namespace EasyDanfe.Elements;

/// <summary>
/// Campo para valores numéricos.
/// </summary>
internal class CampoNumericoElement(string cabecalho, double? conteudoNumerico, EstiloElement estilo, int casasDecimais = 2) : CampoElement(cabecalho, null, estilo, AlinhamentoHorizontal.Direita)
{
    private double? ConteudoNumerico { get; set; } = conteudoNumerico;
    public int CasasDecimais { get; set; } = casasDecimais;

    protected override void DesenharConteudo(Gfx gfx)
    {
        base.Conteudo = ConteudoNumerico.HasValue ? ConteudoNumerico.Value.ToString($"N{CasasDecimais}", Utils.Formatador.Cultura) : null;
        base.DesenharConteudo(gfx);
    }
}
