using AutomobiliuNuoma.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AutomobiliuNuoma.Contracts
{
    public interface IMongoDBRepository
    {
        Task<List<Automobilis>> GetAllAutomobiliai();
        Task AddAutomobilis(Automobilis automobilis);
        Task AddAllAutomobiliai(List<Automobilis> automobiliai);
        Task DeleteAllAutomobiliai();


        //Klientai
        Task<List<Klientas>> GetAllKlientai();
        Task<List<Klientas>> GetKlientaiPagalPavadinima(string pavadinimas);
        Task AddKlientas(Klientas klientas);
        Task AddAllKlientai(List<Klientas> klientai);

    }
}