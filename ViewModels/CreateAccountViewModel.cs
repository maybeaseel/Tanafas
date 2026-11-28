using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Helpers;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

public partial class CreateAccountViewModel : FormViewModel
{
    private readonly IAppNavigator _nav;

    public CreateAccountViewModel(IAppNavigator nav) => _nav = nav;

    // Text only (letters), at least 2 characters
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.Required)]
    [MinLength(2, ErrorMessage = ValidationText.NameTooShort)]
    [RegularExpression(ValidationText.NamePattern, ErrorMessage = ValidationText.LettersOnly)]
    private string firstName = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.Required)]
    [MinLength(2, ErrorMessage = ValidationText.NameTooShort)]
    [RegularExpression(ValidationText.NamePattern, ErrorMessage = ValidationText.LettersOnly)]
    private string familyName = "";

    // Numbers only, in a range
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.Required)]
    [RegularExpression(ValidationText.DigitsPattern, ErrorMessage = ValidationText.DigitsOnly)]
    [Range(typeof(int), "12", "110", ErrorMessage = ValidationText.AgeRange)]
    private string age = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.Required)]
    [RegularExpression(ValidationText.DigitsPattern, ErrorMessage = ValidationText.DigitsOnly)]
    [Range(typeof(int), "100", "900", ErrorMessage = ValidationText.BestRange)]
    private string personalBest = "500";

    // Optional fields: validated only when something is typed
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [RegularExpression(ValidationText.NamePattern, ErrorMessage = ValidationText.LettersOnly)]
    private string doctorName = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [RegularExpression(ValidationText.EmailPattern, ErrorMessage = ValidationText.EmailInvalid)]
    private string emergencyEmail = "";

    // Account
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.EmailRequired)]
    [RegularExpression(ValidationText.EmailPattern, ErrorMessage = ValidationText.EmailInvalid)]
    private string email = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.PasswordRequired)]
    [RegularExpression(ValidationText.PasswordPattern, ErrorMessage = ValidationText.PasswordRule)]
    private string password = "";

    [ObservableProperty] private bool isFemale = true;
    [ObservableProperty] private bool isPasswordHidden = true;

    public string FirstNameError => FirstError(nameof(FirstName));
    public string FamilyNameError => FirstError(nameof(FamilyName));
    public string AgeError => FirstError(nameof(Age));
    public string PersonalBestError => FirstError(nameof(PersonalBest));
    public string DoctorNameError => FirstError(nameof(DoctorName));
    public string EmergencyEmailError => FirstError(nameof(EmergencyEmail));
    public string EmailError => FirstError(nameof(Email));
    public string PasswordError => FirstError(nameof(Password));

    protected override void RaiseErrorProperties()
    {
        OnPropertyChanged(nameof(FirstNameError));
        OnPropertyChanged(nameof(FamilyNameError));
        OnPropertyChanged(nameof(AgeError));
        OnPropertyChanged(nameof(PersonalBestError));
        OnPropertyChanged(nameof(DoctorNameError));
        OnPropertyChanged(nameof(EmergencyEmailError));
        OnPropertyChanged(nameof(EmailError));
        OnPropertyChanged(nameof(PasswordError));
    }

    [RelayCommand] private void SelectFemale() => IsFemale = true;
    [RelayCommand] private void SelectMale() => IsFemale = false;
    [RelayCommand] private void TogglePassword() => IsPasswordHidden = !IsPasswordHidden;
    [RelayCommand] private Task GoToSignInAsync() => _nav.GoToAsync("//signin");

    // Navigation happens only when every input is valid (wireframe: no account is created yet).
    [RelayCommand]
    private async Task CreateAsync()
    {
        if (!ValidateForm()) return;
        await _nav.GoToAsync("//main/today");
    }
}
