using System;

namespace DesafioEtapa3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool IsValido = false;
                int n = 0;
                string texto = "";

                //Solicita para o usuário informar valor de n.
                Console.WriteLine("Informe o valor de n: ");

                //Loop para verificar se o valor é númerico, se não exibe mensagem.
                while (!IsValido)
                {  
                    if (Int32.TryParse(Console.ReadLine(), out n))
                    {   //Excuta o resultado 
                        for (int i = 1; i <= n; i++)
                        {
                            var QtdEspaco = n - i;

                            texto = new String(' ', QtdEspaco) + new String('*', i);

                            Console.WriteLine(texto);
                        }
                   
                        IsValido = true;
                    }
                    else
                    {
                        Console.WriteLine("Informe um valor númerico!");
                    }
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}