namespace Tanaffas.Services;

public class ShellAppNavigator : IAppNavigator
{
    public Task GoToAsync(string route) => Shell.Current.GoToAsync(route);
}
