using EasyDanfe.Enums;
using EasyDanfe.Schemes;
using EasyDanfe.Utils;
using NFe.Danfe.PdfClown.Esquemas;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EasyDanfe.Models;

public static class DanfeModelCreator
{
    public static readonly IEnumerable<FormaEmissao> FormasEmissaoSuportadas =
    [
        FormaEmissao.Normal,
        FormaEmissao.ContingenciaSVCAN,
        FormaEmissao.ContingenciaSVCRS
    ];

    private static EmpresaModel CreateEmpresaFromEmitente(Emit emit)
    {
        var empresaModel = new EmpresaModel()
        {
            RazaoSocial = emit.XNome,
            NomeFantasia = emit.XFant,
            CnpjCpf = emit.CNPJ,
            Ie = emit.IE,
            IeSt = emit.IEST,
            EnderecoLogadrouro = emit.EnderEmit.XLgr,
            EnderecoNumero = emit.EnderEmit.Nro,
            EnderecoBairro = emit.EnderEmit.XBairro,
            Municipio = emit.EnderEmit.XMun,
            EnderecoUf = emit.EnderEmit.UF,
            EnderecoCep = emit.EnderEmit.CEP,
            EnderecoComplemento = string.Empty, // A NF-e nova não tem xCpl em EnderEmit
            Telefone = string.Empty,             // Não há campo fone na estrutura nova
            IM = emit.IM,
            CRT = emit.CRT
        };

        return empresaModel;
    }

    private static EmpresaModel CreateEmpresaFromDestinatario(Dest dest)
    {
        var empresaModel = new EmpresaModel()
        {
            RazaoSocial = dest.XNome,
            Ie = dest.IE,
            CnpjCpf = dest.CNPJ,
            EnderecoLogadrouro = dest.EnderDest.XLgr,
            EnderecoNumero = dest.EnderDest.Nro,
            EnderecoBairro = dest.EnderDest.XBairro,
            Municipio = dest.EnderDest.XMun,
            EnderecoUf = dest.EnderDest.UF,
            EnderecoCep = dest.EnderDest.CEP,
            Telefone = string.Empty
        };

        return empresaModel;
    }

