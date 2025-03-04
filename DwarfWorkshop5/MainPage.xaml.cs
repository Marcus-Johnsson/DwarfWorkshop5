namespace DwarfWorkshop5
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnQuitButtonClicked(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }
        private void OnLoginClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Signin());
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.register());
        }
    }

}
