using AutomobiliuNuoma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Contracts
{
    public interface INuomaService
    {
        void RegistruotiAutomobili(Automobilis automobilis);
        Task<IEnumerable<Automobilis>> GautiVisusAutomobilius();
        Automobilis GautiAutomobiliPagalId(int id);
        IEnumerable<Automobilis> GautiAutomobiliusPagalTipa(string tipas);
        void AtnaujintiAutomobilioInformacija(Automobilis automobilis, int id);
        Task<Automobiliai> GautiAutomobiliusPagalPavadinimaAsync(string pavadinimas);
        void IstrintiAutomobili(int id);
       

        IEnumerable<Klientas> GautiVisusKlientus();
        Task<List<Klientas>> GautiVisusKlientusPagalPavadinima(string pavadinimas);
        Klientas GautiKlientaPagalId(int id);
        void PridetiKlienta(Klientas klientas);
        void AtnaujintiKlienta(Klientas klientas, int id);
        void IstrintiKlienta(int id);


        IEnumerable<Nuoma> GautiVisasNuomas();
        Nuoma GautiNuomaPagalId(int id);
        void NuomotiAutomobili(Nuoma nuoma);
        void AtnaujintiNuoma(Nuoma nuoma, int id);
        void IstrintiNuoma(int id);
        
    }
}
