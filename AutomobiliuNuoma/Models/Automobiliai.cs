using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class Automobiliai
    {
        
        public List<Elektromobilis> elektromobiliai { get; set; }
        
        public List<NaftosKuroAutomobilis> naftosKuroAutomobiliai { get; set; }



        public Automobiliai()
        {
            elektromobiliai = new List<Elektromobilis>();   
            naftosKuroAutomobiliai = new List<NaftosKuroAutomobilis>();
        }
    }

   
    
}
