using AutomobiliuNuoma.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using AutomobiliuNuoma.Models;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace AutomobiliuNuoma.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;
        
        public DatabaseRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        #region Automobilių operacijos
        public IEnumerable<Automobilis> GautiVisusAutomobilius()
        {
           
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT 
                    A.Id, 
                    A.Marke, 
                    A.Modelis, 
                    A.Metai, 
                    A.RegistracijosNumeris, 
                    N.BakoTalpa,
                    E.BaterijosTalpa,
                    APK.Kaina
                FROM Automobiliai A
                LEFT JOIN NaftosKuroAutomobiliai N ON A.Id = N.Id
                LEFT JOIN Elektromobiliai E ON A.Id = E.Id
                LEFT JOIN AutomobiliuParosKaina APK ON A.Id = APK.Id
                ";
                var queryResult = db.Query<dynamic>(sql);

                List<Automobilis> automobiliai = new List<Automobilis>();

                foreach (var row in queryResult)
                {
                    if (row.BakoTalpa != null)
                    {
                        automobiliai.Add(new NaftosKuroAutomobilis(row.Id, row.Marke, row.Modelis, row.Metai, row.RegistracijosNumeris, row.BakoTalpa, decimal.Parse(row.Kaina.ToString(), CultureInfo.GetCultureInfo("lt-LT"))));
                    }
                    else if (row.BaterijosTalpa != null)
                    {
                        automobiliai.Add(new Elektromobilis(row.Id, row.Marke, row.Modelis, row.Metai, row.RegistracijosNumeris, row.BaterijosTalpa, decimal.Parse(row.Kaina.ToString(), CultureInfo.GetCultureInfo("lt-LT"))));
                    }
                    else
                    {
                        automobiliai.Add(new Automobilis(row.Id, row.Marke, row.Modelis, row.Metai, row.RegistracijosNumeris));
                    }
                }

                return automobiliai;
            }
        }
        public IEnumerable<Automobilis> GautiAutomobiliusPagalTipa(string tipas)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "";

                if (tipas == "NaftosKuroAutomobilis")
                {
                    sql = @"
                SELECT 
                    A.Id, 
                    A.Marke, 
                    A.Modelis, 
                    A.Metai, 
                    A.RegistracijosNumeris, 
                    N.BakoTalpa,
                    APK.Kaina
                FROM Automobiliai A
                LEFT JOIN NaftosKuroAutomobiliai N ON A.Id = N.Id
                LEFT JOIN AutomobiliuParosKaina APK ON A.Id = APK.Id
            ";

                    var queryResult = db.Query<dynamic>(sql);
                    List<NaftosKuroAutomobilis> result = new List<NaftosKuroAutomobilis>();

                    foreach (var row in queryResult)
                    {
                        if(row.BakoTalpa != null)
                        {
                            NaftosKuroAutomobilis automobilis = new NaftosKuroAutomobilis(
                            row.Id,
                            row.Marke,
                            row.Modelis,
                            row.Metai,
                            row.RegistracijosNumeris,
                            row.BakoTalpa,
                            decimal.Parse(row.Kaina.ToString(), CultureInfo.GetCultureInfo("lt-LT"))
                            );
                            result.Add(automobilis);
                        
                        }
                        
                        
                    }
                    return result;
                }
                else if (tipas == "Elektromobilis")
                {
                    sql = @"
                SELECT 
                    A.Id, 
                    A.Marke, 
                    A.Modelis, 
                    A.Metai, 
                    A.RegistracijosNumeris, 
                    E.BaterijosTalpa,
                    APK.Kaina
                FROM Automobiliai A
                LEFT JOIN Elektromobiliai E ON A.Id = E.Id
                LEFT JOIN AutomobiliuParosKaina APK ON A.Id = APK.Id
            ";

                    var queryResult = db.Query<dynamic>(sql);
                    List<Elektromobilis> result = new List<Elektromobilis>();

                    foreach (var row in queryResult)
                    {
                        if (row.BaterijosTalpa != null)
                        {
                            Elektromobilis automobilis = new Elektromobilis(
                            row.Id,
                            row.Marke,
                            row.Modelis,
                            row.Metai,
                            row.RegistracijosNumeris,
                            row.BaterijosTalpa,
                            decimal.Parse(row.Kaina.ToString(), CultureInfo.GetCultureInfo("lt-LT"))
                            );
                            result.Add(automobilis);
                        }
                    }
                    return result;
                }

                return Enumerable.Empty<Automobilis>();
            }
        }
        public Automobilis GautiAutomobiliPagalId(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
            SELECT 
                A.Id, 
                A.Marke, 
                A.Modelis, 
                A.Metai, 
                A.RegistracijosNumeris, 
                N.BakoTalpa,
                E.BaterijosTalpa,
                APK.Kaina
            FROM Automobiliai A
            LEFT JOIN NaftosKuroAutomobiliai N ON A.Id = N.Id
            LEFT JOIN Elektromobiliai E ON A.Id = E.Id
            LEFT JOIN AutomobiliuParosKaina APK ON A.Id = APK.Id
            WHERE A.Id = @id
            ";

                var queryResult = db.Query<dynamic>(sql, new { id });

                Automobilis automobilis = new Automobilis();

                foreach (var row in queryResult)
                {
                    if (row.BakoTalpa != null)
                    {
                        automobilis = new NaftosKuroAutomobilis(row.Id, row.Marke, row.Modelis, row.Metai, row.RegistracijosNumeris, row.BakoTalpa, decimal.Parse(row.Kaina.ToString(), CultureInfo.GetCultureInfo("lt-LT")));
                    }
                    else if (row.BaterijosTalpa != null)
                    {
                        automobilis = new Elektromobilis(row.Id, row.Marke, row.Modelis, row.Metai, row.RegistracijosNumeris, row.BaterijosTalpa, decimal.Parse(row.Kaina.ToString(), CultureInfo.GetCultureInfo("lt-LT")));
                    }
                    else
                    {
                        automobilis = new Automobilis(row.Id, row.Marke, row.Modelis, row.Metai, row.RegistracijosNumeris);
                    }
                }

                return automobilis;

                
            }
        }
        public void PridetiAutomobili(Automobilis automobilis)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                const string sql = "INSERT INTO Automobiliai (Marke, Modelis, Metai, RegistracijosNumeris) " +
                                   "VALUES (@Marke, @Modelis, @Metai, @RegistracijosNumeris)";
                db.Execute(sql, automobilis);

                const string sqlTop = "SELECT TOP 1 Id FROM Automobiliai ORDER BY Id DESC";
                int newId = db.QuerySingle<int>(sqlTop);

                if (automobilis is NaftosKuroAutomobilis naftosKuroAutomobilis)
                {
                    const string sqlNafta = "INSERT INTO NaftosKuroAutomobiliai (Id, BakoTalpa) " +
                                   "VALUES (@Id, @Bakotalpa)";
                    db.Execute(sqlNafta, new { Id = newId, naftosKuroAutomobilis.BakoTalpa });

                    const string sqlKaina = "INSERT INTO AutomobiliuParosKaina (Id, Kaina) " +
                   "VALUES (@Id, @Kaina)";
                    db.Execute(sqlKaina, new { Id = newId, naftosKuroAutomobilis.Kaina });
                }
                else if (automobilis is Elektromobilis elektromobilis)
                {
                    const string sqlElektra = "INSERT INTO Elektromobiliai (Id, BaterijosTalpa) " +
                                   "VALUES (@Id, @BaterijosTalpa)";
                    db.Execute(sqlElektra, new { Id = newId, elektromobilis.BaterijosTalpa });

                    const string sqlKaina = "INSERT INTO AutomobiliuParosKaina (Id, Kaina) " +
                   "VALUES (@Id, @Kaina)";
                    db.Execute(sqlKaina, new { Id = newId, elektromobilis.Kaina });
                }
            }
        }
        public void AtnaujintiAutomobili(Automobilis automobilis, int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                const string sql = "UPDATE Automobiliai " +
                    "SET Marke = @Marke, Modelis = @Modelis, Metai = @Metai, RegistracijosNumeris = @RegistracijosNumeris " +
                    "WHERE Id = @Id";

                db.Execute(sql, new {automobilis.Marke, automobilis.Modelis, automobilis.Metai, automobilis.RegistracijosNumeris, Id = id });

                

                if (automobilis is NaftosKuroAutomobilis naftosKuroAutomobilis)
                {
                    const string sqlNafta = "UPDATE NaftosKuroAutomobiliai " +
                        "SET BakoTalpa = @Bakotalpa " +
                        "WHERE Id = @Id";
                    db.Execute(sqlNafta, new { naftosKuroAutomobilis.BakoTalpa, Id = id});

                    const string sqlKaina = "UPDATE AutomobiliuParosKaina " +
                        "SET Id = @Id, Kaina = @Kaina " +
                        "WHERE Id = @Id";
                    db.Execute(sqlKaina, new { Id = id, naftosKuroAutomobilis.Kaina });
                }
                else if (automobilis is Elektromobilis elektromobilis)
                {
                    const string sqlElektra = "UPDATE Elektromobiliai " +
                        "SET BaterijosTalpa = @BaterijosTalpa " +
                        "WHERE Id = @Id";
                    db.Execute(sqlElektra, new { elektromobilis.BaterijosTalpa, Id = id});

                    const string sqlKaina = "UPDATE AutomobiliuParosKaina " +
                        "SET Id = @Id, Kaina = @Kaina " +
                        "WHERE Id = @Id";
                    db.Execute(sqlKaina, new { Id = id, elektromobilis.Kaina });
                }
            }
        }
        public void IstrintiAutomobili(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                Automobilis automobilis = GautiAutomobiliPagalId(id);

                

                if (automobilis is NaftosKuroAutomobilis)
                {
                    const string sqlNafta = "DELETE FROM NaftosKuroAutomobiliai WHERE Id = @Id";
                    db.Execute(sqlNafta, new { Id = id });

                    const string sqlKaina = "DELETE FROM AutomobiliuParosKaina WHERE Id = @Id";
                    db.Execute(sqlKaina, new { Id = id });
                }
                else if (automobilis is Elektromobilis)
                {
                    const string sqlElektra = "DELETE FROM Elektromobiliai WHERE Id = @Id";
                    db.Execute(sqlElektra, new { Id = id });

                    const string sqlKaina = "DELETE FROM AutomobiliuParosKaina WHERE Id = @Id";
                    db.Execute(sqlKaina, new { Id = id });
                }

                const string sql = "DELETE FROM Automobiliai WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }
        #endregion

        #region Klientų operacijos

        public IEnumerable<Klientas> GautiVisusKlientus()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"SELECT * FROM Klientai";
                return db.Query<Klientas>(sql);
            }
        }


        public IEnumerable<Klientas> GautiVisusKlientusPagalPavadinima(string pavadinimas)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"SELECT * FROM Klientai WHERE Vardas LIKE @Pavadinimas OR Pavarde LIKE @Pavadinimas";
                return db.Query<Klientas>(sql, new { Pavadinimas = "%" + pavadinimas + "%" });
            }
        }
        public Klientas GautiKlientaPagalId(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"SELECT * FROM Klientai WHERE Id = @id";
                return db.QuerySingleOrDefault<Klientas>(sql, new { id });
            }
        }
        public void PridetiKlienta(Klientas klientas)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO Klientai (Vardas, Pavarde, GimimoData, RegistracijosData) " +
                    "VALUES (@Vardas, @Pavarde, @GimimoData, @RegistracijosData)";

                db.Execute(sql, klientas);
            }
        }
        public void AtnaujintiKlienta(Klientas klientas, int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Klientai SET " +
                    "Vardas = @Vardas, " +
                    "Pavarde = @Pavarde, " +
                    "GimimoData = @GimimoData, " +
                    "RegistracijosData = @RegistracijosData " +
                    "WHERE Id = @Id";

                db.Execute(sql, new { klientas.Vardas, klientas.Pavarde, klientas.GimimoData, klientas.RegistracijosData, Id = id });
            }
        }
        public void IstrintiKlienta(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "DELETE FROM Klientai WHERE Id = @Id";

                db.Execute(sql, new { Id = id });
            }
        }

        #endregion

        #region  Nuomos operacijos
        public IEnumerable<Nuoma> GautiVisasNuomas()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT
                    N.Id,
                    N.AutomobilioId,
                    N.KlientoId,
                    N.NuomosData,
                    N.GrazinimoData,
                    S.Suma  
                FROM Nuoma N
                LEFT JOIN Saskaitos S ON N.Id = S.NuomosId
                ";
                var results = db.Query<dynamic>(sql);

                List<Nuoma> nuomos = new List<Nuoma>();
                foreach (var row in results)
                {
                    Nuoma nuoma = new Nuoma(row.Id, row.AutomobilioId, row.KlientoId, row.NuomosData, row.GrazinimoData, decimal.Parse(row.Suma.ToString(), CultureInfo.GetCultureInfo("lt-LT")));
                    nuomos.Add(nuoma);
                }

                return nuomos;
            }
        }
        public Nuoma GautiNuomaPagalId(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT
                    N.Id,
                    N.AutomobilioId,
                    N.KlientoId,
                    N.NuomosData,
                    N.GrazinimoData,
                    S.Suma  
                FROM Nuoma N
                LEFT JOIN Saskaitos S ON N.Id = S.NuomosId
                WHERE N.Id = @Id
                ";
                var results = db.Query<dynamic>(sql, new { Id = id} );

                foreach (var row in results)
                {
                    Nuoma nuoma = new Nuoma(row.Id, row.AutomobilioId, row.KlientoId, row.NuomosData, row.GrazinimoData, decimal.Parse(row.Suma.ToString(), CultureInfo.GetCultureInfo("lt-LT")));
                    return nuoma;
                }

                return null;
            }
        }
        public void PridetiNuoma(Nuoma nuoma)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO Nuoma (AutomobilioId, KlientoId, NuomosData, GrazinimoData) " +
                    "VALUES (@AutomobilioId, @KlientoId, @NuomosPradzia, @GrazinimoData); " +
                    "SELECT SCOPE_IDENTITY();";

                int Id = db.ExecuteScalar<int>(sql, new { nuoma.AutomobilioId, nuoma.KlientoId, nuoma.NuomosPradzia, nuoma.GrazinimoData });

                const string sqlSaskaita = "INSERT INTO Saskaitos (NuomosId, Suma) " +
                    "VALUES (@NuomosId, @Suma)";

                db.Execute(sqlSaskaita, new { NuomosId = Id, nuoma.Suma });
            }
        }
        public void AtnaujintiNuoma(Nuoma nuoma, int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Nuoma SET " +
                    "AutomobilioId = @AutomobilioId, " +
                    "KlientoId = @KlientoId, " +
                    "NuomosData = @NuomosPradzia, " +
                    "GrazinimoData = @GrazinimoData " +
                    "WHERE Id = @Id";

                db.Execute(sql, new { nuoma.AutomobilioId, nuoma.KlientoId, nuoma.NuomosPradzia, nuoma.GrazinimoData, Id = id });

                const string sqlSaskaita = "UPDATE Saskaitos SET " +
                    "Suma = @Suma " +
                    "WHERE NuomosId = @NuomosId";

                db.Execute(sqlSaskaita, new { NuomosId = id, nuoma.Suma });
            }
        }
        public void IstrintiNuoma(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                

                const string sqlSaskaita = "DELETE FROM Saskaitos WHERE NuomosId = @Id";

                db.Execute(sqlSaskaita, new { Id = id });

                const string sql = "DELETE FROM Nuoma WHERE Id = @Id";

                db.Execute(sql, new { Id = id });
            }
        }

        #endregion
    }
}
