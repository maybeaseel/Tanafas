namespace Tanaffas.Helpers;

/// <summary>Validation messages (Arabic) and patterns. They are constants because attributes need constants.</summary>
public static class ValidationText
{
    // Patterns
    public const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$";           // name@domain.tld
    public const string NamePattern = @"^[\p{L}][\p{L} .'\-]*$";                    // letters, spaces, . ' -
    public const string DigitsPattern = @"^[0-9]+$";                                 // digits 0-9 only
    public const string PasswordPattern = @"^(?=.*[A-Za-z\u0600-\u06FF])(?=.*[0-9]).{8,}$";
    public const string LabelPattern = @"^[\p{L}\p{N}][\p{L}\p{N} \-]{1,29}$";      // custom symptom or trigger name

    // Messages
    public const string Required = "هذا الحقل مطلوب";
    public const string EmailRequired = "البريد الإلكتروني مطلوب";
    public const string EmailInvalid = "صيغة البريد الإلكتروني غير صحيحة (مثال: name@example.com)";
    public const string PasswordRequired = "كلمة المرور مطلوبة";
    public const string PasswordRule = "كلمة المرور 8 أحرف على الأقل وتحتوي على حرف ورقم";
    public const string NameTooShort = "الاسم قصير جدًا (حرفان على الأقل)";
    public const string LettersOnly = "استخدم حروفًا فقط (بدون أرقام أو رموز)";
    public const string DigitsOnly = "أدخل أرقامًا فقط (0-9)";
    public const string AgeRange = "العمر يجب أن يكون بين 12 و110";
    public const string BestRange = "القيمة يجب أن تكون بين 100 و900 L/min";
    public const string PeakFlowRange = "ذروة التدفق يجب أن تكون بين 50 و900 L/min";
    public const string Spo2Range = "الأكسجين يجب أن يكون بين 70 و100";
    public const string PulseRange = "النبض يجب أن يكون بين 30 و220";
    public const string LabelRule = "استخدم حروفًا وأرقامًا ومسافات فقط (من حرفين إلى 30 حرفًا)";
}
