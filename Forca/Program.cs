using Forca.Classes; 
using Forca.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca
{
    class Program
    {
        static void Main(string[] args)
        {             
            ForcaContext FContext = new ForcaContext();
            /*
            Palavra pal = new Palavra();
            pal.Termo = "Ola";
            pal.Dica = "Cumprimento";

            FContext.Entry(pal).State = EntityState.Added;
            int idPalavra = FContext.SaveChanges();

            Console.WriteLine(pal.Id);
            //update
            pal = FContext.Palavra.Find(pal.Id); 
            pal.Termo = "Hello";
            FContext.Entry(pal).State = EntityState.Modified;
            FContext.SaveChanges();
            return;
            */
            
            //Pega uma palavra pra iniciar o jogo
            Palavra p = PalavraService.BuscarPalavra();
            PalavraService pService = new PalavraService(FContext, p);
            //Se nao tiver nada no banco, popula com o palavras.json
            pService.PopulaDatabase();           

            //Instancia o Jogo
            Jogo j = new Jogo(6, p);

            //Salva Jogo no banco
            JogoService jService = new JogoService(FContext, j);
            int jogoId = jService.Cadastrar();
            //j.Id = jogoId;

            int tentativa = 1;
            //Executa um loop para contar as tentativas
            while( (j.NumChance - j.NumTentativa) > 0)
            {
                //Exibe a dica, nº de palpites restantes e as lacunas
                Console.WriteLine("\nDica:" + p.Dica);
                
                Console.Write("Nº de Tentativas: ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(j.NumChance - j.NumTentativa);
                Console.ResetColor();

                //Se for a primeira rodada
                if ( tentativa == 1)
                {
                    Console.WriteLine(pService.ExibeLacunas(pService.GeraLacunas()));
                }
                else
                {
                    Console.Write("Letras Utilizadas:");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    pService.ExibirTentivas().ForEach(x =>
                        Console.Write( x + " ")
                    );
                    Console.WriteLine("");
                    Console.ResetColor();
                }              

                //Exibe a msg pro usuario tentar
                Console.Write("Escolha uma letra:");

                char letra = Console.ReadLine().ToCharArray()[0];

                //Salva palpite no banco
                Palpite palpite = new Palpite(letra.ToString(), j);
                PalpiteService palpiteService = new PalpiteService(FContext, palpite);
                palpiteService.cadastrar();

                bool acertou = pService.VerificaAcerto(letra);                    
                
                

                //Se acertou, renderiza novas lacunas
                pService.GeraLacunas(letra);

                //Se errado, Adiciona uma tentativa
                if ( ! acertou )
                {
                    jService.AdicionarTentativa();
                } 

                Console.WriteLine(pService.ExibeLacunas(pService.PalavraParcial));

                if (pService.VerificaVencedor())
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Você Venceu! A palavra é " + pService._Palavra.Termo);

                    //Salva vitoria no banco  
                    j.Vitoria = true;
                    j.NumTentativa = tentativa;
                     
                    jService.Cadastrar();

                    return;
                }

                tentativa++;
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Você Perdeu! A palavra era " + pService._Palavra.Termo);


            Console.ReadKey();
        }
    }
}
