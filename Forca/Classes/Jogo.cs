using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Classes
{
    public class Jogo
    {   [Key]     
        public int Id{ get; set; }
        public int NumChance { get; set; }
        public int NumTentativa { get; set; }
        public bool Vitoria { get; set; }        
        public int PalavraId { get; set; }

        [ForeignKey("PalavraId")]
        public virtual Palavra Palavra { get; set; }

        public virtual ICollection<Palpite> Palpites { get; set; }

        public Jogo(int numChance, Palavra palavra)
        {
            NumChance = numChance;
            Palavra = palavra;
        }
 
    }
}
