using System.Xml.Serialization;

namespace EasyDanfe.Schemes;

[XmlRoot(ElementName = "ide", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Ide
{

    [XmlElement(ElementName = "cUF", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CUF { get; set; } = string.Empty;

    [XmlElement(ElementName = "cNF", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CNF { get; set; } = string.Empty;

    [XmlElement(ElementName = "natOp", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string NatOp { get; set; } = string.Empty;

    [XmlElement(ElementName = "mod", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int Mod { get; set; }

    [XmlElement(ElementName = "serie", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string Serie { get; set; } = string.Empty;

    [XmlElement(ElementName = "nNF", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string NNF { get; set; } = string.Empty;

    [XmlElement(ElementName = "dhEmi", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public DateTime DhEmi { get; set; }

    [XmlElement(ElementName = "tpNF", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string TpNF { get; set; } = string.Empty;

    [XmlElement(ElementName = "idDest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int IdDest { get; set; }

    [XmlElement(ElementName = "cMunFG", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CMunFG { get; set; }

    [XmlElement(ElementName = "tpImp", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int TpImp { get; set; }

    [XmlElement(ElementName = "tpEmis", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string TpEmis { get; set; } = string.Empty;

    [XmlElement(ElementName = "cDV", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CDV { get; set; }

    [XmlElement(ElementName = "tpAmb", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string TpAmb { get; set; } = string.Empty;

    [XmlElement(ElementName = "finNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int FinNFe { get; set; }

    [XmlElement(ElementName = "indFinal", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int IndFinal { get; set; }

    [XmlElement(ElementName = "indPres", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int IndPres { get; set; }

    [XmlElement(ElementName = "procEmi", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int ProcEmi { get; set; }

    [XmlElement(ElementName = "verProc", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string VerProc { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "enderEmit", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class EnderEmit
{

    [XmlElement(ElementName = "xLgr", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XLgr { get; set; } = string.Empty;

    [XmlElement(ElementName = "nro", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string Nro { get; set; } = string.Empty;

    [XmlElement(ElementName = "xBairro", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XBairro { get; set; } = string.Empty;

    [XmlElement(ElementName = "cMun", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CMun { get; set; }

    [XmlElement(ElementName = "xMun", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XMun { get; set; } = string.Empty;

    [XmlElement(ElementName = "UF", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string UF { get; set; } = string.Empty;

    [XmlElement(ElementName = "CEP", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CEP { get; set; } = string.Empty;

    [XmlElement(ElementName = "cPais", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CPais { get; set; }

    [XmlElement(ElementName = "xPais", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XPais { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "emit", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Emit
{

    [XmlElement(ElementName = "CNPJ", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CNPJ { get; set; } = string.Empty;

    [XmlElement(ElementName = "xNome", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XNome { get; set; } = string.Empty;

    [XmlElement(ElementName = "xFant", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XFant { get; set; } = string.Empty;

    [XmlElement(ElementName = "enderEmit", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public EnderEmit EnderEmit { get; set; } = new();

    [XmlElement(ElementName = "IE", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string IE { get; set; } = string.Empty;

    [XmlElement(ElementName = "IEST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string IEST { get; set; } = string.Empty;

    [XmlElement(ElementName = "IM", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string IM { get; set; } = string.Empty;

    [XmlElement(ElementName = "CRT", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CRT { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "enderDest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class EnderDest
{

    [XmlElement(ElementName = "xLgr", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XLgr { get; set; } = string.Empty;

    [XmlElement(ElementName = "nro", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string Nro { get; set; } = string.Empty;

    [XmlElement(ElementName = "xBairro", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XBairro { get; set; } = string.Empty;

    [XmlElement(ElementName = "cMun", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CMun { get; set; }

    [XmlElement(ElementName = "xMun", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XMun { get; set; } = string.Empty;

    [XmlElement(ElementName = "UF", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string UF { get; set; } = string.Empty;

    [XmlElement(ElementName = "CEP", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CEP { get; set; } = string.Empty;

    [XmlElement(ElementName = "cPais", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CPais { get; set; }

    [XmlElement(ElementName = "xPais", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XPais { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "dest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Dest
{

    [XmlElement(ElementName = "CNPJ", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CNPJ { get; set; } = string.Empty;

    [XmlElement(ElementName = "xNome", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XNome { get; set; } = string.Empty;

    [XmlElement(ElementName = "enderDest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public EnderDest EnderDest { get; set; } = new();

    [XmlElement(ElementName = "indIEDest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int IndIEDest { get; set; }

    [XmlElement(ElementName = "IE", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string IE { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "autXML", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class AutXML
{

    [XmlElement(ElementName = "CNPJ", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CNPJ { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "prod", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Prod
{

    [XmlElement(ElementName = "cProd", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CProd { get; set; } = string.Empty;

    [XmlElement(ElementName = "cEAN", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CEAN { get; set; } = string.Empty;

    [XmlElement(ElementName = "xProd", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XProd { get; set; } = string.Empty;

    [XmlElement(ElementName = "NCM", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string NCM { get; set; } = string.Empty;

    [XmlElement(ElementName = "CEST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CEST { get; set; }

    [XmlElement(ElementName = "CFOP", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CFOP { get; set; } = string.Empty;

    [XmlElement(ElementName = "uCom", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string UCom { get; set; } = string.Empty;

    [XmlElement(ElementName = "qCom", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal QCom { get; set; }

    [XmlElement(ElementName = "vUnCom", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VUnCom { get; set; }

    [XmlElement(ElementName = "vProd", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VProd { get; set; }

    [XmlElement(ElementName = "cEANTrib", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CEANTrib { get; set; } = string.Empty;

    [XmlElement(ElementName = "uTrib", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string UTrib { get; set; } = string.Empty;

    [XmlElement(ElementName = "qTrib", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal QTrib { get; set; }

    [XmlElement(ElementName = "vUnTrib", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VUnTrib;

    [XmlElement(ElementName = "indTot", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int IndTot { get; set; }
}

[XmlRoot(ElementName = "ICMS10", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ICMS10
{

    [XmlElement(ElementName = "orig", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int Orig { get; set; }

    [XmlElement(ElementName = "CST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CST { get; set; } = string.Empty;

    [XmlElement(ElementName = "modBC", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int ModBC { get; set; }

    [XmlElement(ElementName = "vBC", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VBC { get; set; }

    [XmlElement(ElementName = "pICMS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal PICMS { get; set; }

    [XmlElement(ElementName = "vICMS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VICMS { get; set; }

    [XmlElement(ElementName = "modBCST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int ModBCST { get; set; }

    [XmlElement(ElementName = "pMVAST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal PMVAST { get; set; }

    [XmlElement(ElementName = "vBCST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VBCST { get; set; }

    [XmlElement(ElementName = "pICMSST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal PICMSST { get; set; }

    [XmlElement(ElementName = "vICMSST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VICMSST { get; set; }
}

[XmlRoot(ElementName = "ICMS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ICMS
{

    [XmlElement(ElementName = "ICMS10", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public ICMS10 ICMS10 { get; set; } = new();
}

[XmlRoot(ElementName = "IPITrib", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class IPITrib
{

    [XmlElement(ElementName = "CST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CST { get; set; }

    [XmlElement(ElementName = "vBC", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VBC { get; set; }

    [XmlElement(ElementName = "pIPI", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal PIpi { get; set; }

    [XmlElement(ElementName = "vIPI", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VIPI { get; set; }
}

[XmlRoot(ElementName = "IPI", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class IPI
{

    [XmlElement(ElementName = "cEnq", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CEnq { get; set; }

    [XmlElement(ElementName = "IPITrib", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public IPITrib IPITrib { get; set; } = new();

    [XmlElement(ElementName = "IPINT", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public IPINT IPINT { get; set; } = new();
}

[XmlRoot(ElementName = "PISAliq", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class PISAliq
{

    [XmlElement(ElementName = "CST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CST { get; set; }

    [XmlElement(ElementName = "vBC", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VBC { get; set; }

    [XmlElement(ElementName = "pPIS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal PPIS { get; set; }

    [XmlElement(ElementName = "vPIS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VPIS { get; set; }
}

[XmlRoot(ElementName = "PIS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class PIS
{

    [XmlElement(ElementName = "PISAliq", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public PISAliq PISAliq { get; set; } = new();
}

[XmlRoot(ElementName = "COFINSAliq", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class COFINSAliq
{

    [XmlElement(ElementName = "CST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CST { get; set; }

    [XmlElement(ElementName = "vBC", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VBC { get; set; }

    [XmlElement(ElementName = "pCOFINS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal PCOFINS { get; set; }

    [XmlElement(ElementName = "vCOFINS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VCOFINS { get; set; }
}

[XmlRoot(ElementName = "COFINS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class COFINS
{

    [XmlElement(ElementName = "COFINSAliq", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public COFINSAliq COFINSAliq { get; set; } = new();
}

[XmlRoot(ElementName = "imposto", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Imposto
{

    [XmlElement(ElementName = "ICMS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public ICMS ICMS { get; set; } = new();

    [XmlElement(ElementName = "IPI", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public IPI IPI { get; set; } = new();

    [XmlElement(ElementName = "PIS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public PIS PIS { get; set; } = new();

    [XmlElement(ElementName = "COFINS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public COFINS COFINS { get; set; } = new();
}

[XmlRoot(ElementName = "det", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Det
{

    [XmlElement(ElementName = "prod", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Prod Prod { get; set; } = new();

    [XmlElement(ElementName = "imposto", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Imposto Imposto { get; set; } = new();

    [XmlAttribute(AttributeName = "nItem", Namespace = "")]
    public int NItem { get; set; }

    [XmlText]
    public string Text { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "IPINT", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class IPINT
{

    [XmlElement(ElementName = "CST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CST { get; set; }
}

[XmlRoot(ElementName = "ICMSTot", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ICMSTot
{

    [XmlElement(ElementName = "vBC", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VBC { get; set; }

    [XmlElement(ElementName = "vICMS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VICMS { get; set; }

    [XmlElement(ElementName = "vICMSDeson", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VICMSDeson { get; set; }

    [XmlElement(ElementName = "vFCP", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VFCP { get; set; }

    [XmlElement(ElementName = "vBCST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VBCST { get; set; }

    [XmlElement(ElementName = "vST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VST { get; set; }

    [XmlElement(ElementName = "vFCPST", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VFCPST { get; set; }

    [XmlElement(ElementName = "vFCPSTRet", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VFCPSTRet { get; set; }

    [XmlElement(ElementName = "vProd", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VProd { get; set; }

    [XmlElement(ElementName = "vFrete", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VFrete { get; set; }

    [XmlElement(ElementName = "vSeg", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VSeg { get; set; }

    [XmlElement(ElementName = "vDesc", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VDesc { get; set; }

    [XmlElement(ElementName = "vII", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VII { get; set; }

    [XmlElement(ElementName = "vIPI", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VIPI { get; set; }

    [XmlElement(ElementName = "vIPIDevol", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VIPIDevol { get; set; }

    [XmlElement(ElementName = "vPIS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VPIS { get; set; }

    [XmlElement(ElementName = "vCOFINS", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VCOFINS { get; set; }

    [XmlElement(ElementName = "vOutro", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VOutro { get; set; }

    [XmlElement(ElementName = "vNF", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VNF { get; set; }
}

[XmlRoot(ElementName = "total", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Total
{

    [XmlElement(ElementName = "ICMSTot", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public ICMSTot ICMSTot { get; set; } = new();
}

[XmlRoot(ElementName = "transporta", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Transporta
{

    [XmlElement(ElementName = "CNPJ", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string CNPJ { get; set; } = string.Empty;

    [XmlElement(ElementName = "xNome", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XNome { get; set; } = string.Empty;

    [XmlElement(ElementName = "IE", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string IE { get; set; } = string.Empty;

    [XmlElement(ElementName = "xEnder", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XEnder { get; set; } = string.Empty;

    [XmlElement(ElementName = "xMun", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XMun { get; set; } = string.Empty;

    [XmlElement(ElementName = "UF", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string UF { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "vol", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Vol
{

    [XmlElement(ElementName = "qVol", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int QVol { get; set; }

    [XmlElement(ElementName = "esp", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string Esp { get; set; } = string.Empty;

    [XmlElement(ElementName = "pesoL", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal PesoL { get; set; }

    [XmlElement(ElementName = "pesoB", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal PesoB { get; set; }
}

[XmlRoot(ElementName = "transp", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Transp
{

    [XmlElement(ElementName = "modFrete", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int ModFrete { get; set; }

    [XmlElement(ElementName = "transporta", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Transporta Transporta { get; set; } = new();

    [XmlElement(ElementName = "vol", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Vol Vol { get; set; } = new();
}

[XmlRoot(ElementName = "detPag", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class DetPag
{

    [XmlElement(ElementName = "indPag", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int IndPag { get; set; }

    [XmlElement(ElementName = "tPag", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int TPag { get; set; }

    [XmlElement(ElementName = "vPag", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public decimal VPag { get; set; }
}

[XmlRoot(ElementName = "pag", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class Pag
{
    [XmlElement(ElementName = "detPag", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public DetPag DetPag { get; set; } = new();
}

[XmlRoot(ElementName = "infAdic", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class InfAdic
{

    [XmlElement(ElementName = "infCpl", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string InfCpl { get; set; } = string.Empty;
    [XmlElement(ElementName = "infAdFisco", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string InfAdFisco { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "infNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class InfNFe
{

    [XmlElement(ElementName = "ide", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Ide Ide { get; set; } = new();

    [XmlElement(ElementName = "emit", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Emit Emit { get; set; } = new();

    [XmlElement(ElementName = "dest", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Dest Dest { get; set; } = new();

    [XmlElement(ElementName = "autXML", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public AutXML AutXML { get; set; } = new();

    [XmlElement(ElementName = "det", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public List<Det> Det { get; set; } = new();

    [XmlElement(ElementName = "total", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Total Total { get; set; } = new();

    [XmlElement(ElementName = "transp", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Transp Transp { get; set; } = new();

    [XmlElement(ElementName = "pag", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public Pag Pag { get; set; } = new();

    [XmlElement(ElementName = "infAdic", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public InfAdic InfAdic { get; set; } = new();

    [XmlAttribute(AttributeName = "versao", Namespace = "")]
    public decimal Versao { get; set; } = new();

    [XmlAttribute(AttributeName = "Id", Namespace = "")]
    public string Id { get; set; } = string.Empty;

    [XmlText]
    public string Text { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class CanonicalizationMethod
{

    [XmlAttribute(AttributeName = "Algorithm", Namespace = "")]
    public string Algorithm { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class SignatureMethod
{

    [XmlAttribute(AttributeName = "Algorithm", Namespace = "")]
    public string Algorithm { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class Transform
{

    [XmlAttribute(AttributeName = "Algorithm", Namespace = "")]
    public string Algorithm { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class Transforms
{

    [XmlElement(ElementName = "Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public List<Transform> Transform { get; set; } = new();
}

[XmlRoot(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class DigestMethod
{

    [XmlAttribute(AttributeName = "Algorithm", Namespace = "")]
    public string Algorithm { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class Reference
{

    [XmlElement(ElementName = "Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public Transforms Transforms { get; set; } = new();

    [XmlElement(ElementName = "DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public DigestMethod DigestMethod { get; set; } = new();

    [XmlElement(ElementName = "DigestValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public object DigestValueTransforms { get; set; } = new();

    [XmlAttribute(AttributeName = "URI", Namespace = "")]
    public string URITransforms { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class SignedInfo
{

    [XmlElement(ElementName = "CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public CanonicalizationMethod CanonicalizationMethod { get; set; } = new();

    [XmlElement(ElementName = "SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureMethod SignatureMethod { get; set; } = new();

    [XmlElement(ElementName = "Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public Reference Reference { get; set; } = new();
}

[XmlRoot(ElementName = "X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class X509Data
{

    [XmlElement(ElementName = "X509Certificate", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public object X509Certificate { get; set; } = new();
}

[XmlRoot(ElementName = "KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class KeyInfo
{

    [XmlElement(ElementName = "X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public X509Data X509Data { get; set; } = new();
}

[XmlRoot(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public class Signature
{

    [XmlElement(ElementName = "SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignedInfo SignedInfo { get; set; } = new();

    [XmlElement(ElementName = "SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public object SignatureValue { get; set; } = new();

    [XmlElement(ElementName = "KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public KeyInfo KeyInfo { get; set; } = new();

    [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
    public string Xmlns { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "NFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class NFe
{

    [XmlElement(ElementName = "infNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public InfNFe InfNFe { get; set; } = new();

    [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public Signature Signature { get; set; } = new();
}

[XmlRoot(ElementName = "infProt", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class InfProt
{

    [XmlElement(ElementName = "tpAmb", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int TpAmb { get; set; }

    [XmlElement(ElementName = "verAplic", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int VerAplic { get; set; }

    [XmlElement(ElementName = "chNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string ChNFe { get; set; } = string.Empty;

    [XmlElement(ElementName = "dhRecbto", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public DateTime DhRecbto { get; set; }

    [XmlElement(ElementName = "nProt", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string NProt { get; set; } = string.Empty;

    [XmlElement(ElementName = "digVal", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string DigVal { get; set; } = string.Empty;

    [XmlElement(ElementName = "cStat", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public int CStat { get; set; }

    [XmlElement(ElementName = "xMotivo", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public string XMotivo { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "protNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class ProtNFe
{

    [XmlElement(ElementName = "infProt", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public InfProt InfProt { get; set; } = new();

    [XmlAttribute(AttributeName = "versao", Namespace = "")]
    public decimal Versao { get; set; }

    [XmlText]
    public string Text { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "nfeProc", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class NfeProc
{

    [XmlElement(ElementName = "NFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public NFe NFe { get; set; } = new();

    [XmlElement(ElementName = "protNFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public ProtNFe ProtNFe { get; set; } = new();

    [XmlAttribute(AttributeName = "xmlns", Namespace = "")]
    public string Xmlns { get; set; } = string.Empty;

    [XmlAttribute(AttributeName = "versao", Namespace = "")]
    public decimal Versao { get; set; }

    [XmlText]
    public string Text { get; set; } = string.Empty;
}

