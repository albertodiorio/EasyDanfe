using EasyDanfe.Constants;
using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;

namespace EasyDanfe.Modules.ModuleLocalEntregaRetirada;

abstract class ModuleLocalEntregaRetirada : ModuleBase
{
    public LocalEntregaRetiradaModel Model { get; private set; }

    protected ModuleLocalEntregaRetirada(DanfeModel viewModel, EstiloElement estilo, LocalEntregaRetiradaModel localModel) : base(viewModel, estilo)
    {
        Model = localModel ?? throw new ArgumentNullException(nameof(localModel));

        AdicionarLinhaCampos()
        .ComCampo(Strings.NomeRazaoSocial, Model.NomeRazaoSocial)
        .ComCampo(Strings.CnpjCpf, Utils.Formatter.FormatarCpfCnpj(Model.CnpjCpf), AlinhamentoHorizontal.Centro)
        .ComCampo(Strings.InscricaoEstadual, Model.InscricaoEstadual, AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 45F * Proporcao, 30F * Proporcao);

        AdicionarLinhaCampos()
        .ComCampo(Strings.Endereco, Model.Endereco)
        .ComCampo(Strings.BairroDistrito, Model.Bairro)
        .ComCampo(Strings.Cep, Utils.Formatter.FormatarCEP(Model.Cep), AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 45F * Proporcao, 30F * Proporcao);

        AdicionarLinhaCampos()
        .ComCampo(Strings.Municipio, Model.Municipio)
        .ComCampo(Strings.UF, Model.Uf, AlinhamentoHorizontal.Centro)
        .ComCampo(Strings.FoneFax, Utils.Formatter.FormatarTelefone(Model.Telefone), AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 7F * Proporcao, 30F * Proporcao);
    }

    public override PosicaoBloco Posicao => PosicaoBloco.Topo;

}
