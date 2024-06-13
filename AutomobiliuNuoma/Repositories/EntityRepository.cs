using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Database;
using AutomobiliuNuoma.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Repositories
{
    public class EntityRepository : IDatabaseRepository
    {
        private NuomaDbContext _dbContext;

        public EntityRepository()
        {
            _dbContext = new NuomaDbContext();
        }

        IEnumerable<Automobilis> IDatabaseRepository.GautiVisusAutomobilius()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Automobilis> IDatabaseRepository.GautiAutomobiliusPagalTipa(string tipas)
        {
            throw new NotImplementedException();
        }

        Automobilis IDatabaseRepository.GautiAutomobiliPagalId(int id)
        {
            throw new NotImplementedException();
        }

        void IDatabaseRepository.PridetiAutomobili(Automobilis automobilis)
        {
            throw new NotImplementedException();
        }

        void IDatabaseRepository.AtnaujintiAutomobili(Automobilis automobilis, int id)
        {
            throw new NotImplementedException();
        }

        void IDatabaseRepository.IstrintiAutomobili(int id)
        {
            throw new NotImplementedException();
        }


        //Klientai

        IEnumerable<Klientas> IDatabaseRepository.GautiVisusKlientus()
        {
            return _dbContext.Klientai;
        }

        IEnumerable<Klientas> IDatabaseRepository.GautiVisusKlientusPagalPavadinima(string pavadinimas)
        {
            return _dbContext.Klientai.Where(k => k.Vardas.ToLower().Contains(pavadinimas.ToLower()) || k.Pavarde.ToLower().Contains(pavadinimas.ToLower()));
        }

        Klientas IDatabaseRepository.GautiKlientaPagalId(int id)
        {
            return _dbContext.Klientai.FirstOrDefault(k => k.Id == id);
        }

        void IDatabaseRepository.PridetiKlienta(Klientas klientas)
        {
            _dbContext.Klientai.Add(klientas);
            _dbContext.SaveChanges();
        }

        void IDatabaseRepository.AtnaujintiKlienta(Klientas klientas, int id)
        {
            
            Klientas esamasKlientas = _dbContext.Klientai.Find(id);
            if (esamasKlientas != null)
            {
                _dbContext.Entry(esamasKlientas).CurrentValues.SetValues(klientas);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Klientas nerastas!");
            }
            
        }

        void IDatabaseRepository.IstrintiKlienta(int id)
        {
            Klientas esamasKlientas = _dbContext.Klientai.Find(id);
            if (esamasKlientas != null)
            {
                _dbContext.Klientai.Remove(esamasKlientas);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Klientas nerastas!");
            }
        }


        //Nuoma

        IEnumerable<Nuoma> IDatabaseRepository.GautiVisasNuomas()
        {
            throw new NotImplementedException();
        }

        Nuoma IDatabaseRepository.GautiNuomaPagalId(int id)
        {
            throw new NotImplementedException();
        }

        void IDatabaseRepository.PridetiNuoma(Nuoma nuoma)
        {
            throw new NotImplementedException();
        }

        void IDatabaseRepository.AtnaujintiNuoma(Nuoma nuoma, int id)
        {
            throw new NotImplementedException();
        }

        void IDatabaseRepository.IstrintiNuoma(int id)
        {
            throw new NotImplementedException();
        }
    }
}
