using DwarfWorkhop5;
using DwarfWorkshop5.AddToDataBase;
using DwarfWorkshop5.Models;


namespace DwarfWorkshop5.View;

public partial class Signin : ContentPage
{
    private Helpers _helpers;
    private readonly MyDbContext _mydb;
    private readonly User _user;
    private readonly RegisterUser _registerUser;
    public Signin(MyDbContext mydb, User user, RegisterUser registerUser)
    {
        InitializeComponent();
        _mydb = mydb;
        _user = user;
        _helpers = new Helpers(_mydb);
        _registerUser = registerUser;
    }
    private async void OnLoginClicked(System.Object sender, System.EventArgs e)
    {
        await _helpers.SignInUser(SignInUsername.Text, SignInPassword.Text);

        if (await _helpers.SignInUser(SignInUsername.Text, SignInPassword.Text))
        {
            await Navigation.PushAsync(new LoadingPage("signin", _mydb, _user, _helpers));
        }
        else
        {
            await DisplayAlert("Error", "No valid inputs", "Again");
        }        
    }

    private async void OnCancelButtonClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}