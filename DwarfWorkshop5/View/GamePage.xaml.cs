using DwarfWorkhop5;
using DwarfWorkshop5.Models;


using Microsoft.Maui.Handlers;
using System.Collections.Generic;
using DwarfWorkshop5.DesignPattern;
using CustomButtonHandler = DwarfWorkshop5.DesignPattern.ButtonHandler;
using DwarfWorkshop5.ViewPageModel;
using WinRT.DwarfWorkshop5VtableClasses;
using DwarfWorkshop5.DataCheck;
using Microsoft.Identity.Client;
using DwarfWorkshop5.Calculations;


namespace DwarfWorkshop5.View;

public partial class GamePage : ContentPage
{
    private readonly MyDbContext _mydb;
    private readonly Helpers _helpers;
    private readonly UserSession _session;
    private User? _currentUser;
    private readonly WorkProgress _workProgress;
    
       

    public GamePage(string page, MyDbContext mydb, User user, Helpers helpers, WorkProgress workProgress)
    {
        _session = UserSession.GetInstance();
        _currentUser = _session.GetCurrentUser();
        _workProgress = workProgress;

        InitializeComponent();
        _mydb = mydb;
        _helpers = helpers;
        
        BindingContext = new GamePageModelViews(_mydb);

        Username.Text = _currentUser.Username;
        CheckBuyDwarfButton();
        CallInfo(page);
        StartWorking();
    }     
    private async void CallInfo(string page)
    {
        if (page == "register")
        {
            await DisplayAlert("Khuzdul-ûk aulë nîd", "Khalûk ulûk yâna dâra.", "Drink beer");
            await DisplayAlert("Ten beers later", "Well, now that you can understand me. Here is an starting gift there's some ore and some tokens, go and get your first worker and get him to work!", "Cheers");
        }
        else
        {
            //show offline work
        }
    }

    private void OnJewelryClicked(object sender, EventArgs e)
    {

    }

    private void OnOreClicked(object sender, EventArgs e)
    {

    }

    private void OnGemsClicked(object sender, EventArgs e)
    {

    }

    private void OnMaterialClicked(object sender, EventArgs e)
    {

    }

    private void CheckBuyDwarfButton()
    {
        if(!_helpers.CheckDwarfAvailable().Result)
        {
            BuyDwarf.IsVisible = false;
        }
    }

   



    private void OnDwarfSelected(object sender, SelectionChangedEventArgs e)
    {

    }

    private void OnEffifencyRankBoughtClicked(object sender, EventArgs e)
    {

    }

    private void OnTokenRankBoughtClicked(object sender, EventArgs e)
    {

    }

    private void OnQualityRankBoughtClicked(object sender, EventArgs e)
    {

    }

    private void OnBuyLvlClicked(object sender, EventArgs e)
    {
        
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        var slider = sender as Slider;
        if (slider != null)
        {
            slider.Value = Math.Round(slider.Value);
        }
    }
    private async void StartWorking()
    {
        await RunWork();
    }
    private async Task RunWork()
    {
        while (true) { 

        _workProgress.CalculateWorkProgress(1);
        await Task.Delay(1000);
        }
    }
}