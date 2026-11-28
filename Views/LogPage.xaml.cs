using Tanaffas.ViewModels;

namespace Tanaffas.Views;

public partial class LogPage : ContentPage
{
    public LogPage(LogViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
