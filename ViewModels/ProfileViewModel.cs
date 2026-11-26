using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    private readonly IAppNavigator _nav;

    public ProfileViewModel(IAppNavigator nav) => _nav = nav;

    public string FullName => "سلمى العبدالله";
    public string Email => "salma@example.com";
    public string BestText => "500 L/min";

    [ObservableProperty] private TimeSpan reminderTime = new(8, 0, 0);

    // Navigation action
    [RelayCommand] private Task SignOutAsync() => _nav.GoToAsync("//signin");
}