    public static DanfeModel CreateFromXmlString(string xml)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(NfeProc));

            using var reader = new StringReader(xml);
            var nfeProc = (NfeProc)serializer.Deserialize(reader)!;

            return CreateFromXml(nfeProc);
        }
        catch (InvalidOperationException e)
        {
            throw new Exception("Não foi possível interpretar o texto XML.", e);
        }
    }

    public static DanfeModel CriarDeArquivoXml(string caminho)
    {
        using var sr = new StreamReader(caminho, true);
        return CriarDeArquivoXmlInternal(sr);
    }

    private static DanfeModel CriarDeArquivoXmlInternal(TextReader reader)
    {
        NfeProc nfeProc;
        var serializer = new XmlSerializer(typeof(NfeProc));

        try
        {
            nfeProc = (NfeProc)serializer.Deserialize(reader);
            return CreateFromXml(nfeProc!);
        }
        catch (InvalidOperationException e)
        {
            if (e.InnerException is XmlException)
            {
                XmlException ex = (XmlException)e.InnerException;
                throw new Exception(String.Format("Não foi possível interpretar o Xml. Linha {0} Posição {1}.", ex.LineNumber, ex.LinePosition));
            }

            throw new XmlException("O Xml não parece ser uma NF-e processada.", e);
        }
    }
    public static DanfeModel CreateFromXml(NfeProc nfeProc)
    {
        var danfeModel = new DanfeModel();

        var nfe = nfeProc.NFe;
        var infNfe = nfe.InfNFe;
        var ide = infNfe.Ide;

        danfeModel.TipoEmissao = ConverterTipoEmissao(ide);
        danfeModel.NaturezaOperacao = ide.NatOp;
        danfeModel.NfNumero = ide.NNF;
        danfeModel.NfSerie = ide.Serie;
        danfeModel.ChaveAcesso = TratarChaveAcesso(infNfe);
        danfeModel.TipoAmbiente = ide.TpAmb;
        danfeModel.TipoNF = ide.TpNF;
        danfeModel.Orientacao = ConverterOrientacao(ide);
        danfeModel.Emitente = CreateEmpresaFromEmitente(infNfe.Emit);
        danfeModel.Destinatario = CreateEmpresaFromDestinatario(infNfe.Dest);
        danfeModel.ProtocoloAutorizacao = TratarProtocoloAutorizacao(nfeProc);
        danfeModel.DataHoraEmissao = ide.DhEmi;
        danfeModel.CalculoImposto = CreateCalculoImposto(infNfe.Total);

        foreach (var det in infNfe.Det)
        {
            var produtoModel = CreateProduto(det);
            CreateImposto(det, produtoModel);

            danfeModel.Produtos.Add(produtoModel);
        }

        danfeModel.Transportadora = CreateTransportadora(infNfe.Transp);

        danfeModel.InformacoesComplementares = infNfe.InfAdic.InfCpl;
        danfeModel.InformacoesAdicionaisFisco = infNfe.InfAdic.InfAdFisco;

        return danfeModel;
    }

    private static void CreateImposto(Det det, ProdutoModel produtoModel)
    {
        if (det.Imposto?.ICMS?.ICMS10 is { } icms)
        {
            produtoModel.BaseIcms = icms.VBC;
            produtoModel.ValorIcms = icms.VICMS;
            produtoModel.AliquotaIcms = icms.PICMS;
            produtoModel.OCst = icms.CST;
            produtoModel.PercentualIcmsSt = icms.PICMSST;
            produtoModel.ValorBaseCalculoSt = icms.VBCST;
            produtoModel.ValorIcmsST = icms.VICMSST;
            produtoModel.ValorVastIva = icms.PMVAST;
            produtoModel.ValorIpi = det.Imposto.IPI?.IPITrib?.VIPI;
            produtoModel.AliquotaIpi = det.Imposto.IPI?.IPITrib?.PIpi;

        }
    }

    private static string TratarProtocoloAutorizacao(NfeProc nfeProc)
    {
        return string.Format(Formatter.Cultura, "{0} - {1}", nfeProc.ProtNFe.InfProt.NProt, nfeProc.ProtNFe.InfProt.DhRecbto.DateTimeOffsetValue.DateTime);
    }
    private static Orientacao ConverterOrientacao(Ide ide)
    {
        return ide.TpImp == 1 ? Orientacao.Retrato : Orientacao.Paisagem;
    }

    private static string TratarChaveAcesso(Schemes.InfNFe infNfe)
    {
        return infNfe.Id.Replace("NFe", string.Empty);
    }

    private static FormaEmissao ConverterTipoEmissao(Ide ide)
    {
        return (FormaEmissao)ide.TpEmis;
    }

    private static string MontarDescricaoComImpostos(Det det)
    {
        var descricao = new StringBuilder();
        descricao.AppendLine(det.Prod.XProd);
        descricao.Append($"IVA/MA: {det.Imposto.ICMS.ICMS10.PMVAST.Formatar()}% ");
        descricao.Append($"{nameof(det.Imposto.ICMS.ICMS10.PICMSST)}: {det.Imposto.ICMS.ICMS10.PICMSST.Formatar()}% ");
        descricao.Append($"{nameof(det.Imposto.ICMS.ICMS10.VBCST)}: {det.Imposto.ICMS.ICMS10.VBCST.Formatar()}% ");
        descricao.Append($"{nameof(det.Imposto.ICMS.ICMS10.VICMSST)}: {det.Imposto.ICMS.ICMS10.VICMSST.Formatar()}% ");

        return descricao.ToString();
    }

    private static CalculoImpostoModel CreateCalculoImposto(Schemes.Total total)
    {
        return new CalculoImpostoModel()
        {
            BaseCalculoIcms = total.ICMSTot.VBC,
            ValorIcms = total.ICMSTot.VICMS,
            ValorTotalProdutos = total.ICMSTot.VProd,
            ValorFrete = total.ICMSTot.VFrete,
            ValorSeguro = total.ICMSTot.VSeg,
            ValorDesconto = total.ICMSTot.VDesc,
            OutrasDespesas = total.ICMSTot.VOutro,
            ValorIpi = total.ICMSTot.VIPI,
            ValorTotalNota = total.ICMSTot.VNF,
            ValorPis = total.ICMSTot.VPIS,
            ValorCofins = total.ICMSTot.VCOFINS,
            ValorIcmsSt = total.ICMSTot.VST,
            BaseCalculoIcmsSt = total.ICMSTot.VBCST,
            VIcmsUfDest = total.ICMSTot.VICM
            VIcmsUfRemet =

        };
    }

    private static ProdutoModel CreateProduto(Det det)
    {
        return new ProdutoModel()
        {
            Codigo = det.Prod.CProd,
            Descricao = MontarDescricaoComImpostos(det),
            Ncm = det.Prod.NCM,
            Cfop = det.Prod.CFOP,
            Unidade = det.Prod.UCom,
            Quantidade = det.Prod.QCom,
            ValorUnitario = det.Prod.VUnCom,
            ValorTotal = det.Prod.VProd
        };
    }

    private static TransportadoraModel CreateTransportadora(Transp transp)
    {
        return new TransportadoraModel()
        {
            CnpjCpf = transp.Transporta.CNPJ,
            RazaoSocial = transp.Transporta.XNome,
            ModalidadeFrete = transp.ModFrete,
            EnderecoUf = transp.Transporta.UF,
            Municipio = transp.Transporta.XMun,
            EnderecoLogadrouro = transp.Transporta.XEnder,
            Ie = transp.Transporta.IE,
            QuantidadeVolumes = transp.Vol?.QVol,
            Especie = transp.Vol!.Esp,
            PesoBruto = transp.Vol?.PesoB,
            PesoLiquido = transp.Vol?.PesoL,
        };
    }
}