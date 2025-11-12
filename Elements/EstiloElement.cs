using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Elements;

public class EstiloElement(float tFonteCampoCabecalho = 4, float tFonteCampoConteudo = 5)
{
    public float TamanhoFonteCampoCabecalho { get; } = tFonteCampoCabecalho;
    public float TamanhoFonteCampoConteudo { get; } = tFonteCampoConteudo;
    public Color CorBorda { get; } = Colors.Grey.Lighten2;
    public Color CorFundoCabecalho { get; } = Colors.Grey.Lighten3;
    public float EspessuraBorda { get; } = 0.5f;

    public TextStyle CabecalhoStyle(TextStyle textStyle) => textStyle
        .FontSize(TamanhoFonteCampoCabecalho)
        .SemiBold()
        .FontFamily(Fonts.Verdana);

    public TextStyle ConteudoStyle(TextStyle textStyle) => textStyle
        .FontSize(TamanhoFonteCampoConteudo)
        .FontFamily(Fonts.Verdana);

    public TextStyle ConteudoNegritoStyle(TextStyle textStyle) => textStyle
        .FontSize(TamanhoFonteCampoConteudo)
        .SemiBold()
        .FontFamily(Fonts.Verdana);

    public TextStyle ConteudoItalicoStyle(TextStyle textStyle) => textStyle
        .FontSize(TamanhoFonteCampoConteudo)
        .Italic()
        .FontFamily(Fonts.Verdana);
}
