using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Repositories;
using AutomobiliuNuoma.Services;
using System;
using MongoDB.Driver;
namespace AutomobiliuNuoma
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-8V5PSN2;Database=AutomobiliuNuoma;Integrated Security=True;";
            string connectionStringMongo = "mongodb+srv://Diras:rgd7840Z@learning.0insxlx.mongodb.net/?retryWrites=true&w=majority&appName=Learning";
            
            

            IMongoClient mongoClient = new MongoClient(connectionStringMongo);
            IMongoDBRepository mongoDBRepository = new MongoDBRepository(mongoClient);

            IDatabaseRepository repository = new DatabaseRepository(connectionString);
            INuomaService nuomaService = new NuomaService(repository, mongoDBRepository);
            NuomaConsoleUI consoleUI = new NuomaConsoleUI(nuomaService);

            consoleUI.Meniu();
        }
    }
}