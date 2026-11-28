using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Helpers;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

public partial class SignInViewModel : FormViewModel
{
    private readonly IAppNavigator _nav;

    public SignInViewModel(IAppNavigator nav) => _nav = nav;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.EmailRequired)]
    [RegularExpression(ValidationText.EmailPattern, ErrorMessage = ValidationText.EmailInvalid)]
    private string email = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.PasswordRequired)]
    private string password = "";

    [ObservableProperty] private bool isPasswordHidden = true;

    public string EmailError => FirstError(nameof(Email));
    public string PasswordError => FirstError(nameof(Password));

    protected override void RaiseErrorProperties()
    {
        OnPropertyChanged(nameof(EmailError));
        OnPropertyChanged(nameof(PasswordError));
    }

    // Navigation happens only when the inputs are valid (wireframe: no account check yet).
    [RelayCommand]
    private async Task SignInAsync()
    {
        if (!ValidateForm()) return;
        await _nav.GoToAsync("//main/today");
    }

    [RelayCommand] private Task GoToRegisterAsync() => _nav.GoToAsync("//register");
    [RelayCommand] private void TogglePassword() => IsPasswordHidden = !IsPasswordHidden;
}
