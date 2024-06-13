using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class Klientas
    {
		[JsonPropertyName("id")]
        [Key]
        public int Id { get; set; }
		[JsonPropertyName("vardas")]
		public string Vardas { get; set; }
		[JsonPropertyName("pavarde")]
		public string Pavarde { get; set; }
		[JsonPropertyName("gimimoData")]
		public DateTime GimimoData { get; set; }
		[JsonPropertyName("registracijosData")]
		public DateTime RegistracijosData { get; set; }


        public Klientas()
        {

        }
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
