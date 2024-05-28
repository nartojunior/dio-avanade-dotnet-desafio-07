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
        private string data;        

        public Calculadora(string data)
        {
            this.data = data;
            historico = new List<string>();
        }

        public int Somar(int x, int y) 
        {
            InsertAcao(nameof(Somar), x, y);
            return x + y;
        }

        public int Subtrair(int x, int y)
        {
            InsertAcao(nameof(Subtrair), x, y);
            return x - y;
        }

        public int Multiplicar(int x, int y)
        {
            InsertAcao(nameof(Multiplicar), x, y);
            return x * y;
        }

        public int Dividir(int x, int y)
        {
            InsertAcao(nameof(Dividir), x, y);
            return x / y;
        }

        public List<string> Historico()
        {
            if (historico.Count > 3)
                historico.RemoveRange(3, historico.Count - 3);

            return historico;
        }

        private void InsertAcao(string acao, int x, int y) 
        {
            historico.Insert(0, $"{acao}: {x} e {y} em ({this.data})");
        }
    }
}
