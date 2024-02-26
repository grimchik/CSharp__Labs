namespace Lab1_maui;
using Lab1_maui.Services;
using Lab1_maui.Entities;
public partial class DataBasePage : ContentPage
{
	private readonly SQLiteService _bService = new SQLiteService ();
	public DataBasePage()
	{
        InitializeComponent();
        _bService.Init();
		foreach(var entity in _bService.GetAllCoctails())
		{
            picker.Items.Add(entity.Name);
        }
        
    }
    
}