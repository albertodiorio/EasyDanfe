using EasyDanfe.Constants;
using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;

namespace EasyDanfe.Modules.ModuleLocalEntregaRetirada;

abstract class ModuleLocalEntregaRetirada : ModuleBase
{
    public LocalEntregaRetiradaViewModel Model { get; private set; }

    protected ModuleLocalEntregaRetirada(DanfeViewModel viewModel, EstiloElement estilo, LocalEntregaRetiradaViewModel localModel) : base(viewModel, estilo)
    {
        Model = localModel ?? throw new ArgumentNullException(nameof(localModel));

        AdicionarLinhaCampos()
        .ComCampo(Strings.NomeRazaoSocial, Model.NomeRazaoSocial)
        .ComCampo(Strings.CnpjCpf, Utils.Formatador.FormatarCpfCnpj(Model.CnpjCpf), AlinhamentoHorizontal.Centro)
        .ComCampo(Strings.InscricaoEstadual, Model.InscricaoEstadual, AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 45F * Proporcao, 30F * Proporcao);

        AdicionarLinhaCampos()
        .ComCampo(Strings.Endereco, Model.Endereco)
        .ComCampo(Strings.BairroDistrito, Model.Bairro)
        .ComCampo(Strings.Cep, Utils.Formatador.FormatarCEP(Model.Cep), AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 45F * Proporcao, 30F * Proporcao);

        AdicionarLinhaCampos()
        .ComCampo(Strings.Municipio, Model.Municipio)
        .ComCampo(Strings.UF, Model.Uf, AlinhamentoHorizontal.Centro)
        .ComCampo(Strings.FoneFax, Utils.Formatador.FormatarTelefone(Model.Telefone), AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 7F * Proporcao, 30F * Proporcao);
    }

    public override PosicaoBloco Posicao => PosicaoBloco.Topo;

}
