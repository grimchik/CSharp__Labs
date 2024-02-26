using Lab1_maui.Entities;
using System;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Lab1_maui.Services
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection database;
        public IEnumerable<Ingredient> GetCoctailsIngredients(int id)
        {
            return database.Table<Ingredient>().Where(ingredient => ingredient.CourseId == id).ToList();
        }
        public IEnumerable<Coctail> GetAllCoctails()
        {
            return database.Table<Coctail>().ToList();
        }
        public void Init()
        {
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbFile = Path.Combine(path, "mydbSQLite.db3");
            database = new SQLiteConnection(dbFile,SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            database.DropTable<Coctail>();
            database.DropTable<Ingredient>();
            database.CreateTable<Coctail>();
           
            List<Coctail> coctails = new List<Coctail>
            {
            new Coctail { Name = "Coctail1", Type = "Type1" },
            new Coctail { Name = "Coctail2", Type = "Type2" },
            };
            foreach (var coctail in coctails)
            {
                database.Insert(coctail);
            }
            database.CreateTable<Ingredient>();
            for (int i = 1; i <= 2; i++) 
            {
                for (int j = 1; j <= 5; j++) 
                {
                    Ingredient ingredient = new Ingredient
                    {
                        Name = $"Ingredient{j} for Coctail{i}",
                        Volume = $"{j * 10} ml",
                        CourseId = i 
                    };
                    database.Insert(ingredient);
                }
            }
        }
    }
}
