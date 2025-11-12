using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Elements;

public class CampoElement(string cabecalho, string conteudo, EstiloElement estilo) : IComponent
{
    private readonly string _cabecalho = cabecalho;
    private readonly string _conteudo = conteudo;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Border(_estilo.EspessuraBorda).BorderColor(_estilo.CorBorda).Padding(1).Column(column =>
        {
            column.Item().Text(_cabecalho).Style(_estilo.CabecalhoStyle(TextStyle.Default));
            column.Item().Text(_conteudo).Style(_estilo.ConteudoStyle(TextStyle.Default));
        });
    }
}
