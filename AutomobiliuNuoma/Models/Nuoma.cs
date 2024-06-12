using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class Nuoma
    {
		[JsonPropertyName("id")]
		public int Id { get; set; }
		[JsonPropertyName("automobilioId")]
		public int AutomobilioId { get; set; }
		[JsonPropertyName("klientoId")]
		public int KlientoId { get; set; }
		[JsonPropertyName("nuomosPradzia")]
		public DateTime NuomosPradzia { get; set; }
		[JsonPropertyName("grazinimoData")]
		public DateTime GrazinimoData { get; set; }
		[JsonPropertyName("suma")]
		public decimal Suma {  get; set; }

        public Nuoma()
        {

        }
        public Nuoma(int automobilioId, int klientoId, DateTime grazinimoData, decimal suma)
        {
            AutomobilioId = automobilioId;
            KlientoId = klientoId;
            NuomosPradzia = DateTime.Now;
            GrazinimoData = grazinimoData;
            Suma = suma;
        }

        public Nuoma(int automobilioId, int klientoId, DateTime nuomosPradzia, DateTime grazinimoData, decimal suma)
        {
            AutomobilioId = automobilioId;
            KlientoId = klientoId;
            NuomosPradzia = nuomosPradzia;
            GrazinimoData = grazinimoData;
            Suma = suma;
        }
        public Nuoma(int id, int automobilioId, int klientoId, DateTime nuomosPradzia, DateTime grazinimoData, decimal suma) 
        {
            Id = id;
            AutomobilioId = automobilioId;
            KlientoId = klientoId;
            NuomosPradzia = nuomosPradzia;
            GrazinimoData = grazinimoData;
            Suma = suma;
        }

        public override string ToString()
        {
            return $"ID:{Id}-AutoID:{AutomobilioId}-KlientoID:{KlientoId}-Pradzia:{NuomosPradzia.ToShortDateString()}-Grazinimas:{GrazinimoData.ToShortDateString()}-Kaina:{Suma}";
        }
    }
}
