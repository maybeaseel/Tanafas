using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Tanaffas.ViewModels;

/// One selectable chip (a symptom or a trigger). Each chip owns its toggle command.
public partial class ChipItem : ObservableObject
{
    public ChipItem(string name) => Name = name;

    public string Name { get; }

    [ObservableProperty]
    private bool isSelected;

    [RelayCommand]
    private void Toggle() => IsSelected = !IsSelected;
}
