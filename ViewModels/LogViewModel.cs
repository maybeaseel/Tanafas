using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Helpers;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

public partial class LogViewModel : FormViewModel
{
    private readonly IAppNavigator _nav;
    private readonly IDialogService _dialog;

    public LogViewModel(IAppNavigator nav, IDialogService dialog)
    {
        _nav = nav;
        _dialog = dialog;
    }

    // Required, numbers only, in a range
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = ValidationText.Required)]
    [RegularExpression(ValidationText.DigitsPattern, ErrorMessage = ValidationText.DigitsOnly)]
    [Range(typeof(int), "50", "900", ErrorMessage = ValidationText.PeakFlowRange)]
    private string peakFlow = "";

    // Optional: validated only when something is typed
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [RegularExpression(ValidationText.DigitsPattern, ErrorMessage = ValidationText.DigitsOnly)]
    [Range(typeof(int), "70", "100", ErrorMessage = ValidationText.Spo2Range)]
    private string spo2 = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [RegularExpression(ValidationText.DigitsPattern, ErrorMessage = ValidationText.DigitsOnly)]
    [Range(typeof(int), "30", "220", ErrorMessage = ValidationText.PulseRange)]
    private string pulse = "";

    [ObservableProperty] private bool isReliever;

    public string PeakFlowError => FirstError(nameof(PeakFlow));
    public string Spo2Error => FirstError(nameof(Spo2));
    public string PulseError => FirstError(nameof(Pulse));

    protected override void RaiseErrorProperties()
    {
        OnPropertyChanged(nameof(PeakFlowError));
        OnPropertyChanged(nameof(Spo2Error));
        OnPropertyChanged(nameof(PulseError));
    }

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
    private Task AddSymptomAsync() => AddChipAsync(Symptoms, "إضافة عرض", "اكتب اسم العرض");

    [RelayCommand]
    private Task AddTriggerAsync() => AddChipAsync(Triggers, "إضافة محفز", "اكتب اسم المحفز");

    // Asks the user for a label, checks it, and adds it as a selected chip.
    private async Task AddChipAsync(ObservableCollection<ChipItem> list, string title, string message)
    {
        var name = (await _dialog.PromptAsync(title, message, "إضافة", "إلغاء", maxLength: 30))?.Trim();
        if (string.IsNullOrEmpty(name)) return;

        if (!Regex.IsMatch(name, ValidationText.LabelPattern))
        {
            await _dialog.AlertAsync("اسم غير صالح", ValidationText.LabelRule, "حسنًا");
            return;
        }

        var existing = list.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));
        if (existing != null) existing.IsSelected = true;
        else list.Add(new ChipItem(name) { IsSelected = true });
    }

    // Navigation happens only when the inputs are valid (wireframe: nothing is saved yet).
    [RelayCommand]
    private async Task SaveAsync()
    {
        if (!ValidateForm()) return;
        await _nav.GoToAsync("//main/today");
    }
}
