using DwarfWorkhop5;
using DwarfWorkshop5.AddToDataBase;
using DwarfWorkshop5.Models;


namespace DwarfWorkshop5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
            MyDbContext _mydb = new MyDbContext();
            Helpers _helpers = new Helpers(_mydb);
            User _user = new User();
            RegisterUser _registerUser = new RegisterUser(_helpers);

            MainPage = new NavigationPage(new MainPage(_mydb, _user, _registerUser, _helpers));
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}