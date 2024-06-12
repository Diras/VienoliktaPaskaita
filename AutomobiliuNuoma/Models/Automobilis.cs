using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Models
{
    [BsonKnownTypes(typeof(Elektromobilis), typeof(NaftosKuroAutomobilis))]
    public class Automobilis
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("marke")]
        public string Marke { get; set; }

        [JsonPropertyName("modelis")]
        public string Modelis { get; set; }

        [JsonPropertyName("metai")]
        public int Metai { get; set; }

        [JsonPropertyName("registracijosNumeris")]
        public string RegistracijosNumeris { get; set; }

        [BsonId]
        public ObjectId innerId { get; set; }

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
