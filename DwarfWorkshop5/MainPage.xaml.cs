using DwarfWorkhop5;
using DwarfWorkshop5.AddToDataBase;
using DwarfWorkshop5.DataCheck;
using DwarfWorkshop5.Models;
using DwarfWorkshop5.View;
using System.Threading.Tasks;

namespace DwarfWorkshop5
{
    public partial class MainPage : ContentPage
    {
        private readonly User _user;
        private readonly MyDbContext _mydb;
        private readonly RegisterUser _registerUser;
        private readonly Helpers _helpers;
        
        public MainPage(MyDbContext myDb, User user, RegisterUser registerUser, Helpers helpers)
        {

            InitializeComponent();
            _user = user;
            _mydb = myDb;
            _registerUser = registerUser;
            _helpers = helpers;
            UserSession.Logout();


            //AddToDataBase.AddproductsToDataBase.AddProductsToDataBase(); //  Highest product so far 4554 ;..; 69 times added to database yay
            //AddToDataBase.AddproductsToDataBase.CreateRecipe();

        }

        private void OnQuitButtonClicked(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new View.Signin(_mydb,_user, _registerUser));
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Register(_mydb,_user, _registerUser, _helpers));
        }
    }

}
