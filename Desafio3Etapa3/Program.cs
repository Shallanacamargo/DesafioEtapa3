using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Desafio3Etapa3
{
    class Program
    {
        private static readonly char[] s_converterLetras = ConverterLetras();

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    //Solicitar ao usuário o texto a ser validado
                    Console.WriteLine("Digite uma palavra para verificar quantos Anagramas existem: ");
                    var texto = Console.ReadLine();

                    //Normalizar letras sem acentuações, espaçamentos e colocar todas as letras em minusculo
                    texto = RemoverAcentuacoes(texto.ToLower().Trim());

                    //Remove caracteres especiais
                    texto = Regex.Replace(texto, @"\d", "");

                    //Chamar o método para validar anagramas
                    var retorno = ValidarAnagramas(texto);

                    //Escreve o retorno no console
                    Console.WriteLine(retorno);
                }
            }
            catch (Exception ex)
            {
                //Escreve mensagem de erro 
                Console.WriteLine(ex.Message);
            }
        }

        static int ValidarAnagramas(string texto)
        {
            //Monta todas as possiveis combinações através de uma string e adiciona em uma lista para comparação posterior
            var combinacoesPossiveis = new List<string>();
            for (var i = 0; i < texto.Length; i++)
            {
                for (var j = i; j < texto.Length; j++)
                {
                    combinacoesPossiveis.Add(texto.Substring(i, j - i + 1));
                }
            }

            //Total de anagramas a ser retornado
            var totalAnagramas = 0;

            //Compara as combinações e soma os anagramas possiveis 
            for (var i = 0; i < combinacoesPossiveis.Count - 1; i++)
            {
                var letraInicial = combinacoesPossiveis[i];
                var ordenaLetras = new string(letraInicial.OrderBy(l => l).ToArray());
                for (var j = i + 1; j < combinacoesPossiveis.Count; j++)
                {
                    var letra = combinacoesPossiveis[j];
                    var ordenaLetra = new string(letra.OrderBy(l => l).ToArray());
                    if (ordenaLetras == ordenaLetra)
                    {
                        totalAnagramas++;
                    }
                }
            }

            //Retornar o total de anagramas
            return totalAnagramas;
        }

        public static string RemoverAcentuacoes(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] > 255)
                    sb.Append(texto[i]);
                else
                    sb.Append(s_converterLetras[texto[i]]);
            }

            return sb.ToString();
        }

        private static char[] ConverterLetras()
        {
            char[] accents = new char[256];

            for (int i = 0; i < 256; i++)
                accents[i] = (char)i;

            accents[(byte)'á'] = accents[(byte)'à'] = accents[(byte)'ã'] = accents[(byte)'â'] = accents[(byte)'ä'] = 'a';
            accents[(byte)'Á'] = accents[(byte)'À'] = accents[(byte)'Ã'] = accents[(byte)'Â'] = accents[(byte)'Ä'] = 'A';

            accents[(byte)'é'] = accents[(byte)'è'] = accents[(byte)'ê'] = accents[(byte)'ë'] = 'e';
            accents[(byte)'É'] = accents[(byte)'È'] = accents[(byte)'Ê'] = accents[(byte)'Ë'] = 'E';

            accents[(byte)'í'] = accents[(byte)'ì'] = accents[(byte)'î'] = accents[(byte)'ï'] = 'i';
            accents[(byte)'Í'] = accents[(byte)'Ì'] = accents[(byte)'Î'] = accents[(byte)'Ï'] = 'I';

            accents[(byte)'ó'] = accents[(byte)'ò'] = accents[(byte)'ô'] = accents[(byte)'õ'] = accents[(byte)'ö'] = 'o';
            accents[(byte)'Ó'] = accents[(byte)'Ò'] = accents[(byte)'Ô'] = accents[(byte)'Õ'] = accents[(byte)'Ö'] = 'O';

            accents[(byte)'ú'] = accents[(byte)'ù'] = accents[(byte)'û'] = accents[(byte)'ü'] = 'u';
            accents[(byte)'Ú'] = accents[(byte)'Ù'] = accents[(byte)'Û'] = accents[(byte)'Ü'] = 'U';

            accents[(byte)'ç'] = 'c';
            accents[(byte)'Ç'] = 'C';

            accents[(byte)'ñ'] = 'n';
            accents[(byte)'Ñ'] = 'N';

            accents[(byte)'ÿ'] = accents[(byte)'ý'] = 'y';
            accents[(byte)'Ý'] = 'Y';

            return accents;
        }
    }
}
