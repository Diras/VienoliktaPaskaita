using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class NaftosKuroAutomobilis: Automobilis
    {
        [JsonPropertyName("bakoTalpa")]
        public int BakoTalpa { get; set; }
        [JsonPropertyName("kaina")]
        public decimal Kaina {  get; set; }

        public NaftosKuroAutomobilis() { }

        public NaftosKuroAutomobilis( string marke, string modelis, int metai, string registracijosNumeris, int bakoTalpa, decimal kaina)
            : base(marke, modelis, metai, registracijosNumeris)
        {
            BakoTalpa = bakoTalpa;
            Kaina = kaina;
        }

        public NaftosKuroAutomobilis(int id, string marke, string modelis, int metai, string registracijosNumeris, int bakoTalpa, decimal kaina)
            : base(id, marke, modelis, metai, registracijosNumeris)
        {
            BakoTalpa = bakoTalpa;
            Kaina = kaina;
        }

        public override string ToString()
        {
            return base.ToString() + $", Bako Talpa: {BakoTalpa}, Paros kaina:{Kaina}";
        }
    }
}
