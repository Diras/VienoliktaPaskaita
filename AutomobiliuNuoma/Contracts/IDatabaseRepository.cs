using AutomobiliuNuoma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Contracts
{
    public interface IDatabaseRepository
    {
        // Automobilių operacijos
        IEnumerable<Automobilis> GautiVisusAutomobilius();
        IEnumerable<Automobilis> GautiAutomobiliusPagalTipa(string tipas);
        Automobilis GautiAutomobiliPagalId(int id);
        void PridetiAutomobili(Automobilis automobilis);
        void AtnaujintiAutomobili(Automobilis automobilis, int id);
        void IstrintiAutomobili(int id);


        // Klientų operacijos
        IEnumerable<Klientas> GautiVisusKlientus();
        Klientas GautiKlientaPagalId(int id);
        void PridetiKlienta(Klientas klientas);
        void AtnaujintiKlienta(Klientas klientas, int id);
        void IstrintiKlienta(int id);


        // Nuomos operacijos
        IEnumerable<Nuoma> GautiVisasNuomas();
        Nuoma GautiNuomaPagalId(int id);
        void PridetiNuoma(Nuoma nuoma);
        void AtnaujintiNuoma(Nuoma nuoma, int id);
        void IstrintiNuoma(int id);
    }
}
