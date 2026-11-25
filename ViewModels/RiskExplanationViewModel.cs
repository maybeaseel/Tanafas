using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Tanaffas.Services;

namespace Tanaffas.ViewModels;

/// <summary>Wireframe: sample text only. The page is pushed from Today with GoToAsync("risk"); the Shell back arrow returns.</summary>
public partial class RiskExplanationViewModel
{
    private readonly IAppNavigator _nav;

    public RiskExplanationViewModel(IAppNavigator nav) => _nav = nav;

    public string ZoneTitle => "المنطقة الصفراء • انتبه";
    public string ZoneSummary => "مؤشراتك اليوم تتطلب المتابعة والالتزام الدقيق بخطتك العلاجية.";

    public ObservableCollection<string> Reasons { get; } = new()
    {
        "ذروة التدفق 68% من أفضل قراءة",
        "3 جرعات إسعافية اليوم",
        "تنبيه غبار ورياح في منطقتك",
    };

    public ObservableCollection<string> Steps { get; } = new()
    {
        "1. خذ جرعتك المحددة حسب خطتك العلاجية",
        "2. تواصل مع طبيبك إذا استمر الوضع أو تكرر استخدام البخاخ الإسعافي",
    };

    public string EmergencyText => "في حال صعوبة التنفس الحادة أو التحدث: اطلب الإسعاف فورًا.";
    public string EmergencyNumber => "";
    public bool HasEmergencyNumber => false;
    public string Disclaimer => "هذا التطبيق للمتابعة الذاتية والتوعية الصحية المساندة فقط، ولا يُعد بديلًا عن الاستشارة أو التدخل الطبي العاجل.";

    // Navigation action
    [RelayCommand] private Task AddLogAsync() => _nav.GoToAsync("//main/log");
}

