using Tanaffas.ViewModels;

namespace Tanaffas.Views;

public partial class RiskExplanationPage : ContentPage
{
    public RiskExplanationPage(RiskExplanationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

