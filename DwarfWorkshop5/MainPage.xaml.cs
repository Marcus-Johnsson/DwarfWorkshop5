using DwarfWorkshop5.AddToDataBase;
using DwarfWorkshop5.Models;
using DwarfWorkshop5.View;
using System.Threading.Tasks;

namespace DwarfWorkshop5
{
    public partial class MainPage : ContentPage
    {
        private readonly User _user;
        private readonly MyDbContext _mydb;


        public MainPage(MyDbContext myDb, User user)
        {
            InitializeComponent();
            _user = user;
            _mydb = myDb;
 
            //AddToDataBase.AddproductsToDataBase.AddProductsToDataBase();
            //AddToDataBase.AddproductsToDataBase.CreateRecipe();
            
        }

        private void OnQuitButtonClicked(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new View.Signin(_mydb,_user));
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Register(_mydb,_user));
        }
    }

}
