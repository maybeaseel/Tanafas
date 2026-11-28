namespace Tanaffas.Services;

/// Navigation behind an interface, so ViewModels never touch Shell directly.
public interface IAppNavigator
{
    Task GoToAsync(string route);
}
