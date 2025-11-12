using EasyDanfe.Elements;
using EasyDanfe.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleDadosAdicionais(DanfeModel viewModel, EstiloElement estilo)
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Component(new CabecalhoBlocoElement("DADOS ADICIONAIS", _estilo));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(7).Component(new CampoMultilinhaElement("INFORMAÇÕES COMPLEMENTARES", _viewModel.InformacoesComplementares, _estilo));
                row.RelativeItem(3).Component(new CampoMultilinhaElement("RESERVADO AO FISCO", _viewModel.InformacoesFisco, _estilo));
            }));
        });
    }
}
