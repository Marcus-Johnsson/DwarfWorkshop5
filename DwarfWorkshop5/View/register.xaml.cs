using Azure;
using DwarfWorkhop5;
using DwarfWorkshop5.AddToDataBase;
using DwarfWorkshop5.Models;
using Microsoft.Data.SqlClient;

namespace DwarfWorkshop5.View;

public partial class Register : ContentPage
{
    private readonly RegisterUser _registeruser;
    private readonly MyDbContext _mydb;
    private readonly User _user;
    private readonly Helpers _help;
    public Register(MyDbContext mydb,User user, RegisterUser registerUser, Helpers helpers)
    {
        InitializeComponent();
        _user = user;
        _mydb = mydb;
        _registeruser = registerUser;
        _help = helpers;
       
    }

    private async void OnCreateAccountClicked(System.Object sender, System.EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntryFirst.Text;
        _registeruser.CreateNewUserStep1(username, password);

        await Navigation.PushAsync(new View.LoadingPage("register", _mydb,_user, _help));
    }

    private async void OnCancelClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(_mydb,_user, _registeruser, _help));
    }

    private async void OnUserNameTextChanged(object sender, TextChangedEventArgs e)
    {
        string username = UsernameEntry.Text;

        if (string.IsNullOrWhiteSpace(username))
        {
            AvailableLabelUsername.Text = "";
            CreateAccount.IsEnabled = false;
            return;
        }

        bool isAvailable = await Helpers.CheckUsername(username);

        if (isAvailable)
        {
            AvailableLabelUsername.Text = "Username is available";
            AvailableLabelUsername.TextColor = Colors.Green;
            CreateAccount.IsEnabled = true;
        }
        else
        {
            AvailableLabelUsername.Text = "Username is taken";
            AvailableLabelUsername.TextColor = Colors.Red;
            CreateAccount.IsEnabled = false;
        }
    }


    private async void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
    {
        if (PasswordEntryFirst == null || PasswordEntrySecound == null || AvailableLabelPassword == null)
        {
            return;
        }
        string firstPassword = PasswordEntryFirst.Text;
        string secondPassword = PasswordEntrySecound.Text;

        if (string.IsNullOrWhiteSpace(firstPassword) || string.IsNullOrWhiteSpace(secondPassword))
        {
            AvailableLabelPassword.Text = "";
            CreateAccount.IsEnabled = false;
        }
        await Task.Delay(500);
        if (firstPassword == secondPassword)
        {
            AvailableLabelPassword.Text = "Password match";
            AvailableLabelPassword.TextColor = Colors.Green;
            CreateAccount.IsEnabled = true;
        }
        else
        {
            AvailableLabelPassword.Text = "Password does not match";
            AvailableLabelPassword.TextColor = Colors.Red;
            CreateAccount.IsEnabled = false;
        }

    }
}
