using EasyDanfe.Elements;
using EasyDanfe.Enums;
using EasyDanfe.Models;

namespace EasyDanfe.Modules;

internal class BlocoDuplicataFatura : ModuleBase
{

    public BlocoDuplicataFatura(DanfeModel viewModel, EstiloElement estilo) : base(viewModel, estilo)
    {
        var de = viewModel.Duplicatas.Select(x => new DuplicataElement(estilo, x)).ToList();
        var eh = de.First().Height;

        int numeroElementosLinha = ViewModel.IsPaisagem ? 7 : 6;

        int i = 0;

        while (i < de.Count)
        {
            var fl = new FlexibleLineElement(Width, eh);

            int i2;
            for (i2 = 0; i2 < numeroElementosLinha && i < de.Count; i2++, i++)
            {
                fl.ComElemento(de[i]);
            }

            for (; i2 < numeroElementosLinha; i2++)
                fl.ComElemento(new VazioElement());


            fl.ComLargurasIguais();
            MainVerticalStack.Add(fl);
        }

    }

    public override string Cabecalho => "Fatura / Duplicata";
    public override PosicaoBloco Posicao => PosicaoBloco.Topo;
}