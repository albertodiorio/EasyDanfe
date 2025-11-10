using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Graphics;
using EasyDanfe.Models;

namespace EasyDanfe.Modules;

/// <summary>
/// Define um bloco básico do DANFE.
/// </summary>
internal abstract class ModuleBase : ElementBase
{
    /// <summary>
    /// Constante de proporção dos campos para o formato retrato A4, porcentagem dividida pela largura desenhável.
    /// </summary>
    public const float Proporcao = 100F / 200F;

    public DanfeViewModel ViewModel { get; private set; }

    public abstract PosicaoBloco Posicao { get; }

    /// <summary>
    /// Pilha principal.
    /// </summary>
    public VerticalStackElement MainVerticalStack { get; private set; }

    /// <summary>
    /// Quando verdadeiro, o bloco é mostrado apenas na primeira página, caso contário é mostrado em todas elas.
    /// </summary>
    public virtual bool VisivelSomentePrimeiraPagina => true;

    public virtual string Cabecalho => null;

    public ModuleBase(DanfeViewModel viewModel, EstiloElement estilo) : base(estilo)
    {
        MainVerticalStack = new VerticalStackElement();
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

        if (!string.IsNullOrWhiteSpace(Cabecalho))
        {
            MainVerticalStack.Add(new CabecalhoBlocoElement(estilo, Cabecalho));
        }
    }

    public LinhaCamposElement AdicionarLinhaCampos()
    {
        var l = new LinhaCamposElement(Estilo, Width);
        l.Width = Width;
        l.Height = Constants.Constants.CampoAltura;
        MainVerticalStack.Add(l);
        return l;
    }

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);
        MainVerticalStack.SetPosition(X, Y);
        MainVerticalStack.Width = Width;
        MainVerticalStack.Draw(gfx);
    }

    public override float Height { get => MainVerticalStack.Height; set => throw new NotSupportedException(); }
    public override bool PossuiContono => false;
}