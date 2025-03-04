using DwarfWorkhop5;
using Microsoft.Data.SqlClient;

namespace DwarfWorkshop5.View;

public partial class register : ContentPage
{
    public register()
    {
        InitializeComponent();
    }

    private void OnCreateAccountClicked(System.Object sender, System.EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntryFirst.Text;
        AddToDataBase.RegisterUser.CreateNewUserStep1(username, password);

        Navigation.PushAsync(new View.GamePage());
    }

    private void OnCancelClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void OnUserNameTextChanged(object sender, TextChangedEventArgs e)
    {
        string username = UsernameEntry.Text;

        if (string.IsNullOrWhiteSpace(username))
        {
            AvailableLabelUsername.Text = "";
            CreateAccount.IsEnabled = false;
            return;
        }

        bool isAvailable = await CheckUsername(username);

        if (isAvailable)
        {
            AvailableLabelUsername.Text = "Username is available";
            AvailableLabelUsername.TextColor = Colors.Green;
            CreateAccount.IsEnabled = true;
        }
        else
        {
            AvailableLabelUsername.Text = "Username is taken";
            AvailableLabelUsername.TextColor = Colors.Red;
            CreateAccount.IsEnabled = false;
        }
    }


    private async Task<bool> CheckUsername(string username)
    {
        await Task.Delay(500); // Important for not overloading database

        using (var connection = new SqlConnection(GetSetData.GetConnectionString()))
        {
            await connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM User WHERE Username = @Username";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                int count = (int)await command.ExecuteScalarAsync();
                return count == 0;
            }
        }
    }

    private async void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
    {
        if (PasswordEntryFirst == null || PasswordEntrySecound == null || AvailableLabelPassword == null)
        {
            return;
        }
        string firstPassword = PasswordEntryFirst.Text;
        string secondPassword = PasswordEntrySecound.Text;

        if (string.IsNullOrWhiteSpace(firstPassword) || string.IsNullOrWhiteSpace(secondPassword))
        {
            AvailableLabelPassword.Text = "";
            CreateAccount.IsEnabled = false;
        }
        await Task.Delay(500);
        if (firstPassword == secondPassword)
        {
            AvailableLabelPassword.Text = "Password match";
            AvailableLabelPassword.TextColor = Colors.Green;
            CreateAccount.IsEnabled = true;
        }
        else
        {
            AvailableLabelPassword.Text = "Password does not match";
            AvailableLabelPassword.TextColor = Colors.Red;
            CreateAccount.IsEnabled = false;
        }

    }
}
