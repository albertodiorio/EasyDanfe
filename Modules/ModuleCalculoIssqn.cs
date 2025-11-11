using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;

namespace EasyDanfe.Modules;

internal class ModuleCalculoIssqn : ModuleBase
{
    public ModuleCalculoIssqn(DanfeModel viewModel, EstiloElement estilo) : base(viewModel, estilo)
    {
        var m = viewModel.CalculoIssqn;

        AdicionarLinhaCampos()
            .ComCampo("INSCRIÇÃO MUNICIPAL", m.InscricaoMunicipal, AlinhamentoHorizontal.Centro)
            .ComCampoNumerico("VALOR TOTAL DOS SERVIÇOS", m.ValorTotalServicos)
            .ComCampoNumerico("BASE DE CÁLCULO DO ISSQN", m.BaseIssqn)
            .ComCampoNumerico("VALOR TOTAL DO ISSQN", m.ValorIssqn)
            .ComLargurasIguais();
    }

    public override PosicaoBloco Posicao => PosicaoBloco.Base;
    public override string Cabecalho => "CÁLCULO DO ISSQN";
}