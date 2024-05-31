using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class Automobilis
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public int Metai { get; set; }
        public string RegistracijosNumeris { get; set; }

        public Automobilis() 
        { 
        
        }

        public Automobilis( string marke, string modelis, int metai, string registracijosNumeris)
        {
            Marke = marke;
            Modelis = modelis;
            Metai = metai;
            RegistracijosNumeris = registracijosNumeris;
        }

        public Automobilis(int id, string marke, string modelis, int metai, string registracijosNumeris)
        {
            Id = id;
            Marke = marke;
            Modelis = modelis;
            Metai = metai;
            RegistracijosNumeris = registracijosNumeris;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Marke: {Marke}, Modelis: {Modelis}, Metai: {Metai}, RegistracijosNumeris: {RegistracijosNumeris}";
        }
    }
}
