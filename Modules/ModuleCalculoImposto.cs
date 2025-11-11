using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;

namespace EasyDanfe.Modules;

class ModuleCalculoImposto : ModuleBase
{
    public ModuleCalculoImposto(DanfeModel viewModel, EstiloElement estilo) : base(viewModel, estilo)
    {
        var m = ViewModel.CalculoImposto;

        var l = AdicionarLinhaCampos()
        .ComCampoNumerico("BASE DE CÁLC. DO ICMS", m.BaseCalculoIcms)
        .ComCampoNumerico("VALOR DO ICMS", m.ValorIcms)
        .ComCampoNumerico("BASE DE CÁLC. ICMS S.T.", m.BaseCalculoIcmsSt)
        .ComCampoNumerico("VALOR DO ICMS SUBST.", m.ValorIcmsSt)
        .ComCampoNumerico("V. IMP. IMPORTAÇÃO", m.ValorII);

        if (ViewModel.ExibirIcmsInterestadual)
        {
            l.ComCampoNumerico("V. ICMS UF REMET.", m.VIcmsUfRemet)
             .ComCampoNumerico("VALOR DO FCP", m.VFcpUfDest);
        }

        if (ViewModel.ExibirPisConfins)
        {
            l.ComCampoNumerico("VALOR DO PIS", m.ValorPis);
        }

        l.ComCampoNumerico("V. TOTAL PRODUTOS", m.ValorTotalProdutos)
       .ComLargurasIguais();

        l = AdicionarLinhaCampos()
        .ComCampoNumerico("Valor do Frete", m.ValorFrete)
        .ComCampoNumerico("Valor do Seguro", m.ValorSeguro)
        .ComCampoNumerico("Desconto", m.ValorDesconto)
        .ComCampoNumerico("Outras Despesas", m.OutrasDespesas)
        .ComCampoNumerico("Valor Ipi", m.ValorIpi);

        if (ViewModel.ExibirIcmsInterestadual)
        {
            l.ComCampoNumerico("V. ICMS UF DEST.", m.VIcmsUfDest)
            .ComCampoNumerico("V. TOT. TRIB.", m.ValorAproximadoTributos);
        }

        if (ViewModel.ExibirPisConfins)
        {
            l.ComCampoNumerico("VALOR DO COFINS", m.ValorCofins);
        }

        l.ComCampoNumerico("Valor Total da Nota", m.ValorTotalNota)
        .ComLargurasIguais();
    }

    public override PosicaoBloco Posicao => PosicaoBloco.Topo;
    public override string Cabecalho => "Cálculo do Imposto";
}