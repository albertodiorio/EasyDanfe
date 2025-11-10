using EasyDanfe.Enums;

namespace EasyDanfe.Elements;

internal class TabelaColunaElement(string[] cabecalho, float porcentagemLargura, AlinhamentoHorizontal alinhamentoHorizontal = AlinhamentoHorizontal.Esquerda)
{
    public string[] Cabecalho { get; private set; } = cabecalho;
    public float PorcentagemLargura { get; set; } = porcentagemLargura;
    public AlinhamentoHorizontal AlinhamentoHorizontal { get; private set; } = alinhamentoHorizontal;

    public override string ToString()
    {
        return string.Join(" ", Cabecalho);
    }
}
