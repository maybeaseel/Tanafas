using Tanaffas.ViewModels;

namespace Tanaffas.Views;

public partial class TrendsPage : ContentPage
{
    public TrendsPage(TrendsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        // Redraw the two charts whenever the period changes.
        vm.ChartsChanged += () =>
        {
            PeakView.Invalidate();
            RelieverView.Invalidate();
        };
    }
}

