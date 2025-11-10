using EasyDanfe.Elements;
using EasyDanfe.Models;

namespace EasyDanfe.Modules.ModuleLocalEntregaRetirada;

class ModuleLocalEntrega(DanfeViewModel viewModel, EstiloElement estilo) : ModuleLocalEntregaRetirada(viewModel, estilo, viewModel.LocalEntrega)
{
    public override string Cabecalho => "Informações do local de entrega";
}
