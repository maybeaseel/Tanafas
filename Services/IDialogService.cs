namespace Tanaffas.Services;

/// Dialogs behind an interface, so ViewModels never touch pages or Shell directly.
public interface IDialogService
{
    Task AlertAsync(string title, string message, string close);
    Task<string?> PromptAsync(string title, string message, string accept, string cancel, int maxLength = -1);
}
