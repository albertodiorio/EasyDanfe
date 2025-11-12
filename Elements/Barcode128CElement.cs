using BarcodeStandard;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace EasyDanfe.Elements;

public class Barcode128CElement : IComponent
{
    private readonly string _chaveAcesso;
    private readonly float _scale;

    public Barcode128CElement(string chaveAcesso, float scale = 1.0f)
    {
        _chaveAcesso = chaveAcesso;
        _scale = scale;
    }

    public void Compose(IContainer container)
    {
        var barcodePng = GenerateBarcodePng(_chaveAcesso, _scale);
        if (barcodePng is not null)
        {
            container.AlignCenter().Column(column =>
            {
                column.Item().Image(barcodePng);
                column.Item().Text(_chaveAcesso).AlignCenter().FontSize(4);
            });
        }
        else
        {
            container.AlignCenter().Text("Erro ao gerar código de barras").FontSize(6);
        }
    }

    private static byte[]? GenerateBarcodePng(string content, float scale)
    {
        try
        {
            var barcode = new Barcode();
            int symbols = content.Length / 2;
            int minModules = symbols * 11 + 35;
            int minBarWidth = 1;
            int width = (int)(Math.Max(220, minModules * minBarWidth) * scale);
            int height = (int)(24 * scale);

            using var skImage = barcode.Encode(BarcodeStandard.Type.Code128, content, SKColors.Black, SKColors.White, width, height);
            using var data = skImage.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }
        catch
        {
            return null;
        }
    }
}
