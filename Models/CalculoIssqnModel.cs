namespace EasyDanfe.Models;

public class CalculoIssqnModel
{
    public string InscricaoMunicipal { get; set; }

    /// <summary>
    /// <para>Valor Total dos Serviços sob não-incidência ou não tributados pelo ICMS</para>
    /// <para>Tag vServ</para>
    /// </summary> 
    public decimal? ValorTotalServicos { get; set; }

    /// <summary>
    /// <para>Base de Cálculo do ISS</para>
    /// <para>Tag vBC</para>
    /// </summary>
    public decimal? BaseIssqn { get; set; }

    /// <summary>
    /// <para>Valor Total do ISS</para>
    /// <para>Tag vISS</para>
    /// </summary>
    public decimal? ValorIssqn { get; set; }

    /// <summary>
    /// Mostrar ou não o Bloco.
    /// </summary>
    public bool Mostrar { get; set; }

    public CalculoIssqnModel()
    {
        Mostrar = false;
    }
}
