using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameoflife
{
    public class ContadorVivos
    {
        int[,] Vizinhanca;
        public ContadorVivos(int[,] matriz)
        {
            Vizinhanca = matriz;
        }

        public int ContarVivos(int posicaoI, int posicaoJ)
        {
            List<Posicao> posicoes = MontarPosicoes(posicaoI, posicaoJ);
            int vivos = 0;

            foreach (var posicao in posicoes)
            {
                try
                {
                    vivos += Vizinhanca[posicao.i, posicao.j];
                }
                catch
                { }
            }

            return vivos;
        }

        private List<Posicao> MontarPosicoes(int posicaoI, int posicaoJ)
        {
            return new List<Posicao>
            {
                new Posicao{ i = posicaoI-1, j = posicaoJ-1},
                new Posicao{ i = posicaoI, j = posicaoJ-1},
                new Posicao{ i = posicaoI+1, j = posicaoJ-1},
                new Posicao{ i = posicaoI-1, j = posicaoJ},
                new Posicao{ i = posicaoI+1, j = posicaoJ},
                new Posicao{ i = posicaoI-1, j = posicaoJ+1 },
                new Posicao{ i = posicaoI, j = posicaoJ+1 },
                new Posicao{ i = posicaoI+1, j = posicaoJ+1 }
            };
        }
    }

    public struct Posicao
    {
        public int i { get; set; }
        public int j { get; set; }
    }
}
