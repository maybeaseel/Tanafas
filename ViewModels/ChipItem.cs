using CommunityToolkit.Mvvm.ComponentModel;

namespace Tanaffas.ViewModels;

public partial class ChipItem : ObservableObject
{
    public ChipItem(string name) => Name = name;

    public string Name { get; }

    [ObservableProperty]
    private bool isSelected;
}

