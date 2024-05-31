using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    public class Nuoma
    {
        public int Id { get; set; }
        public int AutomobilioId { get; set; }
        public int KlientoId { get; set; }
        public DateTime NuomosPradzia { get; set; }
        public DateTime GrazinimoData { get; set; }

        public decimal Suma {  get; set; }


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
