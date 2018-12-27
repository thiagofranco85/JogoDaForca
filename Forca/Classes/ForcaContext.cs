using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Classes
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ForcaContext : DbContext
    {
        public DbSet<Palavra> Palavra { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Palpite> Palpite { get; set; }

        public ForcaContext() : base("name=StringDeConexaoForcaMySql")
        {
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
