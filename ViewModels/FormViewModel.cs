using CommunityToolkit.Mvvm.ComponentModel;

namespace Tanaffas.ViewModels;

/// <summary>Base for pages with a validated form. Validation attributes live on each ViewModel's properties.</summary>
public abstract partial class FormViewModel : ObservableValidator
{
    [ObservableProperty]
    private bool isBusy;

    protected FormViewModel()
    {
        ErrorsChanged += (_, _) => RaiseErrorProperties();
    }

    /// <summary>Raise PropertyChanged for every *Error property so the labels under the fields refresh.</summary>
    protected abstract void RaiseErrorProperties();

    protected string FirstError(string propertyName) =>
        GetErrors(propertyName).FirstOrDefault()?.ErrorMessage ?? "";

    /// <summary>Validates every property. Returns true when the form is valid.</summary>
    protected bool ValidateForm()
    {
        ValidateAllProperties();
        return !HasErrors;
    }
}
