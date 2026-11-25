namespace Tanaffas.Services;

/// <summary>Navigation behind an interface, so ViewModels never touch Shell directly.</summary>
public interface IAppNavigator
{
    Task GoToAsync(string route);
}
