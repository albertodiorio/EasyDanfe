using EasyDanfe.Elements;
using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleProdutosServicos(DanfeModel viewModel, EstiloElement estilo)
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Component(new CabecalhoBlocoElement("DADOS DOS PRODUTOS / SERVIÇOS", _estilo));

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1);  // CÓDIGO PRODUTO
                    columns.RelativeColumn(5);  // DESCRIÇÃO DO PRODUTO / SERVIÇO (longest)
                    columns.RelativeColumn(1);  // NCM/SH
                    columns.RelativeColumn(1);  // CST
                    columns.RelativeColumn(1);  // CFOP
                    columns.RelativeColumn(1);  // UNID.
                    columns.RelativeColumn(1);  // QUANT.
                    columns.RelativeColumn(1);  // V. UNIT.
                    columns.RelativeColumn(1);  // V. TOTAL
                    columns.RelativeColumn(1);  // BC ICMS
                    columns.RelativeColumn(1);  // V. ICMS
                    columns.RelativeColumn(1);  // V. IPI
                    columns.RelativeColumn(1);  // ALIQ. ICMS
                    columns.RelativeColumn(1);  // ALIQ. IPI

                });

                table.Header(header =>
                {
                    header.Cell().Element(CabecalhoCell).Text("CÓDIGO PRODUTO").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("DESCRIÇÃO DO PRODUTO / SERVIÇO").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("NCM/SH").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("CST").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("CFOP").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("UNID.").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("QUANT.").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("V. UNIT.").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("V. TOTAL").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("BC ICMS").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("V. ICMS").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("V. IPI").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("ALIQ. ICMS").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                    header.Cell().Element(CabecalhoCell).Text("ALIQ. IPI").Style(_estilo.CabecalhoStyle(TextStyle.Default));
                });

                foreach (var produto in _viewModel.Produtos)
                {
                    table.Cell().Element(ContentCell).Text(produto.Codigo).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).Column(col =>
                    {
                        col.Item().Text(produto.Descricao).Style(_estilo.ConteudoStyle(TextStyle.Default));
                        if (!string.IsNullOrWhiteSpace(produto.DescricaoImpostos))
                        {
                            col.Item().Text(produto.DescricaoImpostos).Style(_estilo.ConteudoStyle(TextStyle.Default).FontSize(_estilo.TamanhoFonteCampoConteudo - 1));
                        }
                    });
                    table.Cell().Element(ContentCell).Text(produto.Ncm).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).Text(produto.OCst).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).Text(produto.Cfop).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).Text(produto.Unidade).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(produto.Quantidade)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(produto.ValorUnitario)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(produto.ValorTotal)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(produto.BaseIcms)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(produto.ValorIcms)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(produto.ValorIpi)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(produto.AliquotaIcms)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                    table.Cell().Element(ContentCell).AlignRight().Text(Formatter.Format(produto.AliquotaIpi)).Style(_estilo.ConteudoStyle(TextStyle.Default));
                }
            });
        });
    }

    private IContainer CabecalhoCell(IContainer container) => container.Background(_estilo.CorFundoCabecalho).Padding(0.1f).Border(_estilo.EspessuraBorda).BorderColor(_estilo.CorBorda);
    private IContainer ContentCell(IContainer container) => container.Padding(0.1f).Border(_estilo.EspessuraBorda).BorderColor(_estilo.CorBorda);
}
