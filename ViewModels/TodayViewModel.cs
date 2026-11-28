using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

/// <summary>Wireframe: sample values only. Real data is connected in a later phase.</summary>
public partial class TodayViewModel
{
    private readonly IAppNavigator _nav;

    public TodayViewModel(IAppNavigator nav)
    {
        _nav = nav;
        DateText = FormatDate(DateTime.Now);
    }

    public string Greeting => "مرحباً، جين دو";
    public string DateText { get; }

    public string ZoneTitle => "المنطقة الصفراء • انتبه";
    public string ZoneSummary => "مؤشراتك اليوم تتطلب المتابعة والالتزام الدقيق بخطتك العلاجية.";
    public ObservableCollection<string> Reasons { get; } = new()
    {
        "ذروة التدفق 68% من أفضل قراءة",
        "3 جرعات إسعافية اليوم",
        "تنبيه غبار ورياح في منطقتك",
    };

    public string ControllerText => "1";
    public string RelieverText => "3";
    public string PeakFlowText => "340";
    public double PeakProgress => 0.68;
    public string PeakPercentText => "68% من أفضل قراءة";
    public string OxygenText => "96%";
    public string PulseText => "88";
    public string AirTitle => "تنبيه غبار ورياح";
    public string AirDetail => "AQI 112";
    public bool AirAlert => true;
    public string AdherenceText => "96%";
    public string StableText => "12 يومًا";

    // Navigation actions
    [RelayCommand] private Task WhyAsync() => _nav.GoToAsync("risk");
    [RelayCommand] private Task AddLogAsync() => _nav.GoToAsync("//main/log");

    private static string FormatDate(DateTime date)
    {
        try { return date.ToString("dddd، d MMMM", new CultureInfo("ar")); }
        catch { return date.ToString("yyyy-MM-dd"); }
    }
}
