using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuNuoma.Services
{
    public class NuomaConsoleUI
    {
        private readonly INuomaService _nuomaService;

        public NuomaConsoleUI(INuomaService nuomaService)
        {
            _nuomaService = nuomaService;
        }

        public void Meniu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Automobilių nuomos sistema");
                Console.WriteLine("1. Pradeti darba su automobiliais");
                Console.WriteLine("2. Pradeti darba su klientais");
                Console.WriteLine("3. Pradeti darba su nuoma");          
                Console.WriteLine("0. Išeiti");
                Console.Write("Pasirinkite opciją: ");

                int pasirinkimas = CheckInput(0,3);

                switch (pasirinkimas)
                {
                    case 1:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Automobilių valdymas");
                            Console.WriteLine("1. Prideti automobili");
                            Console.WriteLine("2. Parodyti visus automobilius");
                            Console.WriteLine("3. Surasti automobili pagal tipa");
                            Console.WriteLine("4. Atnaujinti automobilio informacija");
                            Console.WriteLine("5. Istrinti automobili is sistemos");
                            Console.WriteLine("0. Išeiti");
                            Console.Write("Pasirinkite opciją: ");

                            int number = CheckInput(0,5);

                            switch (number)
                            {
                                case 1:
                                    PridetiAutomobili();
                                    break;
                                case 2:
                                    AtvaizduotiVisusAutomobilius();
                                    break;
                                case 3:
                                    FiltruotiAutomobiliusPagalTipa();
                                    break;
                                case 4:
                                    AtnaujintiAutomobili();
                                    break;
                                case 5:
                                    IstrintiAutomobili();
                                    break;
                                case 0:
                                    break;

                                default:
                                    break;
                            }

                            if (number == 0)
                            {
                                break; // Išeiti iš vidinio while ciklo
                            }

                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();

                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Klientu valdymas");
                            Console.WriteLine("1. Prideti klienta");
                            Console.WriteLine("2. Parodyti visus klientus");
                            Console.WriteLine("3. Atnaujinti klieto informacija");
                            Console.WriteLine("4. Istrinti klienta is sistemos");
                            Console.WriteLine("0. Išeiti");
                            Console.Write("Pasirinkite opciją: ");

                            int number = CheckInput(0, 4);

                            switch (number)
                            {
                                case 1:
                                    PridetiKlienta();
                                    break;
                                case 2:
                                    AtvaizduotiVisusKlientus();
                                    break;
                                case 3:
                                    AtnaujintiKlienta();
                                    break;
                                case 4:
                                    IstrintiKlienta();
                                    break;

                                case 0:
                                    break;

                                default:
                                    break;
                            }

                            if (number == 0)
                            {
                                break; // Išeiti iš vidinio while ciklo
                            }
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Nuomos valdymas");
                            Console.WriteLine("1. Isnuomoti automobili");
                            Console.WriteLine("2. Parodyti nuomos sarasa");
                            Console.WriteLine("3. Atnaujinti nuomos informacija");
                            Console.WriteLine("4. Istrinti nuomos irasa is sistemos");
                            Console.WriteLine("0. Išeiti");
                            Console.Write("Pasirinkite opciją: ");

                            int number = CheckInput(0, 4);

                            switch (number)
                            {
                                case 1:
                                    PridetiNuoma();
                                    break;
                                case 2:
                                    AtvaizduotiVisaNuoma();
                                    break;
                                case 3:
                                    AtnaujintiNuoma();
                                    break;
                                case 4:
                                    IstrintiNuoma();
                                    break;

                                case 0:
                                    break;

                                default:
                                    break;
                            }

                            if (number == 0)
                            {
                                break; // Išeiti iš vidinio while ciklo
                            }
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    
                    case 0:
                        return;
                    default:
                        
                        break;
                }
            }
        }


        private int CheckInput(int nuo, int iki)
        {

            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number) && number >= nuo && number <= iki)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Neteisingas skaicius, pabandykite dar karta!");
                }
            }
        }

        private void PridetiAutomobili()
        {
            Console.WriteLine("Pasirinkite automobilio tipą (1 - Naftos Kuro Automobilis, 2 - Elektromobilis): ");
            int tipas = CheckInput(1,2);

            Console.WriteLine("Įveskite markę: ");
            string marke = Console.ReadLine();

            Console.WriteLine("Įveskite modelį: ");
            string modelis = Console.ReadLine();

            Console.WriteLine("Įveskite metus: ");
            int metai = int.Parse(Console.ReadLine());

            string registracijosNumeris = $"{marke}-{modelis}-{metai}";

            Console.WriteLine("Įveskite paros kaina: ");
            decimal kaina = Decimal.Parse(Console.ReadLine());

            if (tipas == 1)
            {
                Console.WriteLine("Įveskite bako talpą: ");
                int bakoTalpa = int.Parse(Console.ReadLine());

                var naftosKuroAutomobilis = new NaftosKuroAutomobilis(marke, modelis, metai, registracijosNumeris, bakoTalpa, kaina);
                _nuomaService.RegistruotiAutomobili(naftosKuroAutomobilis);
            }
            else if (tipas == 2)
            {
                Console.WriteLine("Įveskite baterijos talpą: ");
                int baterijosTalpa = int.Parse(Console.ReadLine());

                var elektromobilis = new Elektromobilis(marke, modelis, metai, registracijosNumeris, baterijosTalpa, kaina);
                _nuomaService.RegistruotiAutomobili(elektromobilis);
            }
            
        }

        private void AtvaizduotiVisusAutomobilius()
        {
            Console.WriteLine("Visi automobiliai: ");
            List<Automobilis> automobiliuSarasas = _nuomaService.GautiVisusAutomobilius().ToList();
            if(automobiliuSarasas.Count == 0)
            {
                Console.WriteLine("Siuo metu automobiliu nera!");
            }
            else
            {
                foreach (Automobilis automobilis in automobiliuSarasas)
                {
                    if (automobilis is NaftosKuroAutomobilis naftosKuroAutomobilis)
                    {
                        Console.WriteLine(naftosKuroAutomobilis);
                    }
                    else if (automobilis is Elektromobilis elektromobilis)
                    {
                        Console.WriteLine(elektromobilis);
                    }
                    else
                    {
                        Console.WriteLine(automobilis);
                    }
                }
            }
            
        }

        private void FiltruotiAutomobiliusPagalTipa()
        {
            Console.WriteLine("Įveskite automobilio tipą ( 1. NaftosKuroAutomobilis arba 2. Elektromobilis): ");
            int number = CheckInput(1,2);
            string tipas;
            if (number == 1)
            {
                tipas = "NaftosKuroAutomobilis";
            }
            else
            {
                tipas = "Elektromobilis";
            }
            List<Automobilis> automobiliuSarasas = _nuomaService.GautiAutomobiliusPagalTipa(tipas).ToList();

            foreach (Automobilis automobilis in automobiliuSarasas)
            {
                if (automobilis is NaftosKuroAutomobilis naftosKuroAutomobilis)
                {
                    Console.WriteLine(naftosKuroAutomobilis);
                }
                else if (automobilis is Elektromobilis elektromobilis)
                {
                    Console.WriteLine(elektromobilis);
                }
            }
        }

        private void AtnaujintiAutomobili()
        {
            
            AtvaizduotiVisusAutomobilius();

            Console.WriteLine("Įveskite automobilio ID, kurį norite atnaujinti: ");
            int id = int.Parse(Console.ReadLine());
            

            Console.WriteLine("Pasirinktas automobilis: ");
            Automobilis automobilis1 = _nuomaService.GautiAutomobiliPagalId(id);
            if(automobilis1 is NaftosKuroAutomobilis naftosKuroAutomobilis)
            {
                Console.WriteLine(naftosKuroAutomobilis);
            }
            else if(automobilis1 is Elektromobilis elektromobilis)
            {
                Console.WriteLine(elektromobilis); 
            }
            else
            {
                Console.WriteLine(automobilis1);
            }


            Console.WriteLine("Įveskite naują automobilio tipa(1. NaftosKuroAutomobilis arba 2 Elektromobilis): ");
            int number = CheckInput(1,2);
            string tipas;
            if (number == 1)
            {
                tipas = "NaftosKuroAutomobilis";
            }
            else if (number == 2)
            {
                tipas = "Elektromobilis";
            }

            Console.WriteLine("Įveskite naują markę: ");
            string marke = Console.ReadLine();

            Console.WriteLine("Įveskite naują modelį: ");
            string modelis = Console.ReadLine();

            Console.WriteLine("Įveskite naujus metus (1900 iki 2024): ");
            int metai = CheckInput(1900, 2024);

            int talpa = 0;
            if (number == 1)
            {
                Console.WriteLine("Įveskite nauja kuro bako talpa: ");
                talpa = CheckInput(int.MinValue, int.MaxValue);
            }
            else if (number == 2)
            {
                Console.WriteLine("Įveskite nauja baterijos talpa: ");
                talpa = CheckInput(int.MinValue, int.MaxValue);
            }

            string registracijosNumeris = $"{marke}-{modelis}-{metai}";

            Console.WriteLine("Įveskite paros kaina: ");
            decimal kaina = Decimal.Parse(Console.ReadLine());

            Automobilis automobilis = new Automobilis();
            
            if (number == 1)
            {
                automobilis = new NaftosKuroAutomobilis(marke, modelis, metai, registracijosNumeris, talpa, kaina);
            }
            else if (number == 2)
            {
                automobilis = new Elektromobilis(marke, modelis, metai, registracijosNumeris, talpa, kaina);
            }


            _nuomaService.AtnaujintiAutomobilioInformacija(automobilis, id);
        }

        private void IstrintiAutomobili()
        {
            
            AtvaizduotiVisusAutomobilius();

            Console.WriteLine("Įveskite automobilio ID, kurį norite ištrinti: ");
            int id = int.Parse(Console.ReadLine());

            _nuomaService.IstrintiAutomobili(id);
        }


        private void PridetiKlienta()
        {
            Console.WriteLine("Įveskite Varda: ");
            string vardas = Console.ReadLine();

            Console.WriteLine("Įveskite Pavadre: ");
            string pavarde = Console.ReadLine();

            Console.WriteLine("Įveskite gimimo data (yyyy-mm-dd): ");
            DateTime gimimoData = DateTime.Parse(Console.ReadLine());

            DateTime registracijosData = DateTime.Now;

            Klientas klientas = new Klientas(vardas,pavarde,gimimoData, registracijosData);

            _nuomaService.PridetiKlienta(klientas);
        }

        private void AtvaizduotiVisusKlientus()
        {
            Console.WriteLine("Visi klientai: ");
            List<Klientas> klientai = _nuomaService.GautiVisusKlientus().ToList();

            if (klientai.Count == 0)
            {
                Console.WriteLine("Siuo metu klientu nera!");
            }
            else
            {
                foreach (Klientas klientas in klientai)
                {
                    Console.WriteLine(klientas);
                }
            }

            
        }

        private void AtnaujintiKlienta()
        {
            AtvaizduotiVisusKlientus();
            Console.WriteLine("Pasirinkite Id kliento kurio informacija norite atnaujinti: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Pasirinkitas klientas: ");
            Klientas klientas = _nuomaService.GautiKlientaPagalId(number);
            Console.WriteLine(klientas);


            Console.WriteLine("Įveskite nauja Varda: ");
            string vardas = Console.ReadLine();

            Console.WriteLine("Įveskite nauja Pavadre: ");
            string pavarde = Console.ReadLine();

            Console.WriteLine("Įveskite nauja gimimo data (yyyy-mm-dd): ");
            DateTime gimimoData = DateTime.Parse(Console.ReadLine());

            Klientas klientas1 = new Klientas(vardas, pavarde, gimimoData, klientas.RegistracijosData);

            _nuomaService.AtnaujintiKlienta(klientas1, number);
        }

        private void IstrintiKlienta()
        {
            AtvaizduotiVisusKlientus();
            Console.WriteLine("Pasirinkite Id kliento kurio informacija norite atnaujinti: ");
            int number = int.Parse(Console.ReadLine());

            _nuomaService.IstrintiKlienta(number);
        }

        private void PridetiNuoma()
        {
            AtvaizduotiVisusAutomobilius();
            Console.WriteLine("Įveskite automobilio ID, kurį norite išnuomoti: ");
            int automobilioId = int.Parse(Console.ReadLine());

            AtvaizduotiVisusKlientus();
            Console.WriteLine("Įveskite kliento ID: ");
            int klientoId = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite nuomos pradzios datą (YYYY-MM-DD): ");
            DateTime nuomosPradzia = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite nuomos pabaigos datą (YYYY-MM-DD): ");
            DateTime nuomosPabaiga = DateTime.Parse(Console.ReadLine());

            decimal kaina = 0;
            Automobilis automobilis = _nuomaService.GautiAutomobiliPagalId(automobilioId);
            if (automobilis is NaftosKuroAutomobilis naftosKuroAutomobilis)
            {
                kaina = naftosKuroAutomobilis.Kaina;
            }
            if (automobilis is Elektromobilis elektromobilis)
            {
                kaina = elektromobilis.Kaina;
            }

            int days = (int)(nuomosPabaiga - nuomosPradzia).TotalDays;
            decimal suma = kaina *days;

            Nuoma newNuoma = new Nuoma(automobilioId, klientoId, nuomosPradzia, nuomosPabaiga, suma);

            List<Nuoma> sarasas = _nuomaService.GautiVisasNuomas().ToList();
            if(sarasas.Count == 0)
            {
                _nuomaService.NuomotiAutomobili(newNuoma);
            }
            else
            {
                bool automobilisLaisvas = true;

                foreach (Nuoma nuoma in sarasas)
                {
                    if (nuoma.AutomobilioId == automobilioId &&
                        ((nuomosPradzia >= nuoma.NuomosPradzia && nuomosPradzia <= nuoma.GrazinimoData) ||
                         (nuomosPabaiga >= nuoma.NuomosPradzia && nuomosPabaiga <= nuoma.GrazinimoData) ||
                         (nuomosPradzia <= nuoma.NuomosPradzia && nuomosPabaiga >= nuoma.GrazinimoData)))
                    {
                        automobilisLaisvas = false;
                        break;
                    }
                }

                if (automobilisLaisvas)
                {
                    _nuomaService.NuomotiAutomobili(newNuoma);
                    Console.WriteLine("Automobilis sėkmingai išnuomotas.");
                }
                else
                {
                    Console.WriteLine("Automobilis pasirinktu laikotarpiu yra užimtas.");
                }
            }
        }

        private void AtvaizduotiVisaNuoma()
        {
            Console.WriteLine("Nuomos sarasas: ");
            List<Nuoma> sarasas = _nuomaService.GautiVisasNuomas().ToList();

            if (sarasas.Count == 0)
            {
                Console.WriteLine("Sarasas tuscias!");
            }
            else
            {
                foreach (Nuoma nuoma in sarasas)
                {
                    Console.WriteLine(nuoma);
                }
            }
            
        }

        private void AtnaujintiNuoma()
        {
            AtvaizduotiVisaNuoma();
            Console.WriteLine("Pasirinkite Id Nuomos punto kurio nuoma norite pratesti: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Pasirinkitas nuomos irasas: ");
            Nuoma nuoma = _nuomaService.GautiNuomaPagalId(number);
            Console.WriteLine(nuoma);


            Console.WriteLine("Iveskite nauja nuomos pabaigos datą (YYYY-MM-DD): ");
            DateTime naujaPabaiga = DateTime.Parse(Console.ReadLine());

            decimal kaina = 0;
            Automobilis automobilis = _nuomaService.GautiAutomobiliPagalId(number);
            if (automobilis is NaftosKuroAutomobilis naftosKuroAutomobilis)
            {
                kaina = naftosKuroAutomobilis.Kaina;
            }
            if (automobilis is Elektromobilis elektromobilis)
            {
                kaina = elektromobilis.Kaina;
            }

            int days = (int)(naujaPabaiga - nuoma.NuomosPradzia).TotalDays;
            decimal suma = kaina * days;

            Nuoma newNuoma = new Nuoma(nuoma.AutomobilioId, nuoma.KlientoId, nuoma.NuomosPradzia, naujaPabaiga, suma);

            _nuomaService.AtnaujintiNuoma(newNuoma, number);
        }

        private void IstrintiNuoma()
        {
            AtvaizduotiVisaNuoma();
            Console.WriteLine("Pasirinkite Id Nuomos iraso kurio informacija norite atnaujinti: ");
            int number = int.Parse(Console.ReadLine());

            _nuomaService.IstrintiNuoma(number);
        }

        
    }
}
