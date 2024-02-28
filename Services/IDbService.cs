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
        IEnumerable<Cocktail> GetAllCocktails();
        IEnumerable<Ingredient> GetCocktailsIngredients(int id);
        void Init();

    }
}
