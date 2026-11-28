using System.Globalization;

namespace Tanaffas.Helpers;

/// <summary>True when the text is not empty. Used to show an error label only when there is an error.</summary>
public class NotEmptyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is string s && s.Length > 0;

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}
