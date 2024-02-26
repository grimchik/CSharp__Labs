using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_maui.Entities;

namespace Lab1_maui.Services
{
    public interface IDbService
    {
        IEnumerable<Coctail> GetAllCoctails();
        IEnumerable<Ingredient> GetCoctailsIngredients(int id);
        void Init();

    }
}
