using EasyDanfe.Enums;
using EasyDanfe.Graphics;

namespace EasyDanfe.Elements;

/// <summary>
/// Campo multilinha.
/// </summary>
internal class CampoMultilinhaElement : CampoElement
{
    private readonly TextBlockElement _tbConteudo;

    public CampoMultilinhaElement(string cabecalho, string conteudo, EstiloElement estilo, AlinhamentoHorizontal alinhamentoHorizontalConteudo = AlinhamentoHorizontal.Esquerda)
          : base(cabecalho, conteudo, estilo, alinhamentoHorizontalConteudo)
    {
        _tbConteudo = new TextBlockElement(conteudo, estilo.FonteCampoConteudo);
        IsConteudoNegrito = false;
    }

    protected override void DesenharConteudo(Gfx gfx)
    {
        if (!string.IsNullOrWhiteSpace(Conteudo))
        {
            _tbConteudo.SetPosition(RetanguloDesenhvael.X, RetanguloDesenhvael.Y + Estilo.FonteCampoCabecalho.AlturaLinha + Estilo.PaddingInferior);
            _tbConteudo.Draw(gfx);
        }
    }

    public override float Height
    {
        get
        {
            return Math.Max(_tbConteudo.Height + Estilo.FonteCampoCabecalho.AlturaLinha + Estilo.PaddingSuperior + 2 * Estilo.PaddingInferior, base.Height);
        }
        set
        {
            base.Height = value;
        }
    }

    public override float Width { get => base.Width; set { base.Width = value; _tbConteudo.Width = value - 2 * Estilo.PaddingHorizontal; } }
}
