using System.Globalization;

namespace EasyDanfe.Utils;

public static class Formatter
{
    private static readonly CultureInfo Culture = new("pt-BR");

    public static string Format(decimal? value, int casasDecimais = 2)
    {
        if (value == null)
            return string.Empty;

        return value.Value.ToString($"N{casasDecimais}", Culture);
    }

    public static string Format(DateTimeOffset? value)
    {
        if (value == null)
            return string.Empty;

        return value.Value.ToString("dd/MM/yyyy", Culture);
    }

    public static string Format(string? value)
    {
        return value ?? string.Empty;
    }

    public static string FormatCnpjCpf(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var cleanValue = new string(value.Where(char.IsDigit).ToArray());

        if (cleanValue.Length == 14)
        {
            return Convert.ToUInt64(cleanValue).ToString(@"00\.000\.000\/0000\-00");
        }
        else if (cleanValue.Length == 11)
        {
            return Convert.ToUInt64(cleanValue).ToString(@"000\.000\.000\-00");
        }

        return value;
    }

    public static string FormatCep(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var cleanValue = new string(value.Where(char.IsDigit).ToArray());

        if (cleanValue.Length == 8)
        {
            return Convert.ToUInt64(cleanValue).ToString(@"00000\-000");
        }

        return value;
    }

    public static string FormatTelefone(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var cleanValue = new string(value.Where(char.IsDigit).ToArray());

        if (cleanValue.Length == 10)
        {
            return Convert.ToUInt64(cleanValue).ToString(@"(00) 0000-0000");
        }
        else if (cleanValue.Length == 11)
        {
            return Convert.ToUInt64(cleanValue).ToString(@"(00) 00000-0000");
        }

        return value;
    }
}
