using Forca.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( PalavraService.GetPalavra().Termo );
            Console.ReadKey();
        }
    }
}
