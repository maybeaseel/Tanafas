namespace Tanaffas.Services;

public class DialogService : IDialogService
{
    private static Page? CurrentPage => Shell.Current?.CurrentPage;

    public async Task AlertAsync(string title, string message, string close)
    {
        var page = CurrentPage;
        if (page != null) await page.DisplayAlert(title, message, close);
    }

    public async Task<string?> PromptAsync(string title, string message, string accept, string cancel, int maxLength = -1)
    {
        var page = CurrentPage;
        if (page == null) return null;
        return await page.DisplayPromptAsync(title, message, accept, cancel, maxLength: maxLength);
    }
}
