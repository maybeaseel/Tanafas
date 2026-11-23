using Tanaffas.ViewModels;

namespace Tanaffas.Views;

public partial class CreateAccountPage : ContentPage
{
    public CreateAccountPage(CreateAccountViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

