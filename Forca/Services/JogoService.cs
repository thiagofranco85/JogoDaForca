using Forca.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Services
{
    class JogoService
    {
        private ForcaContext _FContext { get; set; }
        private Jogo _Jogo { get; set; }

        public JogoService(ForcaContext fContext, Jogo jogo)
        {
            _Jogo = jogo;
            _FContext = fContext;
        }

        public void AdicionarTentativa()
        {
            _Jogo.NumTentativa++;
        }

        public int Cadastrar()
        {
            _FContext.Jogo.AddOrUpdate<Jogo>(_Jogo);
            return _FContext.SaveChanges();            
        }
    }
}
