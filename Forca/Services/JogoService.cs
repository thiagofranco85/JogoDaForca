using Forca.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Services
{
    class JogoService
    {
        private ForcaContext FContext { get; set; }
        private Jogo Jogo { get; set; }

        public JogoService(ForcaContext fContext, Jogo jogo)
        {
            Jogo = jogo;
            FContext = fContext;
        }

        public void AdicionarTentativa()
        {
            Jogo.NumTentativa++;
        }
    }
}
