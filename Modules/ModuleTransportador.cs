using EasyDanfe.Elements;
using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleTransportador
{
    private readonly DanfeModel _viewModel;
    private readonly EstiloElement _estilo;

    public ModuleTransportador(DanfeModel viewModel, EstiloElement estilo)
    {
        _viewModel = viewModel;
        _estilo = estilo;
    }

    public void Compose(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Component(new CabecalhoBlocoElement("TRANSPORTADOR / VOLUMES TRANSPORTADOS", _estilo));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(2).Component(new CampoElement("MODALIDADE DO FRETE", _viewModel.Transportadora.ModalidadeFreteString, _estilo));
                row.RelativeItem(4).Component(new CampoElement("NOME / RAZÃO SOCIAL", _viewModel.Transportadora.RazaoSocial, _estilo));
                row.RelativeItem(2).Component(new CampoElement("CNPJ / CPF", Formatter.FormatCnpjCpf(_viewModel.Transportadora.CnpjCpf), _estilo));
                row.RelativeItem(2).Component(new CampoElement("INSCRIÇÃO ESTADUAL", _viewModel.Transportadora.Ie, _estilo));
            }));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(4).Component(new CampoElement("ENDEREÇO", _viewModel.Transportadora.EnderecoLinha1, _estilo));
                row.RelativeItem(3).Component(new CampoElement("MUNICÍPIO", _viewModel.Transportadora.Municipio, _estilo));
                row.RelativeItem(1).Component(new CampoElement("UF", _viewModel.Transportadora.EnderecoUf, _estilo));
                row.RelativeItem(2).Component(new CampoElement("PLACA DO VEÍCULO", _viewModel.Transportadora.Placa, _estilo));
            }));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(2).Component(new CampoNumericoElement("QUANTIDADE", Formatter.Format(_viewModel.Transportadora.QuantidadeVolumes), _estilo));
                row.RelativeItem(2).Component(new CampoElement("ESPÉCIE", _viewModel.Transportadora.Especie, _estilo));
                row.RelativeItem(2).Component(new CampoElement("MARCA", _viewModel.Transportadora.Marca, _estilo));
                row.RelativeItem(2).Component(new CampoElement("NUMERAÇÃO", _viewModel.Transportadora.Numeracao, _estilo));
                row.RelativeItem(1).Component(new CampoNumericoElement("PESO BRUTO", Formatter.Format(_viewModel.Transportadora.PesoBruto), _estilo));
                row.RelativeItem(1).Component(new CampoNumericoElement("PESO LÍQUIDO", Formatter.Format(_viewModel.Transportadora.PesoLiquido), _estilo));
            }));
        });
    }
}
