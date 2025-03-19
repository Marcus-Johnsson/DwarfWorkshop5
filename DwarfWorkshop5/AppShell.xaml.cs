using DwarfWorkshop5.View;

namespace DwarfWorkshop5
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Game", typeof(GamePage));
            Routing.RegisterRoute("SignIn", typeof(Signin));
            Routing.RegisterRoute("Register", typeof(Register));
        }
    
      public async Task NavigateToGame()
        {
            await Shell.Current.GoToAsync("Game");
        }
        public async Task NavigateToSignIn()
        {
            await Shell.Current.GoToAsync("SignIn");
        }
        public async Task NavigateToRegister()
        {
            await Shell.Current.GoToAsync("Register");
        }
    }
}