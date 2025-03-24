using DwarfWorkhop5;
using DwarfWorkshop5.Calculations;
using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.View;

public partial class LoadingPage : ContentPage
{
    private readonly MyDbContext _mydb;
    private readonly User _user;
    private WorkProgress _workProgress;
    private readonly Helpers _helpers;
    private readonly Shop _shop;

    public LoadingPage(string page, MyDbContext mydb, User user, Helpers helpers, WorkProgress workProgress, Shop shop)
    {
		InitializeComponent();
        _workProgress = new WorkProgress();
        _mydb = mydb;
        _user = user;
        _helpers = helpers;

        OnStart(page);

        NavigateToGame(page);
    }
    private async Task NavigateToGame(string page)
    {
        await Task.Delay(100);
        if (page == "register")
        {
            await Navigation.PushAsync(new View.GamePage("register",_mydb,_user, _helpers, _workProgress));
        }
        else
        {
            await Navigation.PushAsync(new View.GamePage("signin",_mydb,_user, _helpers, _workProgress));
        }
    }

    private void OnStart(string page)
    {
        if (page == "Signin")
        {
            double offlineTime = _workProgress.CalculateTime();
            _workProgress.CalculateWorkProgress(offlineTime);
        }
    }
  
}