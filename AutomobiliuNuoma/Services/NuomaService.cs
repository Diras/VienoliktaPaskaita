using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;
using Serilog;

namespace AutomobiliuNuoma.Services
{
    public class NuomaService : INuomaService
    {
        private readonly IDatabaseRepository _repository;
        private readonly IMongoDBRepository _mongoDBRepository;

        public NuomaService(IDatabaseRepository repository, IMongoDBRepository mongoDBRepository)
        {
            _repository = repository;
            _mongoDBRepository = mongoDBRepository;
            ICacheControlService cacheControlService = new CacheControlService(_mongoDBRepository);
            cacheControlService.Start();
        }

        public async Task<IEnumerable<Automobilis>> GautiVisusAutomobilius()
        {
            Log.Information("Uzklausa - Gauti visus auto is MongoDB");
            try
            {
                List<Automobilis> automobiliai = await _mongoDBRepository.GetAllAutomobiliai();
                if (automobiliai == null || !automobiliai.Any())
                {
                    Log.Information("MongoDB automobiliu saraso neturi, kreipiames i SQL");
                    automobiliai = _repository.GautiVisusAutomobilius().ToList();

                    await _mongoDBRepository.AddAllAutomobiliai(automobiliai);
                }

                return automobiliai;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Klaida teikiant uzklausa gauti visus auto is duomenu bazes");
                throw;
            }
            

            
        }
        public Automobilis GautiAutomobiliPagalId(int id)
        {
            return _repository.GautiAutomobiliPagalId(id);
        }
        public IEnumerable<Automobilis> GautiAutomobiliusPagalTipa(string tipas)
        {
            return _repository.GautiAutomobiliusPagalTipa(tipas);
        }
        public async void RegistruotiAutomobili(Automobilis automobilis)
        {
            _repository.PridetiAutomobili(automobilis);
            await _mongoDBRepository.AddAutomobilis(automobilis);
        }
        public void AtnaujintiAutomobilioInformacija(Automobilis automobilis, int id)
        {
            _repository.AtnaujintiAutomobili(automobilis, id);
        }

        public async Task<Automobiliai> GautiAutomobiliusPagalPavadinimaAsync(string pavadinimas)
        {
            IEnumerable<Automobilis> automobiliai = await GautiVisusAutomobilius();

            List<Elektromobilis> elektromobiliai = automobiliai.OfType<Elektromobilis>().ToList();
            List<NaftosKuroAutomobilis> naftosKuroAutomobiliai = automobiliai.OfType<NaftosKuroAutomobilis>().ToList();
            Automobiliai result = new Automobiliai();

            foreach (var item in elektromobiliai)
            {
                if (item.Modelis.Contains(pavadinimas, StringComparison.OrdinalIgnoreCase) || item.Marke.Contains(pavadinimas, StringComparison.OrdinalIgnoreCase))
                {
                    result.elektromobiliai.Add(item);
                }
            }

            foreach (var item in naftosKuroAutomobiliai)
            {
                if (item.Modelis.Contains(pavadinimas, StringComparison.OrdinalIgnoreCase) || item.Marke.Contains(pavadinimas, StringComparison.OrdinalIgnoreCase))
                {
                    result.naftosKuroAutomobiliai.Add(item);
                }
            }

            return result;
        }

        public void IstrintiAutomobili(int id)
        {
            _repository.IstrintiAutomobili(id);
        }




        public IEnumerable<Klientas> GautiVisusKlientus()
        {
            return _repository.GautiVisusKlientus();
        }

        public async Task<List<Klientas>> GautiVisusKlientusPagalPavadinima(string pavadinimas)
        {
            List<Klientas> klientai = await _mongoDBRepository.GetKlientaiPagalPavadinima(pavadinimas);

            if (klientai == null || !klientai.Any())
            {
                klientai = _repository.GautiVisusKlientusPagalPavadinima(pavadinimas).ToList();
                await _mongoDBRepository.AddAllKlientai(klientai);
            }

            return klientai;
        }

        public Klientas GautiKlientaPagalId(int id)
        {
            return _repository.GautiKlientaPagalId(id);
        }
        public void PridetiKlienta(Klientas klientas)
        {
            _repository.PridetiKlienta(klientas);
        }
        public void AtnaujintiKlienta(Klientas klientas, int id)
        {
            _repository.AtnaujintiKlienta(klientas, id);
        }
        public void IstrintiKlienta(int id)
        {
            _repository.IstrintiKlienta(id);
        }




        public IEnumerable<Nuoma> GautiVisasNuomas()
        {
            return _repository.GautiVisasNuomas();
        }
        public Nuoma GautiNuomaPagalId(int id)
        {
            return _repository.GautiNuomaPagalId(id);
        }
        public void NuomotiAutomobili(Nuoma nuoma)
        {
            _repository.PridetiNuoma(nuoma);
        }
        public void AtnaujintiNuoma(Nuoma nuoma, int id)
        {
            _repository.AtnaujintiNuoma(nuoma, id);
        }
        public void IstrintiNuoma(int id)
        {
            _repository.IstrintiNuoma(id);
        }
    }
}
