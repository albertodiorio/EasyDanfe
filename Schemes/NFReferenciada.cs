using System.Xml;
using System.Xml.Serialization;

namespace EasyDanfe.Schemes;

[Serializable]
[XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
public class NFReferenciada
{
    [XmlElement("refCTe", typeof(string))]
    [XmlElement("refECF", typeof(RefECF))]
    [XmlElement("refNF", typeof(RefNF))]
    [XmlElement("refNFP", typeof(RefNFP))]
    [XmlElement("refNFe", typeof(string))]
    [XmlChoiceIdentifier("TipoNFReferenciada")]
    public object Item;

    [XmlIgnore]
    public TipoNFReferenciada TipoNFReferenciada { get; set; }

    public override string ToString()
    {
        if (TipoNFReferenciada == TipoNFReferenciada.refCTe || TipoNFReferenciada == TipoNFReferenciada.refNFe)
        {
            string chaveAcesso = Item.ToString();
            return $"{Utils.Utils.TipoDFeDeChaveAcesso(chaveAcesso)} Ref.: {Utils.Formatador.FormatarChaveAcesso(Item.ToString())}";
        }
        else
            return Item.ToString();
    }

}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
public enum TipoNFReferenciada
{
    refCTe,
    refECF,
    refNF,
    refNFP,
    refNFe,
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
public class RefECF
{
    public string mod { get; set; } = string.Empty;
    public string nECF { get; set; }
    public string nCOO { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"ECF Ref.: Modelo: {mod} ECF: {nECF} COO: {nCOO}";
    }
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
public class RefNF
{
    public string AAMM { get; set; } = string.Empty;
    public string CNPJ { get; set; } = string.Empty;
    public string mod { get; set; } = string.Empty;
    public string serie { get; set; } = string.Empty;
    public string nNF { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"NF Ref.: Série: {serie} Número: {nNF} Emitente: {Utils.Formatador.FormatarCnpj(CNPJ)} Modelo: {mod}";
    }
}

[Serializable]
[XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
public class RefNFP
{
    public string AAMM { get; set; } = string.Empty;
    public string CNPJ { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string IE { get; set; } = string.Empty;
    public string mod { get; set; } = string.Empty;
    public string serie { get; set; } = string.Empty;
    public string nNF { get; set; } = string.Empty;

    public override string ToString()
    {
        string cpfCnpj = !string.IsNullOrWhiteSpace(CNPJ) ? CNPJ : CPF;
        return $"NFP Ref.: Série: {serie} Número: {nNF} Emitente: {Utils.Formatador.FormatarCpfCnpj(cpfCnpj)} Modelo: {mod} IE: {IE}";
    }
}
