namespace DwarfWorkshop5.View;

public partial class Signin : ContentPage
{
	public Signin()
	{
		InitializeComponent();
	}
    private void OnLoginClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new GamePage());
    }

    private void OnCancelButtonClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopAsync();
    }
}