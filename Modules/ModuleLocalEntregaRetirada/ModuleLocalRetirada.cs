using EasyDanfe.Elements;
using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules.ModuleLocalEntregaRetirada;

public class ModuleLocalRetirada(DanfeModel viewModel, EstiloElement estilo)
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        if (_viewModel.LocalRetirada is null || !_viewModel.ExibirBlocoLocalRetirada)
            return;

        container.Column(column =>
        {
            column.Item().Component(new CabecalhoBlocoElement("LOCAL DE RETIRADA", _estilo));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(5).Component(new CampoElement("ENDEREÇO", _viewModel.LocalRetirada.Endereco, _estilo));
                row.RelativeItem(3).Component(new CampoElement("MUNICÍPIO", _viewModel.LocalRetirada.Municipio, _estilo));
                row.RelativeItem(1).Component(new CampoElement("UF", _viewModel.LocalRetirada.Uf, _estilo));
                row.RelativeItem(1).Component(new CampoElement("CNPJ / CPF", Formatter.FormatCnpjCpf(_viewModel.LocalRetirada.CnpjCpf), _estilo));
            }));
        });
    }
}
