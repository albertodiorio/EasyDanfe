using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Graphics;
using EasyDanfe.Models;

namespace EasyDanfe.Modules;

internal class ModuleDadosAdicionais : ModuleBase
{
    public const float AlturaMinima = 25;
    private readonly CampoMultilinhaElement _cInfComplementares;
    private readonly FlexibleLineElement _Linha;
    private readonly CampoElement _cReservadoFisco;
    public const float InfComplementaresLarguraPorcentagem = 75;

    public ModuleDadosAdicionais(DanfeViewModel viewModel, EstiloElement estilo) : base(viewModel, estilo)
    {
        _cInfComplementares = new CampoMultilinhaElement("Informações Complementares", ViewModel.TextoAdicional(), estilo);
        _cReservadoFisco = new CampoMultilinhaElement("Reservado ao fisco", ViewModel.TextoAdicionalFisco(), estilo);

        _Linha = new FlexibleLineElement() { Height = _cInfComplementares.Height }
        .ComElemento(_cInfComplementares)
        .ComElemento(_cReservadoFisco)
        .ComLarguras(InfComplementaresLarguraPorcentagem, 0);

        MainVerticalStack.Add(_Linha);
    }

    public override float Width
    {
        get => base.Width;
        set
        {
            base.Width = value;
            // Força o ajuste da altura do InfComplementares
            if (_cInfComplementares != null && _Linha != null)
            {
                _Linha.Width = value;
                _Linha.Posicionar();
                _cInfComplementares.Height = AlturaMinima;
                _Linha.Height = _cInfComplementares.Height;
            }
        }
    }

    public override void Draw(Gfx gfx)
    {
        base.Draw(gfx);
    }

    public override PosicaoBloco Posicao => PosicaoBloco.Base;
    public override string Cabecalho => "Dados adicionais";
}
