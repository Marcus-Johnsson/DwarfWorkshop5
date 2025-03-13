using DwarfWorkshop5.Calculations;
using DwarfWorkshop5.Models;
using DwarfWorkshop5.ViewPageModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.Design;
using Windows.Security.EnterpriseData;

namespace DwarfWorkshop5.View;

public partial class LoadingPage : ContentPage
{
    private readonly MyDbContext _mydb;
    private readonly User _user;
    private WorkProgress _workProgress;
    public LoadingPage(string page, MyDbContext mydb, User user)
    {
		InitializeComponent();
        _workProgress = new WorkProgress();
        _mydb = mydb;
        _user = user;

        OnStart(page);

        NavigateToGame(page);
    }
    private async Task NavigateToGame(string page)
    {
        await Task.Delay(100);
        if (page == "register")
        {
            await Navigation.PushAsync(new View.GamePage("register",_mydb,_user));
        }
        else
        {
            await Navigation.PushAsync(new View.GamePage("signin",_mydb,_user));
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        StartWorkTimerAsync();
    }

    private void OnStart(string page)
    {
        if (page == "Signin")
        {
            double offlineTime = _workProgress.CalculateTime();
            _workProgress.CalculateWorkProgress(offlineTime);
        }
    }
    private async void StartWorkTimerAsync()
    {
        await Task.Run(async () =>
            {
                while (true)
                {
                    Device.BeginInvokeOnMainThread(() =>
                        {
                            _workProgress.CalculateWorkProgress(1);
                        });
                    
                    await Task.Delay(1000);
                } 
               
            });
    }
}