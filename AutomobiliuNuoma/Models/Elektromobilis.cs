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
        public decimal Kaina {  get; set; }

        public Elektromobilis(string marke, string modelis, int metai, string registracijosNumeris, int baterijosTalpa, decimal kaina)
            : base(marke, modelis, metai, registracijosNumeris)
        {
            BaterijosTalpa = baterijosTalpa;
            Kaina = kaina;
        }
        public Elektromobilis(int id, string marke, string modelis, int metai, string registracijosNumeris, int baterijosTalpa, decimal kaina)
            : base(id, marke, modelis, metai, registracijosNumeris)
        {
            BaterijosTalpa = baterijosTalpa;
            Kaina = kaina;
        }

        public override string ToString()
        {
            return base.ToString() + $", Elektromobilis, Baterijos Talpa: {BaterijosTalpa}, Paros kaina:{Kaina}";
        }
    }
}
