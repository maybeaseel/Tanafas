using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

public partial class CreateAccountViewModel : ObservableObject
{
    private readonly IAppNavigator _nav;

    public CreateAccountViewModel(IAppNavigator nav) => _nav = nav;

    [ObservableProperty] private string firstName = "";
    [ObservableProperty] private string familyName = "";
    [ObservableProperty] private string age = "";
    [ObservableProperty] private string personalBest = "500";
    [ObservableProperty] private string doctorName = "";
    [ObservableProperty] private string emergencyEmail = "";
    [ObservableProperty] private string email = "";
    [ObservableProperty] private string password = "";
    [ObservableProperty] private bool isFemale = true;
    [ObservableProperty] private bool isPasswordHidden = true;

    [RelayCommand] private void SelectFemale() => IsFemale = true;
    [RelayCommand] private void SelectMale() => IsFemale = false;
    [RelayCommand] private void TogglePassword() => IsPasswordHidden = !IsPasswordHidden;

    // Navigation actions (wireframe: no account is created yet)
    [RelayCommand] private Task CreateAsync() => _nav.GoToAsync("//main/today");
    [RelayCommand] private Task GoToSignInAsync() => _nav.GoToAsync("//signin");
}

