using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.View;

public partial class GamePage : ContentPage
{
    private readonly MyDbContext _mydb;
    public GamePage(string page, MyDbContext mydb, User user)
    {
        InitializeComponent();
        _mydb = mydb;
        CallInfo(page);
        BindingContext = new ViewPageModel.GamePageModelViews(_mydb);


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

    private void OnDwarfsClicked(object sender, EventArgs e)
    {

    }

    private void OnInventoryClicked(object sender, EventArgs e)
    {

    }

    private void OnStoreClicked(object sender, EventArgs e)
    {

    }

    private void OnDwarf1Clicked(object sender, EventArgs e)
    {

    }

    private void OnDwarf2Clicked(object sender, EventArgs e)
    {

    }

    private void OnDwarf3Clicked(object sender, EventArgs e)
    {

    }

    private void OnDwarf4Clicked(object sender, EventArgs e)
    {

    }

    private void OnDwarf5Clicked(object sender, EventArgs e)
    {

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

    private void OnBuyDwarfClicked(object sender, EventArgs e)
    {

    }

    private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}