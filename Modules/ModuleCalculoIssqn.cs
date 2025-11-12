using EasyDanfe.Elements;
using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleCalculoIssqn(DanfeModel viewModel, EstiloElement estilo)
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        if (!_viewModel.CalculoIssqn.Mostrar)
            return;

        container.Column(column =>
        {
            column.Item().Component(new CabecalhoBlocoElement("CÁLCULO DO ISSQN", _estilo));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(3).Component(new CampoNumericoElement("BASE DE CÁLCULO DO ISSQN", Formatter.Format(_viewModel.CalculoIssqn.BaseIssqn), _estilo));
                row.RelativeItem(3).Component(new CampoNumericoElement("VALOR TOTAL DO ISSQN", Formatter.Format(_viewModel.CalculoIssqn.ValorIssqn), _estilo));
                row.RelativeItem(4).Component(new CampoNumericoElement("VALOR TOTAL DOS SERVIÇOS", Formatter.Format(_viewModel.CalculoIssqn.ValorTotalServicos), _estilo));
            }));
        });
    }
}
