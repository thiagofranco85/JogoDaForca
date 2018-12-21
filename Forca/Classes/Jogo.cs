using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Classes
{
    public class Jogo
    {
        public Palavra Palavra { get; set; }
        public char Letra { get; set; }
        public int Palpite { get; set; }
        public int Erros { get; set; }

        public Jogo(Palavra palavra, char letra, int palpite)
        {
            Palavra = palavra;
            Letra = letra; 
        }
    }
}
