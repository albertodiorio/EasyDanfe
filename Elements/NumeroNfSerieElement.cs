using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Elements;

public class NumeroNfSerieElement(string numero, string serie, EstiloElement estilo) : IComponent
{
    private readonly string _numero = numero;
    private readonly string _serie = serie;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Component(new CampoElement("Nº", _numero, _estilo));
            column.Item().Component(new CampoElement("SÉRIE", _serie, _estilo));
        });
    }
}
