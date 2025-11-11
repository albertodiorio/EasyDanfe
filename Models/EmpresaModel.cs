using System.Text;

namespace EasyDanfe.Models;

public class EmpresaModel
{
    public string RazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string EnderecoLogadrouro { get; set; } = string.Empty;
    public string EnderecoComplemento { get; set; } = string.Empty;
    public string EnderecoNumero { get; set; } = string.Empty;
    public string EnderecoCep { get; set; } = string.Empty;
    public string EnderecoBairro { get; set; } = string.Empty;
    public string EnderecoUf { get; set; } = string.Empty;
    public string Municipio { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CnpjCpf { get; set; } = string.Empty;
    public string Ie { get; set; } = string.Empty;
    public string IeSt { get; set; } = string.Empty;
    public string IM { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CRT { get; set; } = string.Empty;

    public string EnderecoLinha1
    {
        get
        {
            var sb = new StringBuilder();
            sb.Append(EnderecoLogadrouro);
            if (!string.IsNullOrWhiteSpace(EnderecoNumero)) sb.Append(", ").Append(EnderecoNumero);
            if (!string.IsNullOrWhiteSpace(EnderecoComplemento)) sb.Append(" - ").Append(EnderecoComplemento);
            return sb.ToString();
        }
    }

    public string EnderecoLinha2 => $"{EnderecoBairro} - CEP: {Utils.Formatter.FormatarCEP(EnderecoCep)}";

    public string EnderecoLinha3
    {
        get
        {
            var sb = new StringBuilder()
                .Append(Municipio).Append(" - ").Append(EnderecoUf);

            if (!string.IsNullOrWhiteSpace(Telefone))
                sb.Append(" Fone: ").Append(Utils.Formatter.FormatarTelefone(Telefone));

            return sb.ToString();
        }
    }
}
