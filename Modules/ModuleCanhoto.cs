using EasyDanfe.Elements;
using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Modules;

public class ModuleCanhoto(DanfeModel viewModel, EstiloElement estilo)
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Text("RECEBEMOS OS PRODUTOS CONSTANTES DA NOTA FISCAL ELETRÔNICA ABAIXO:").Style(_estilo.CabecalhoStyle(TextStyle.Default));
            column.Item().Row(row =>
            {
                row.RelativeItem(3).Component(new CampoElement("Nº DA NOTA FISCAL", _viewModel.Numero, _estilo));
                row.RelativeItem(3).Component(new CampoElement("SÉRIE", _viewModel.Serie, _estilo));
                row.RelativeItem(4).Component(new CampoElement("DATA DE RECEBIMENTO", string.Empty, _estilo));
                row.RelativeItem(4).Component(new CampoElement("IDENTIFICAÇÃO E ASSINATURA DO RECEBEDOR", string.Empty, _estilo));
            });
            column.Item().Row(row =>
            {
                row.RelativeItem(5).Component(new CampoElement("NOME/RAZÃO SOCIAL", _viewModel.Destinatario.RazaoSocial, _estilo));
                row.RelativeItem(5).Component(new CampoElement("CNPJ/CPF", Formatter.FormatCnpjCpf(_viewModel.Destinatario.CnpjCpf), _estilo));
            });
            column.Item().Component(new LinhaTracejadaElement());
            column.Spacing(5);
        });
    }
}
