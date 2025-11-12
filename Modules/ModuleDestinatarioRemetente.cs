using EasyDanfe.Elements;
using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleDestinatarioRemetente(DanfeModel viewModel, EstiloElement estilo)
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Component(new CabecalhoBlocoElement("DESTINATÁRIO / REMETENTE", _estilo));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(5).Component(new CampoElement("NOME / RAZÃO SOCIAL", _viewModel.Destinatario.RazaoSocial, _estilo));
                row.RelativeItem(3).Component(new CampoElement("CNPJ / CPF", Formatter.FormatCnpjCpf(_viewModel.Destinatario.CnpjCpf), _estilo));
                row.RelativeItem(2).Component(new CampoElement("DATA DA EMISSÃO", Formatter.Format(_viewModel.DataEmissao), _estilo));
            }));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(5).Component(new CampoElement("ENDEREÇO", _viewModel.Destinatario.EnderecoLinha1, _estilo));
                row.RelativeItem(3).Component(new CampoElement("BAIRRO / DISTRITO", _viewModel.Destinatario.EnderecoBairro, _estilo));
                row.RelativeItem(2).Component(new CampoElement("DATA SAÍDA / ENTRADA", Formatter.Format(_viewModel.DataSaidaEntrada), _estilo));
            }));

            column.Item().Component(new LinhaCamposElement(row =>
            {
                row.RelativeItem(3).Component(new CampoElement("MUNICÍPIO", _viewModel.Destinatario.Municipio, _estilo));
                row.RelativeItem(1).Component(new CampoElement("UF", _viewModel.Destinatario.EnderecoUf, _estilo));
                row.RelativeItem(2).Component(new CampoElement("CEP", Formatter.FormatCep(_viewModel.Destinatario.EnderecoCep), _estilo));
                row.RelativeItem(2).Component(new CampoElement("INSCRIÇÃO ESTADUAL", _viewModel.Destinatario.Ie, _estilo));
                row.RelativeItem(2).Component(new CampoElement("TELEFONE", Formatter.FormatTelefone(_viewModel.Destinatario.Telefone), _estilo));
            }));
        });
    }
}
