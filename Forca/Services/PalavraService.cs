using System;
using System.Collections.Generic;
using Forca.Classes;
using Newtonsoft.Json;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Globalization;
using System.IO;

namespace Forca.Services
{
    public class PalavraService
    {
        public ForcaContext _FContext { get; private set; }
        public Palavra _Palavra { get; private set; }
        public HashSet<char> _LetrasPalpites { get; private set; }
        public string PalavraParcial { get; private set; }

        public PalavraService(ForcaContext fContext, Palavra palavra)
        {
            _FContext = fContext;
            _Palavra = palavra;
            _LetrasPalpites = new HashSet<char>();
            PalavraParcial = GeraLacunas();
        }

        public static Palavra BuscarPalavra()
        {
           // Console.WriteLine( Path.Combine(Directory.GetCurrentDirectory(), "palavras.json") );
           // Console.ReadKey();

            string textoArquivo = File.ReadAllText( Path.Combine(Directory.GetCurrentDirectory(), "palavras.json"), System.Text.Encoding.UTF8);
            //string textoArquivo = System.IO.File.ReadAllText(@"~/../palavras.json",System.Text.Encoding.UTF8);
            List<Palavra> palavras = JsonConvert.DeserializeObject<List<Palavra>>(textoArquivo);

            var rand = new Random();
            var index = palavras.Skip(rand.Next(0, palavras.Count)).Take(1);
            return index.First();
        }

        public bool VerificaVencedor()
        {
            return PalavraParcial == _Palavra.Termo;
        }

        public bool VerificaAcerto(char letra)
        {
            bool retorno = false;

            if( _Palavra.Termo.IndexOf(letra) >= 0)
            {
                retorno = true;
            }

            return retorno;
        }

        public List<char> ExibirTentivas()
        {
           return _LetrasPalpites.ToList();
        }

        public string GeraLacunas(char letra = char.MinValue )
        {
            int qtde = _Palavra.Termo.Length;
            string retorno="";

            if( letra == char.MinValue)
            {
                for (int i = 0; i < qtde; i++)
                {
                    if(_Palavra.Termo[i] == ' ')
                    {
                        retorno += " ";
                    }
                    else
                    {
                        retorno += "_";
                    }
                    
                }

                return retorno;
                 
            }
            else{
                int posicao = _Palavra.Termo.IndexOf(letra);
                _LetrasPalpites.Add(letra);
                if ( posicao >= 0)
                {
                    
                    char[] somenteLacunas = GeraLacunas().ToCharArray();


                    for (int i = 0; i < _LetrasPalpites.Count; i++)
                    {
                        for (int j = 0; j < _Palavra.Termo.Length; j++)
                        {
                            if (_Palavra.Termo[j] == _LetrasPalpites.ToList()[i])
                            {
                                somenteLacunas[j] = _LetrasPalpites.ToList()[i];
                                //Console.WriteLine(_Palavra.Termo[j]);
                            }
                        }
                    }

                    PalavraParcial = new string(somenteLacunas);
                } 
                return PalavraParcial;
            }          
            
        }       

        public string ExibeLacunas(string lacunas)
        {
            return lacunas.Replace("_", "_ ");
        }

        protected List<Palavra> LeArquivoJson()
        {
            string textoArquivo = System.IO.File.ReadAllText(@"~/../palavras.json", System.Text.Encoding.UTF8);
            List<Palavra> palavras = JsonConvert.DeserializeObject<List<Palavra>>(textoArquivo);

            return palavras;
        }

        public void PopulaDatabase()
        {
            int qtde = _FContext.Palavra.Count();
            ICollection<Palavra> lista;
            if ( qtde == 0)
            {
                lista = this.LeArquivoJson();

                foreach(Palavra p in lista)
                {
                    Console.WriteLine(p.Termo);
                }

                _FContext.Palavra.AddRange(lista);
                _FContext.SaveChanges();
            }
        }
    }
}
