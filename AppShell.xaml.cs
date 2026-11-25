using Tanaffas.Views;

namespace Tanaffas;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // A page that is pushed on top of the tabs (not a tab itself). Opened with GoToAsync("risk").
        Routing.RegisterRoute("risk", typeof(RiskExplanationPage));
    }
}
