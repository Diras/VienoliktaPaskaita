using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class Elektromobilis: Automobilis
    {
        public int BaterijosTalpa { get; set; }


        public Elektromobilis(string marke, string modelis, int metai, string registracijosNumeris, int baterijosTalpa)
            : base(marke, modelis, metai, registracijosNumeris)
        {
            BaterijosTalpa = baterijosTalpa;
        }
        public Elektromobilis(int id, string marke, string modelis, int metai, string registracijosNumeris, int baterijosTalpa)
            : base(id, marke, modelis, metai, registracijosNumeris)
        {
            BaterijosTalpa = baterijosTalpa;
        }

        public override string ToString()
        {
            return base.ToString() + $", Elektromobilis, Baterijos Talpa: {BaterijosTalpa}";
        }
    }
}
