namespace EasyDanfe.Utils;

public static class Utils
{
    public static string GetModalidadeFrete(string? value)
    {
        return value switch
        {
            "0" => "0 - Emitente",
            "1" => "1 - Destinatário",
            "2" => "2 - Terceiros",
            "3" => "3 - Próprio (Remetente)",
            "4" => "4 - Próprio (Destinatário)",
            "9" => "9 - Sem Frete",
            _ => string.Empty,
        };
    }

    public static string GetTipoEmissao(string? value)
    {
        return value switch
        {
            "1" => "1 - Normal",
            "2" => "2 - Contingência FS",
            "3" => "3 - Contingência SCAN",
            "4" => "4 - Contingência DPEC",
            "5" => "5 - Contingência FSDA",
            "6" => "6 - Contingência SVC-AN",
            "7" => "7 - Contingência SVC-RS",
            "9" => "9 - Contingência Off-line NFC-e",
            _ => string.Empty,
        };
    }

    public static string GetTipoAmbiente(string? value)
    {
        return value switch
        {
            "1" => "1 - Produção",
            "2" => "2 - Homologação",
            _ => string.Empty,
        };
    }

    public static string GetFinalidadeEmissao(string? value)
    {
        return value switch
        {
            "1" => "1 - Normal",
            "2" => "2 - Complementar",
            "3" => "3 - Ajuste",
            "4" => "4 - Devolução de Mercadoria",
            _ => string.Empty,
        };
    }

    public static string GetTipoOperacao(string? value)
    {
        return value switch
        {
            "0" => "0 - Entrada",
            "1" => "1 - Saída",
            _ => string.Empty,
        };
    }

    public static string GetConsumidorFinal(string? value)
    {
        return value switch
        {
            "0" => "0 - Normal",
            "1" => "1 - Consumidor Final",
            _ => string.Empty,
        };
    }

    public static string GetIndicadorPresenca(string? value)
    {
        return value switch
        {
            "0" => "0 - Não se aplica",
            "1" => "1 - Operação presencial",
            "2" => "2 - Operação não presencial, pela Internet",
            "3" => "3 - Operação não presencial, Teleatendimento",
            "4" => "4 - NFC-e em operação com entrega a domicílio",
            "5" => "5 - Operação presencial, fora do estabelecimento",
            "9" => "9 - Operação não presencial, outros",
            _ => string.Empty,
        };
    }
}
