namespace Lab1_maui;
using Lab1_maui.Services;
using Lab1_maui.Entities;
public partial class DataBasePage : ContentPage
{
	private readonly IDbService _bService;
	public DataBasePage(IDbService dbService)
	{
        InitializeComponent();
        _bService = dbService;
        _bService.Init();
		foreach(var entity in _bService.GetAllCocktails())
		{
            picker.Items.Add(entity.Name);
        }
        
    }
    
    private void picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Cocktail> list = _bService.GetAllCocktails().ToList();
        string str = picker.SelectedItem.ToString();
        int index = 0;
        foreach (Cocktail cocktail in list)
        {
            if (cocktail.Name == str)
            {
                break;
            }
            index++;
        }
        List<Ingredient> ingredients = _bService.GetCocktailsIngredients(index).ToList();
        List<string> ingredientNames = new List<string>();
        foreach (Ingredient ingredient in ingredients)
        {
            ingredientNames.Add(ingredient.Name);
        }
        Collection.ItemsSource = ingredientNames;
    }
}