namespace EasyDanfe.Models;

public class ProdutoModel
{
    public string Codigo { get; set; }
    public string InformacoesAdicionais { get; set; }
    public string Descricao { get; set; }
    public string Ncm { get; set; }
    public string OCst { get; set; }
    public int Cfop { get; set; }
    public string Unidade { get; set; }
    public decimal Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal BaseIcms { get; set; }
    public decimal ValorIcms { get; set; }
    public decimal AliquotaIcms { get; set; }
    public decimal? ValorIpi { get; set; }
    public decimal? AliquotaIpi { get; set; }
    public decimal? ValorAproximadoTributos { get; set; }
    public decimal PercentualIcmsSt { get; set; }
    public decimal ValorBaseCalculoSt { get; set; }
    public decimal ValorVastIva { get; set; }
    public decimal ValorIcmsST { get; set; }

    public ProdutoModel()
    {

    }

    public string DescricaoCompleta
    {
        get
        {
            string descriCaoCompleta = Descricao;

            if (!string.IsNullOrWhiteSpace(InformacoesAdicionais))
            {
                descriCaoCompleta += "\r\n" + InformacoesAdicionais;
            }

            return descriCaoCompleta;
        }
    }
}
