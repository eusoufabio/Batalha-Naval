using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNavalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int tamanho = solicitaNumero("Qual o tamanho da área de batalha? ");
            int barcos = solicitaNumero("Quantos barcos terão no jogo? ");

            string[] jogador = new string[2];

            for (int i = 0; i < jogador.Length; i++)
                jogador[i] = solicitaTexto(string.Format("Qual o nome do {0}º jodagor? ", i + 1));

            char[,,] area = new char[2, tamanho, tamanho];

            for (int jog = 0; jog < jogador.Length; jog++)
            {
                Console.Clear();

                for (int lin = 0; lin < tamanho; lin++)
                    for (int col = 0; col < tamanho; col++)
                        area[jog, lin, col] = ' ';

                for (int b = 0; b < barcos; b++)
                {
                    Console.Clear();
                    Console.WriteLine(string.Format("{0}, difina as posições dos seus barcos", jogador[jog]));
                    Console.WriteLine();
                    Console.WriteLine("MAPA DO {0}", );
                    int[] coordenadas = new int[2];
                    coordenadas = solicitaCoordenadas(string.Format("Coordenadas do barco {0}: ", b + 1));

                    area[jog, coordenadas[0], coordenadas[1]] = '█';
                }

                imprimeArea(area, jog);
                Console.ReadLine();
            }
        }

        static string criarGrade(string inicio, string meio, string fim, int quant)
        {
            string retorno = inicio;

            for (int i = 1; i < quant; i++)
                retorno = string.Concat(retorno, meio);

            retorno = string.Concat(retorno, fim);
            return retorno;
        }

        static void imprimeArea(char[,,] area, int jogador)
        {
            Console.WriteLine(criarGrade("┌─", "─┬─", "─┐", area.GetLength(1)));
            for (int lin = 0; lin < area.GetLength(1); lin++)
            {
                string linha = "│";
                for (int col = 0; col < area.GetLength(2); col++)
                    linha = string.Concat(linha, area[jogador, lin, col], area[jogador, lin, col], '│');

                Console.WriteLine(linha);
                if (lin < area.GetLength(2) - 1)
                    Console.WriteLine(criarGrade("├─", "─┼─", "─┤", area.GetLength(1)));
            }
            Console.WriteLine(criarGrade("└─", "─┴─", "─┘", area.GetLength(1)));
        }

        static int solicitaNumero(string mensagem)
        {
            int entrada = 0;
            bool valido = false;

            while (!valido)
            {
                Console.Write(mensagem);
                try
                {
                    entrada = int.Parse(Console.ReadLine());
                    valido = true;
                }
                catch
                {
                    Console.WriteLine("O valor digitado não é um número inteiro válido!");
                }
            }
            return entrada;
        }

        static string solicitaTexto(string mensagem)
        {
            Console.Write(mensagem);
            return Console.ReadLine();
        }

        static int[] solicitaCoordenadas(string mensagem)
        {
            string entrada;
            string[] partes = new string[1];
            int[] retorno = new int[2];
            bool valido = false;

            while (!valido)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine().Replace(',', '.');

                partes = entrada.Split('.');

                if (partes.Length == 2)
                    valido = (eNumero(partes[0]) && eNumero(partes[1]));
            }

            retorno[0] = int.Parse(partes[0]);
            retorno[1] = int.Parse(partes[1]);

            return retorno;
        }

        static bool eNumero(string texto)
        {
            try
            {
                int num = int.Parse(texto);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
