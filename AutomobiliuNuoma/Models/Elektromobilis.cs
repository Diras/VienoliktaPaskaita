using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class Elektromobilis: Automobilis
    {
        [JsonPropertyName("baterijosTalpa")]
        public int BaterijosTalpa { get; set; }
        [JsonPropertyName("kaina")]
        public decimal Kaina {  get; set; }

        public Elektromobilis()
        {

        }
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
            return base.ToString() + $", Baterijos Talpa: {BaterijosTalpa}, Paros kaina:{Kaina}";
        }
    }
}
