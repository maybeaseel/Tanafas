using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

public partial class LogViewModel : ObservableObject
{
    private readonly IAppNavigator _nav;

    public LogViewModel(IAppNavigator nav) => _nav = nav;

    [ObservableProperty] private string peakFlow = "";
    [ObservableProperty] private string spo2 = "";
    [ObservableProperty] private string pulse = "";
    [ObservableProperty] private bool isReliever;
    [ObservableProperty] private bool recordDose = true;

    public ObservableCollection<ChipItem> Symptoms { get; } = new()
    {
        new ChipItem("سعال"), new ChipItem("صفير"), new ChipItem("ضيق تنفس"), new ChipItem("استيقاظ ليلي"),
    };

    public ObservableCollection<ChipItem> Triggers { get; } = new()
    {
        new ChipItem("وبر الحيوانات"), new ChipItem("حبوب اللقاح"), new ChipItem("غبار"), new ChipItem("دخان"),
    };

    [RelayCommand] private void SelectController() => IsReliever = false;
    [RelayCommand] private void SelectReliever() => IsReliever = true;

    [RelayCommand]
    private void ToggleChip(ChipItem? chip)
    {
        if (chip != null) chip.IsSelected = !chip.IsSelected;
    }

    // Wireframe: adds a sample chip. A real prompt comes later.
    [RelayCommand]
    private void AddTrigger() => Triggers.Add(new ChipItem("محفز جديد") { IsSelected = true });

    // Navigation action (wireframe: nothing is saved yet)
    [RelayCommand] private Task SaveAsync() => _nav.GoToAsync("//main/today");
}

