using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Elements;

public class CabecalhoBlocoElement(string titulo, EstiloElement estilo) : IComponent
{
    private readonly string _titulo = titulo;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container
            .Background(_estilo.CorFundoCabecalho)
            .Border(1).BorderColor(_estilo.CorBorda)
            .PaddingVertical(1)
            .AlignCenter()
            .Text(_titulo)
            .Style(_estilo.CabecalhoStyle(TextStyle.Default))
            .FontSize(_estilo.TamanhoFonteCampoCabecalho + 1)
            .SemiBold();
    }
}
