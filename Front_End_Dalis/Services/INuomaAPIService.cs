using AutomobiliuNuoma.Models;


namespace Front_End_Dalis.Services
{
    public interface INuomaAPIService
    {
		Automobiliai GautiVisusAutomobilius();
        Automobilis GautiAutomobiliPagalId(int id);
		List<Elektromobilis> FiltruotiAutomobiliusPagalElektro(string tipas);
		List<NaftosKuroAutomobilis> FiltruotiAutomobiliusPagalNaftos(string tipas);
		Task<Automobiliai> GautiAutomobiliusPagalPavadinimaAsync(string pavadinimas);
		Task AtnaujintiElektromobili(int id, Elektromobilis elektromobilis);
		Task AtnaujintiNaftosKuroAutomobili(int id, NaftosKuroAutomobilis naftosKuroAutomobilis);
        void IstrintiAutomobili(int id);



		List<Klientas> GautiVisusKlientus();
		Task<List<Klientas>> GautiKlientusPagalPavadinima(string pavadinimas);


        Klientas GautiKlientaPagalId(int id);
		void PridetiKlienta(Klientas klientas);
		void AtnaujintiKlienta(Klientas klientas, int id);
		void IstrintiKlienta(int id);


		List<Nuoma> GautiVisasNuomas();
		Nuoma GautiNuomaPagalId(int id);
		void NuomotiAutomobili(Nuoma nuoma);
		void AtnaujintiNuoma(Nuoma nuoma, int id);
		void IstrintiNuoma(int id);
	}
}