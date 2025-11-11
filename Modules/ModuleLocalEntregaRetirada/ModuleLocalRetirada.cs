using EasyDanfe.Elements;
using EasyDanfe.Models;

namespace EasyDanfe.Modules.ModuleLocalEntregaRetirada;

class ModuleLocalRetirada(DanfeModel viewModel, EstiloElement estilo) : ModuleLocalEntregaRetirada(viewModel, estilo, viewModel.LocalRetirada)
{
    public override string Cabecalho => "Informações do local de retirada";
}