using EasyDanfe.Models;
using EasyDanfe.Utils;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EasyDanfe.Elements;

public class IdentificacaoEmitenteElement(DanfeModel viewModel, EstiloElement estilo) : IComponent
{
    private readonly DanfeModel _viewModel = viewModel;
    private readonly EstiloElement _estilo = estilo;

    public void Compose(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem(3).Border(_estilo.EspessuraBorda).BorderColor(_estilo.CorBorda).Column(column =>
            {
                column.Item().Row(logoRow =>
                {
                    logoRow.RelativeItem(1).AlignLeft().Text(string.Empty).Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(7);
                    logoRow.RelativeItem(8).PaddingLeft(1).Column(emitenteColumn =>
                    {
                        emitenteColumn.Item().Text(_viewModel.Emitente.RazaoSocial).Style(_estilo.ConteudoNegritoStyle(TextStyle.Default)).FontSize(7).ClampLines(1);
                        emitenteColumn.Item().Text(_viewModel.Emitente.EnderecoLinha1).Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(7).ClampLines(1);
                        emitenteColumn.Item().Text($"{_viewModel.Emitente.Municipio} - {_viewModel.Emitente.EnderecoUf}").Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(7).ClampLines(1);
                        emitenteColumn.Item().Text($"Fone: {Formatter.FormatTelefone(_viewModel.Emitente.Telefone)}").Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(5).ClampLines(1);
                        emitenteColumn.Item().Text($"CEP: {Formatter.FormatCep(_viewModel.Emitente.EnderecoCep)}").Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(5).ClampLines(1);
                        emitenteColumn.Item().Text($"CNPJ: {Formatter.FormatTelefone(_viewModel.Emitente.CnpjCpf)}").Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(5).ClampLines(1);
                        emitenteColumn.Item().Text($"I.E: {_viewModel.Emitente.Ie}").Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(5).ClampLines(1);
                    });
                });
            });

            row.RelativeItem(2).Border(_estilo.EspessuraBorda).BorderColor(_estilo.CorBorda).Column(column =>
            {
                column.Spacing(2);
                column.Item().Background(_estilo.CorFundoCabecalho).AlignCenter().Text("DANFE").Style(_estilo.ConteudoNegritoStyle(TextStyle.Default)).FontSize(8);
                column.Item().AlignCenter().Text("DOCUMENTO AUXILIAR DA NOTA FISCAL ELETRÔNICA").Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(6).ClampLines(1);
                column.Item().AlignCenter().Text($"0 - ENTRADA / 1 - SAÍDA [{_viewModel.TipoEmissao}]").Style(_estilo.ConteudoStyle(TextStyle.Default)).FontSize(5).ClampLines(1);
                column.Item().AlignCenter().Text($"Nº: {_viewModel.Numero}").Style(_estilo.ConteudoNegritoStyle(TextStyle.Default)).FontSize(5).ClampLines(1);
                column.Item().AlignCenter().Text($"Sérieº: {_viewModel.Serie}").Style(_estilo.ConteudoNegritoStyle(TextStyle.Default)).FontSize(5).ClampLines(1);
                column.Item().AlignCenter().Text(x =>
                {
                    x.DefaultTextStyle(TextStyle.Default.FontSize(5));
                    x.Span("Folha");
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });

            row.RelativeItem(4).Border(_estilo.EspessuraBorda).BorderColor(_estilo.CorBorda).Column(column =>
            {
                column.Item().PaddingTop(10).BorderAlignmentMiddle().Element(c => new Barcode128CElement(_viewModel.ChaveAcesso).Compose(c));
            });
        });
    }
}
