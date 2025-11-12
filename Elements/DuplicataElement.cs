using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Elements;

public class DuplicataElement(List<DuplicataModel> duplicatas, EstiloElement estilo) : IComponent
{
    private readonly List<DuplicataModel> _duplicatas = duplicatas;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            table.Header(header =>
            {
                header.Cell().Element(CabecalhoCell).Text("Número").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                header.Cell().Element(CabecalhoCell).Text("Vencimento").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                header.Cell().Element(CabecalhoCell).Text("Valor").Style(_estilo.CabecalhoStyle(TextStyle.Default));
            });

            foreach (var duplicata in _duplicatas)
            {
                table.Cell().Element(ContentCell).Text(duplicata.Numero).Style(_estilo.ConteudoStyle(TextStyle.Default));
                table.Cell().Element(ContentCell).Text(Formatter.Format(duplicata.Vecimento)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(duplicata.Valor)).Style(_estilo.ConteudoStyle(TextStyle.Default));
            }
        });
    }

    private IContainer CabecalhoCell(IContainer container) => container.Background(_estilo.CorFundoCabecalho).Padding(1).Border(_estilo.EspessuraBorda).BorderColor(_estilo.CorBorda);
    private IContainer ContentCell(IContainer container) => container.Padding(1).Border(_estilo.EspessuraBorda).BorderColor(_estilo.CorBorda);
}
