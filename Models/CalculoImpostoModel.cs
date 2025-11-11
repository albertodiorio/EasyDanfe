namespace EasyDanfe.Models;

public class CalculoImpostoModel
{
    public decimal BaseCalculoIcms { get; set; }
    public decimal ValorIcms { get; set; }
    public decimal? VIcmsUfDest { get; set; }
    public decimal? VIcmsUfRemet { get; set; }
    public decimal? VFcpUfDest { get; set; }
    public decimal BaseCalculoIcmsSt { get; set; }
    public decimal ValorIcmsSt { get; set; }
    public decimal? ValorTotalProdutos { get; set; }
    public decimal ValorFrete { get; set; }
    public decimal ValorSeguro { get; set; }
    public decimal ValorDesconto { get; set; }
    public decimal OutrasDespesas { get; set; }
    public decimal ValorII { get; set; }
    public decimal ValorIpi { get; set; }
    public decimal ValorPis { get; set; }
    public decimal ValorCofins { get; set; }
    public decimal ValorTotalNota { get; set; }
    public decimal? ValorAproximadoTributos { get; set; }
}
