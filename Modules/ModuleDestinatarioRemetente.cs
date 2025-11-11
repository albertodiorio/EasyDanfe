using EasyDanfe.Constants;
using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;
using EasyDanfe.Utils;

namespace EasyDanfe.Modules;

internal class ModuleDestinatarioRemetente : ModuleBase
{
    public ModuleDestinatarioRemetente(DanfeModel viewModel, EstiloElement estilo) : base(viewModel, estilo)
    {
        var destinatario = viewModel.Destinatario;

        AdicionarLinhaCampos()
        .ComCampo(Strings.RazaoSocial, destinatario.RazaoSocial)
        .ComCampo(Strings.CnpjCpf, Formatter.FormatarCpfCnpj(destinatario.CnpjCpf), AlinhamentoHorizontal.Centro)
        .ComCampo("Data de Emissão", viewModel.DataHoraEmissao.Formatar(), AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 45F * Proporcao, 30F * Proporcao);

        AdicionarLinhaCampos()
        .ComCampo(Strings.Endereco, destinatario.EnderecoLinha1)
        .ComCampo(Strings.BairroDistrito, destinatario.EnderecoBairro)
        .ComCampo("CEP", Formatter.FormatarCEP(destinatario.EnderecoCep), AlinhamentoHorizontal.Centro)
        .ComCampo("Data Entrada / Saída", ViewModel.DataSaidaEntrada.Formatar(), AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 45F * Proporcao, 25F * Proporcao, 30F * Proporcao);

        AdicionarLinhaCampos()
        .ComCampo(Strings.Municipio, destinatario.Municipio)
        .ComCampo(Strings.FoneFax, Formatter.FormatarTelefone(destinatario.Telefone), AlinhamentoHorizontal.Centro)
        .ComCampo(Strings.UF, destinatario.EnderecoUf, AlinhamentoHorizontal.Centro)
        .ComCampo(Strings.InscricaoEstadual, destinatario.Ie, AlinhamentoHorizontal.Centro)
        .ComCampo("Hora Entrada / Saída", ViewModel.HoraSaidaEntrada.Formatar(), AlinhamentoHorizontal.Centro)
        .ComLarguras(0, 35F * Proporcao, 7F * Proporcao, 40F * Proporcao, 30F * Proporcao);
    }

    public override string Cabecalho => "Destinatário / Remetente";
    public override PosicaoBloco Posicao => PosicaoBloco.Topo;
}
