using EasyDanfe.Enums;

namespace EasyDanfe.Models;

public class DanfeModel
{
    public EmpresaModel Emitente { get; set; } = new();
    public EmpresaModel Destinatario { get; set; } = new();
    public LocalEntregaRetiradaModel? LocalRetirada { get; set; }
    public LocalEntregaRetiradaModel? LocalEntrega { get; set; }
    public TransportadoraModel Transportadora { get; set; } = new();
    public CalculoImpostoModel CalculoImposto { get; set; } = new();
    public CalculoIssqnModel CalculoIssqn { get; set; } = new();
    public List<ProdutoModel> Produtos { get; set; } = [];
    public List<DuplicataModel> Duplicatas { get; set; } = [];

    public string ChaveAcesso { get; set; } = string.Empty;
    public string NaturezaOperacao { get; set; } = string.Empty;
    public string ProtocoloAutorizacao { get; set; } = string.Empty;
    public string InformacoesComplementares { get; set; } = string.Empty;
    public string InformacoesFisco { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Serie { get; set; } = string.Empty;
    public string TipoNf { get; set; } = string.Empty;
    public string TipoOperacao { get; set; } = string.Empty;
    public string TipoEmissao { get; set; } = string.Empty;
    public string TipoAmbiente { get; set; } = string.Empty;
    public string FinalidadeEmissao { get; set; } = string.Empty;
    public string ConsumidorFinal { get; set; } = string.Empty;
    public string IndicadorPresenca { get; set; } = string.Empty;

    public DateTimeOffset DataEmissao { get; set; }
    public DateTimeOffset DataSaidaEntrada { get; set; }

    public Orientacao Orientacao { get; set; } = Orientacao.Retrato;
    public bool ExibirBlocoLocalRetirada { get; set; } = true;
    public bool ExibirBlocoLocalEntrega { get; set; } = true;
    public bool ExibirCanhoto { get; set; } = true;
    public byte[]? Logo { get; set; }
}
