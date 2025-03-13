using DwarfWorkshop5.Models;
using Microsoft.Windows.Management.Deployment;
using System.Threading.Tasks;

namespace DwarfWorkshop5.View;

public partial class Signin : ContentPage
{
    private readonly MyDbContext _mydb;
    private readonly User _user;
	public Signin(MyDbContext mydb, User user)
	{
		InitializeComponent();
        _mydb = mydb;
        _user = user;
	}
    private async void OnLoginClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new LoadingPage("signin", _mydb, _user));
    }

    private async void OnCancelButtonClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}