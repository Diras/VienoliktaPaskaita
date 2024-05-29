using System;
using VienoliktaPaskaita.Services;
using VienoliktaPaskaita.Models;
using VienoliktaPaskaita.Contracts;

namespace VienoliktaPaskaita
{
    public class Program 
    {
        public static void Main(string[] args)
        {

            MainFunkcijos mainFunkcijos = new MainFunkcijos();
            IDatabaseService databaseService = new DatabaseService("Server=DESKTOP-8V5PSN2;Database=DesimtaPaskaita;Integrated Security=True;");

            mainFunkcijos.IsvestiKnygas(databaseService);
            mainFunkcijos.IsvestiKnyguKopija(databaseService);
            mainFunkcijos.IsvestiAutorius(databaseService);

            //Author author1 = new Author("Ernestas", "Rachmangulovas", new DateTime(1990,02,17), "Lietuva");
            Console.WriteLine("Iveskite: Varda, Pavarde, Gimimo data, Sali!");
            //Author author2 = new Author(Console.ReadLine(), Console.ReadLine(), DateTime.Parse(Console.ReadLine()), Console.ReadLine() );
            //databaseService.InsertAuthor(author2);

            mainFunkcijos.IsvestiAutorius(databaseService);

            Console.WriteLine("Iveskite Autoriaus ID kuri norite istrinti!");
            databaseService.DeleteAuthor(int.Parse(Console.ReadLine()));

            mainFunkcijos.IsvestiAutorius(databaseService);


        }
    }

}

