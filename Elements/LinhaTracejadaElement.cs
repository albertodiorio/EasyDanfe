using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Elements;

public class LinhaTracejadaElement : IComponent
{
    public void Compose(IContainer container)
    {
        container.LineHorizontal(1)
            .LineColor(Colors.Grey.Lighten1)
            .LineDashPattern([3, 3]);
    }
}
