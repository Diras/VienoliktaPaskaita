using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Services
{
    public class NuomaService : INuomaService
    {
        private readonly IDatabaseRepository _repository;

        public NuomaService(IDatabaseRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Automobilis> GautiVisusAutomobilius()
        {
            return _repository.GautiVisusAutomobilius();
        }
        public Automobilis GautiAutomobiliPagalId(int id)
        {
            return _repository.GautiAutomobiliPagalId(id);
        }
        public IEnumerable<Automobilis> GautiAutomobiliusPagalTipa(string tipas)
        {
            return _repository.GautiAutomobiliusPagalTipa(tipas);
        }
        public void RegistruotiAutomobili(Automobilis automobilis)
        {
            _repository.PridetiAutomobili(automobilis);
        }
        public void AtnaujintiAutomobilioInformacija(Automobilis automobilis, int id)
        {
            _repository.AtnaujintiAutomobili(automobilis, id);
        }
        public void IstrintiAutomobili(int id)
        {
            _repository.IstrintiAutomobili(id);
        }




        public IEnumerable<Klientas> GautiVisusKlientus()
        {
            return _repository.GautiVisusKlientus();
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
