using EasyDanfe.Elements;
using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleCalculoImposto(DanfeModel viewModel, EstiloElement estilo)
{
    public void Compose(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Component(new CabecalhoBlocoElement("CÁLCULO DO IMPOSTO", estilo));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(2).Component(new CampoNumericoElement("BASE DE CÁLCULO DO ICMS", Formatter.Format(viewModel.CalculoImposto.BaseCalculoIcms), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("VALOR DO ICMS", Formatter.Format(viewModel.CalculoImposto.ValorIcms), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("BASE DE CÁLCULO ICMS ST", Formatter.Format(viewModel.CalculoImposto.BaseCalculoIcmsSt), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("VALOR DO ICMS ST", Formatter.Format(viewModel.CalculoImposto.ValorIcmsSt), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("VALOR TOTAL DOS PRODUTOS", Formatter.Format(viewModel.CalculoImposto.ValorTotalProdutos), estilo));
            }));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(2).Component(new CampoNumericoElement("VALOR DO FRETE", Formatter.Format(viewModel.CalculoImposto.ValorFrete), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("VALOR DO SEGURO", Formatter.Format(viewModel.CalculoImposto.ValorSeguro), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("VALOR DO DESCONTO", Formatter.Format(viewModel.CalculoImposto.ValorDesconto), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("OUTRAS DESPESAS ACESSÓRIAS", Formatter.Format(viewModel.CalculoImposto.OutrasDespesas), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("VALOR TOTAL DO IPI", Formatter.Format(viewModel.CalculoImposto.ValorIpi), estilo));
                row.RelativeItem(2).Component(new CampoNumericoElement("VALOR TOTAL DA NOTA", Formatter.Format(viewModel.CalculoImposto.ValorTotalNota), estilo));
            }));
        });
    }
}
