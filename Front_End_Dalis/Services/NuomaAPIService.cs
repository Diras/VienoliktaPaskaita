using AutomobiliuNuoma.Models;
using Front_End_Dalis.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Serilog;


namespace Front_End_Dalis.Services
{
    public class NuomaAPIService : INuomaAPIService
    {
        private readonly string _apiBase;
        private readonly HttpClient _httpClient;

        public NuomaAPIService(string apiBase)
        {
            _apiBase = apiBase;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBase);    
        }

        public Automobiliai GautiVisusAutomobilius()
        {
            string path = "api/Automobiliu/GetAutomobiliai";
            HttpResponseMessage response = _httpClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                Automobiliai automobiliai = JsonSerializer.Deserialize<Automobiliai>(jsonResponse);
                return automobiliai;
            }
            else
            {
                return new Automobiliai();
            }
        }

        public List<Elektromobilis> FiltruotiAutomobiliusPagalElektro(string tipas)
        {
            string path = $"api/Automobiliu/GetAutoPagalTipa/{tipas}";
            HttpResponseMessage response = _httpClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                List<Elektromobilis> automobiliai = JsonSerializer.Deserialize<List<Elektromobilis>>(jsonResponse);
                return automobiliai;
            }
            else
            {
                return new List<Elektromobilis>();
            }
        }

        public List<NaftosKuroAutomobilis> FiltruotiAutomobiliusPagalNaftos(string tipas)
        {
            string path = $"api/Automobiliu/GetAutoPagalTipa/{tipas}";
            HttpResponseMessage response = _httpClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                List<NaftosKuroAutomobilis> automobiliai = JsonSerializer.Deserialize<List<NaftosKuroAutomobilis>>(jsonResponse);
                return automobiliai;
            }
            else
            {
                return new List<NaftosKuroAutomobilis>();
            }
        }


        public Automobilis GautiAutomobiliPagalId(int id)
        {
            string path = $"api/Automobiliu/GetAutoPagalId/{id}";
            HttpResponseMessage response = _httpClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                using (JsonDocument document = JsonDocument.Parse(jsonResponse))
                {
                    JsonElement root = document.RootElement;

                    if (root.TryGetProperty("bakoTalpa", out _))
                    {
                        NaftosKuroAutomobilis naftosKuroAutomobilis = JsonSerializer.Deserialize<NaftosKuroAutomobilis>(jsonResponse);
                        return naftosKuroAutomobilis;
                    }
                    else if (root.TryGetProperty("baterijosTalpa", out _))
                    {
                        Elektromobilis elektromobilis = JsonSerializer.Deserialize<Elektromobilis>(jsonResponse);
                        return elektromobilis;
                    }
                }
            }
            return null;
        }
        public async Task<Automobiliai> GautiAutomobiliusPagalPavadinimaAsync(string pavadinimas)
        {
            try
            {
                string path = $"api/Automobiliu/GetAutoPagalPavadinima/{pavadinimas}";
                HttpResponseMessage response = await _httpClient.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Automobiliai automobiliai = JsonSerializer.Deserialize<Automobiliai>(jsonResponse);

                    return automobiliai;
                }
                else
                {
                    return new Automobiliai();
                }
            }
            catch (Exception ex)
            {
                // Apdorojimas klaidoms
                return new Automobiliai();
            }
        }

        public async Task AtnaujintiElektromobili(int id, Elektromobilis elektromobilis)
        {
            try
            {
                string path = $"api/Automobiliu/AtnaujintiAutomobilisElektro/{id}";
                string jsonContent = JsonSerializer.Serialize(elektromobilis);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PatchAsync(path, content);

                // Patikrinkite atsakymą
                if (!response.IsSuccessStatusCode)
                {
                    Log.Error($"Nepavyko atnaujinti elektromobilio. Status kodas: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Klaida atnaujinant elektromobili - NuomaAPI");
                throw;
            }
        }

        public async Task AtnaujintiNaftosKuroAutomobili(int id, NaftosKuroAutomobilis naftosKuroAutomobilis)
        {
            try
            {
                string path = $"api/Automobiliu/AtnaujintiAutomobilisNaftos/{id}";
                string jsonContent = JsonSerializer.Serialize(naftosKuroAutomobilis);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PatchAsync(path, content);

                // Patikrinkite atsakymą
                if (!response.IsSuccessStatusCode)
                {
                    Log.Error($"Nepavyko atnaujinti elektromobilio. Status kodas: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Klaida atnaujinant elektromobili - NuomaAPI");
                throw;
            }
        }


        public void IstrintiAutomobili(int id)
        {
            throw new NotImplementedException();
        }

        



        public List<Klientas> GautiVisusKlientus()
		{
			string path = "api/Klientai/GetKlientai";
			HttpResponseMessage response = _httpClient.GetAsync(path).Result;
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = response.Content.ReadAsStringAsync().Result;
				return JsonSerializer.Deserialize<List<Klientas>>(jsonResponse);
			}
			else
			{
				return new List<Klientas>();
			}
		}

        public async Task<List<Klientas>> GautiKlientusPagalPavadinima(string pavadinimas)
        {
            string path = $"api/Klientai/GetKlientaiPagalPavadinima/{pavadinimas}";
            HttpResponseMessage response = _httpClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<List<Klientas>>(jsonResponse);
            }
            else
            {
                return new List<Klientas>();
            }
        }

        public Klientas GautiKlientaPagalId(int id)
		{
			throw new NotImplementedException();
		}

		public void PridetiKlienta(Klientas klientas)
		{
			throw new NotImplementedException();
		}

		public void AtnaujintiKlienta(Klientas klientas, int id)
		{
			throw new NotImplementedException();
		}

		public void IstrintiKlienta(int id)
		{
			throw new NotImplementedException();
		}





		public List<Nuoma> GautiVisasNuomas()
		{
			string path = "api/Nuoma/GetNuoma";
			HttpResponseMessage response = _httpClient.GetAsync(path).Result;
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = response.Content.ReadAsStringAsync().Result;
				return JsonSerializer.Deserialize<List<Nuoma>>(jsonResponse);
			}
			else
			{
				return new List<Nuoma>();
			}
		}

		public Nuoma GautiNuomaPagalId(int id)
		{
			throw new NotImplementedException();
		}

		public void NuomotiAutomobili(Nuoma nuoma)
		{
			throw new NotImplementedException();
		}

		public void AtnaujintiNuoma(Nuoma nuoma, int id)
		{
			throw new NotImplementedException();
		}

		public void IstrintiNuoma(int id)
		{
			throw new NotImplementedException();
		}
	}
}
