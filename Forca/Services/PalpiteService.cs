using Forca.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Services
{
    class PalpiteService
    {
        public ForcaContext _FContext { get; private set; }
        public Palpite _Palpite { get; private set; }

        public PalpiteService(ForcaContext FContext, Palpite Palpite)
        {
            _FContext = FContext;
            _Palpite = Palpite;
        }

        public void cadastrar()
        {
            _FContext.Palpite.AddOrUpdate<Palpite>();
            _FContext.SaveChanges();
        }
    }
}
