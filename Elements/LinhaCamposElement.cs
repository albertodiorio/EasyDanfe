using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Elements;

public class LinhaCamposElement(Action<RowDescriptor> compose) : IComponent
{
    private readonly Action<RowDescriptor> _compose = compose;

    public void Compose(IContainer container)
    {
        container.Row(_compose);
    }
}
