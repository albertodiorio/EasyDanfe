namespace EasyDanfe.Models;

public class DuplicataModel
{
    /// <summary>
    /// <para>Número da Duplicata</para>
    /// <para>Tag nDup</para>
    /// </summary>
    public string Numero { get; set; } = string.Empty;

    /// <summary>
    /// <para>Data de vencimento</para>
    /// <para>Tag dVenc</para>
    /// </summary>
    public DateTime? Vecimento { get; set; }

    /// <summary>
    /// <para>Valor da duplicata</para>
    /// <para>Tag vDup</para>
    /// </summary>
    public decimal? Valor { get; set; }
}
