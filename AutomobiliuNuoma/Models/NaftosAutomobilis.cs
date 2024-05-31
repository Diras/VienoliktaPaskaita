using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class NaftosKuroAutomobilis: Automobilis
    {
        public int BakoTalpa { get; set; }


        public NaftosKuroAutomobilis( string marke, string modelis, int metai, string registracijosNumeris, int bakoTalpa)
            : base(marke, modelis, metai, registracijosNumeris)
        {
            BakoTalpa = bakoTalpa;
        }

        public NaftosKuroAutomobilis(int id, string marke, string modelis, int metai, string registracijosNumeris, int bakoTalpa)
            : base(id, marke, modelis, metai, registracijosNumeris)
        {
            BakoTalpa = bakoTalpa;
        }

        public override string ToString()
        {
            return base.ToString() + $", NaftosKuroAutomobilis, Bako Talpa: {BakoTalpa}";
        }
    }
}
