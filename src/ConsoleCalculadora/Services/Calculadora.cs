using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculadora.Services
{
    public class Calculadora
    {
        private List<string> historico;

        public Calculadora()
        {
            historico = new List<string>();
        }

        public int Somar(int x, int y) 
        {
            historico.Insert(0, $"{nameof(Somar)}: {x} e {y}");
            return x + y;
        }

        public int Subtrair(int x, int y)
        {
            historico.Insert(0, $"{nameof(Subtrair)}: {x} e {y}");
            return x - y;
        }

        public int Multiplicar(int x, int y)
        {
            historico.Insert(0, $"{nameof(Multiplicar)}: {x} e {y}");
            return x * y;
        }

        public int Dividir(int x, int y)
        {
            historico.Insert(0, $"{nameof(Dividir)}: {x} e {y}");
            return x / y;
        }

        public List<string> Historico()
        {
            if (historico.Count > 3)
                historico.RemoveRange(3, historico.Count - 3);

            return historico;
        }

    }
}
