namespace Tanaffas.Views;

public partial class CreateAccountPage : ContentPage
{
    public CreateAccountPage()
    {
        InitializeComponent();
    }

    // Placeholder navigation so the skeleton can be tested. The real page replaces this file.
    private async void OnContinue(object? sender, EventArgs e) => await Shell.Current.GoToAsync("//main/today");
}

