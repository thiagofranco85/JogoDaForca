using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Classes
{
    public class Palpite
    {
        [Key]
        public int Id { get; set; }        
        public char Letra { get; set; } 
        public int Erro { get; set; }        

    }
}
