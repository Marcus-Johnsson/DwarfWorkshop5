using DwarfWorkshop5.Models;

namespace DwarfWorkshop5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MyDbContext _mydb = new MyDbContext();
            User _user = new User();
            MainPage = new NavigationPage(new MainPage(_mydb, _user));
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}