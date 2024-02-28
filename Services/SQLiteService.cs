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
        public IEnumerable<Ingredient> GetCocktailsIngredients(int id)
        {
            return database.Table<Ingredient>().Where(ingredient => ingredient.CourseId == id).ToList();
        }
        public IEnumerable<Cocktail> GetAllCocktails()
        {
            return database.Table<Cocktail>().ToList();
        }
        public void Init()
        {
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbFile = Path.Combine(path, "mydbSQLite.db3");
            database = new SQLiteConnection(dbFile,SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            database.DropTable<Cocktail>();
            database.DropTable<Ingredient>();
            database.CreateTable<Cocktail>();
           
            List<Cocktail> coctails = new List<Cocktail>
            {
            new Cocktail { Name = "Cocktail1", Type = "Type1" },
            new Cocktail { Name = "Cocktail2", Type = "Type2" },
            };
            foreach (var coctail in coctails)
            {
                database.Insert(coctail);
            }
            database.CreateTable<Ingredient>();
            for (int i = 0; i <= 1; i++) 
            {
                for (int j = 1; j <= 5; j++) 
                {
                    Ingredient ingredient = new Ingredient
                    {
                        Name = $"Ingredient{j} for Cocktail{i+1}",
                        Volume = $"{j * 10} ml",
                        CourseId = i 
                    };
                    database.Insert(ingredient);
                }
            }
        }
    }
}
