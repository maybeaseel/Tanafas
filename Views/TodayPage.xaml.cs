using Tanaffas.ViewModels;

namespace Tanaffas.Views;

public partial class TodayPage : ContentPage
{
    public TodayPage(TodayViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
