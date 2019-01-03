using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Classes
{
    public class Palpite
    {
        [Key]
        public int Id { get; set; } 
        public string Letra { get; set; } 
        public int JogoId { get; set; }

        [ForeignKey("JogoId")]
        public virtual Jogo Jogo { get; set; }

        public Palpite()
        {
        }

        public Palpite(string letra, Jogo jogo)
        {
            Letra = letra;
            Jogo = jogo;
        }
    }
}
