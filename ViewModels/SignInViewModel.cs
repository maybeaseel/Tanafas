using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

public partial class SignInViewModel : ObservableObject
{
    private readonly IAppNavigator _nav;

    public SignInViewModel(IAppNavigator nav) => _nav = nav;

    [ObservableProperty] private string email = "";
    [ObservableProperty] private string password = "";
    [ObservableProperty] private bool rememberMe;
    [ObservableProperty] private bool isPasswordHidden = true;

    // Navigation actions (wireframe: no account check yet)
    [RelayCommand] private Task SignInAsync() => _nav.GoToAsync("//main/today");
    [RelayCommand] private Task GoToRegisterAsync() => _nav.GoToAsync("//register");
    [RelayCommand] private void TogglePassword() => IsPasswordHidden = !IsPasswordHidden;
}
