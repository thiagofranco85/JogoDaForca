using System;
using System.Collections.Generic;
using Forca.Classes;
using Newtonsoft.Json;
using System.Linq;


namespace Forca.Services
{
    public class PalavraService
    {
        //private Palavra Palavra { get; set; }         

        public static Palavra GetPalavra()
        {
            string textoArquivo = System.IO.File.ReadAllText(@"~/../palavras.json",System.Text.Encoding.UTF8);
            List<Palavra> palavras = JsonConvert.DeserializeObject<List<Palavra>>(textoArquivo);

            var rand = new Random();
            var index = palavras.Skip(rand.Next(0, palavras.Count)).Take(1);
            return index.First();
        }
    }
}
