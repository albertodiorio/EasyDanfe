using EasyDanfe.Elements;
using EasyDanfe.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleIdentificacaoEmitente(DanfeModel viewModel, EstiloElement estilo)
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Component(new IdentificacaoEmitenteElement(_viewModel, _estilo));
    }
}
