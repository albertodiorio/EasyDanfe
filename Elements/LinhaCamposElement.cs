using EasyDanfe.Enums;

namespace EasyDanfe.Elements;

/// <summary>
/// Linha de campos, posiciona e muda a largura desses elementos de forma proporcional.
/// </summary>
internal class LinhaCamposElement : FlexibleLineElement
{
    public EstiloElement Estilo { get; private set; }

    public LinhaCamposElement(EstiloElement estilo, float width, float height = Constants.Constants.CampoAltura) : base()
    {
        Estilo = estilo;
        SetSize(width, height);
    }

    public LinhaCamposElement(EstiloElement estilo) : base()
    {
        Estilo = estilo;
    }

    public virtual LinhaCamposElement ComCampo(string cabecalho, string conteudo, AlinhamentoHorizontal alinhamentoHorizontalConteudo = AlinhamentoHorizontal.Esquerda)
    {
        var campo = new CampoElement(cabecalho, conteudo, Estilo, alinhamentoHorizontalConteudo);
        Elementos.Add(campo);
        return this;
    }

    public virtual LinhaCamposElement ComCampoNumerico(string cabecalho, decimal? conteudoNumerico, int casasDecimais = 2)
    {
        var campo = new CampoNumericoElement(cabecalho, conteudoNumerico, Estilo, casasDecimais);
        Elementos.Add(campo);
        return this;
    }
}
