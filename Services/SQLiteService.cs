using Lab1_maui.Entities;
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
        private List<Coctail> coctails = new List<Coctail>();
        private List<Ingredient> ingredients = new List<Ingredient>();
        public void Init()
        {

        }
    }
}
