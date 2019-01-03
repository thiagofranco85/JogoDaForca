using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Classes
{
    public class Palavra
    {   
        [Key]
        public int Id{ get; set; }

        private string _Termo;

        public string Termo {
            get { return _Termo; }
            set
            {
                _Termo = RemoveAcentos(value);
            }
        }
        public string Dica { get; set; }         

        public virtual ICollection<Jogo> Jogos { get; set; }

        public Palavra()
        {
        }

        public static string RemoveAcentos(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
