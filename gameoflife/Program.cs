using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gameoflife
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] comunidade = CriarComunidadeInicial(60, 90);
            CriarGeracoes(comunidade);

            Console.ReadKey();
        }

        /// <summary>
        /// Gera a comunidade inicial aleatória
        /// </summary>
        /// <param name="altura"></param>
        /// <param name="largura"></param>
        /// <returns></returns>
        private static int[,] CriarComunidadeInicial(int altura, int largura)
        {
            int[,] matriz = new int[altura, largura];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = j % 2;
                }
            }
            return matriz;
        }

        /// <summary>
        /// Gera as próximas gerações
        /// </summary>
        /// <param name="comunidade"></param>
        private static void CriarGeracoes(int[,] comunidade)
        {
            int[,] novaComunidade = new int[comunidade.GetLength(0), comunidade.GetLength(1)];
            for (int i = 0; i < comunidade.GetLength(0); i++)
            {
                for (int j = 0; j < comunidade.GetLength(1); j++)
                {
                    novaComunidade[i, j] = DecidirFuturo(i, j, comunidade);
                    Console.Write(comunidade[i, j]);
                }
                Console.WriteLine("");
            }
            Thread.Sleep(1000);
            CriarGeracoes(novaComunidade);
        }

        /// <summary>
        /// Valida as regras para decidir a proxima geração 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="comunidade"></param>
        /// <returns></returns>
        private static int DecidirFuturo(int i, int j, int[,] comunidade)
        {
            var contadorVivos = new ContadorVivos(comunidade);
            int vizinhosVivos = contadorVivos.ContarVivos(i, j);
            if (vizinhosVivos < 2 || vizinhosVivos > 3)
                return 0;
            if (vizinhosVivos == 3)
                return 1;
            if (vizinhosVivos == 2 || vizinhosVivos == 3)
                return comunidade[i, j];
            return 0;
        }
    }
}
