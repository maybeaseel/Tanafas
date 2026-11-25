using Tanaffas.ViewModels;

namespace Tanaffas.Views;

public partial class SignInPage : ContentPage
{
    public SignInPage(SignInViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
