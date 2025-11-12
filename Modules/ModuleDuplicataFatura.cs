using EasyDanfe.Elements;
using EasyDanfe.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleDuplicataFatura(DanfeModel viewModel, EstiloElement estilo)
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        if (_viewModel.Duplicatas.Count == 0)
            return;

        container.Column(column =>
        {
            column.Item().Component(new CabecalhoBlocoElement("FATURA / DUPLICATAS", _estilo));
            column.Item().Component(new DuplicataElement(_viewModel.Duplicatas, _estilo));
        });
    }
}
