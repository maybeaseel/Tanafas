using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Drawables;

namespace Tanaffas.ViewModels;

public record TriggerRow(string Name, string PercentText, double Progress);

/// <summary>Wireframe: sample values that change with the selected period. Real data comes later.</summary>
public partial class TrendsViewModel : ObservableObject
{
    public TrendsViewModel() => Build(14);

    public PeakFlowChart PeakChart { get; } = new() { PersonalBest = 500 };
    public BarChart RelieverChart { get; } = new();

    public ObservableCollection<TriggerRow> TopTriggers { get; } = new()
    {
        new TriggerRow("وبر الحيوانات", "45%", 0.45),
        new TriggerRow("حبوب اللقاح", "32%", 0.32),
        new TriggerRow("غبار", "18%", 0.18),
    };

    /// <summary>The page listens to this and redraws the two charts.</summary>
    public event Action? ChartsChanged;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Is7), nameof(Is14), nameof(Is30))]
    private int selectedDays = 14;

    public bool Is7 => SelectedDays == 7;
    public bool Is14 => SelectedDays == 14;
    public bool Is30 => SelectedDays == 30;

    public string AverageText => "355 L/min";
    public string ChangeText => "انخفضت ذروة التدفق بنسبة 12% خلال الفترة. يُرجى مراجعة الخطة العلاجية.";
    public string RelieverAverageText => "1.8 جرعة/يوم";

    [RelayCommand]
    private void SelectPeriod(string? days)
    {
        if (!int.TryParse(days, out var value)) return;
        SelectedDays = value;
        Build(value);
        ChartsChanged?.Invoke();
    }

    private void Build(int days)
    {
        var peak = new List<double?>();
        var reliever = new List<int>();
        for (var i = 0; i < days; i++)
        {
            peak.Add(440 - i * (140.0 / days) + ((i % 3) - 1) * 12);
            reliever.Add((i % 4 == 0 ? 1 : 0) + (i >= days - 3 ? i - (days - 4) : 0));
        }
        PeakChart.Values = peak;
        RelieverChart.Values = reliever;
    }
}

