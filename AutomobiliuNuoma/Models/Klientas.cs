using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class Klientas
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateTime GimimoData { get; set; }
        public DateTime RegistracijosData { get; set; }

        public Klientas(string vardas, string pavarde, DateTime gimimoData, DateTime registracijosData) 
        {
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoData = gimimoData;
            RegistracijosData = registracijosData;
        }

        public Klientas(int id, string vardas, string pavarde, DateTime gimimoData, DateTime registracijosData)
        {
            Id = id;
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoData = gimimoData;
            RegistracijosData = registracijosData;
        }

        public override string ToString()
        {
            return $"ID:{Id}-{Vardas}-{Pavarde}-Gimimo data:{GimimoData.ToShortDateString()}-Registracijos data:{RegistracijosData}";
        }
    }
}
