using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Repositories;
using AutomobiliuNuoma.Services;
using System;

namespace AutomobiliuNuoma
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-8V5PSN2;Database=AutomobiliuNuoma;Integrated Security=True;";
            IDatabaseRepository repository = new DatabaseRepository(connectionString);
            INuomaService nuomaService = new NuomaService(repository);
            NuomaConsoleUI consoleUI = new NuomaConsoleUI(nuomaService);

            
            consoleUI.Meniu();
        }
    }
}