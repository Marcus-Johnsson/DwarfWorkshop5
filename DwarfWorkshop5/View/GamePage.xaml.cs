using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.View;

public partial class GamePage : ContentPage
{
    private readonly MyDbContext _mydb;
    private readonly User _user;
    public GamePage(string page, MyDbContext mydb, User user)
    {
        InitializeComponent();
        _mydb = mydb;
        _user = user;
        CallInfo(page);
        BindingContext = new ViewPageModel.GamePageModelViews(_mydb, _user);


    }
    private async void CallInfo(string page)
    {
        if (page == "register")
        {
            await DisplayAlert("Welcome To the WorkShop", "As a starting gift here's some ore's for you.", "Cheers");
        }
        else
        {
            //show offline work
        }
    }
}