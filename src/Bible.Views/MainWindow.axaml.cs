using Bible.Abstractions.ViewModels;
using Bible.Views.Internals.Components;

namespace Bible.Views;

/// <summary>
/// <see cref="MainWindow" /> 의 Code Behind 입니다.
/// </summary>
internal partial class MainWindow : WindowBase
{
    /// <summary>
    /// <see cref="MainWindow" /> 를 초기화합니다.
    /// </summary>
    /// <param name="locator"> <see cref="IViewModelLocator" /> 의 구현체입니다. </param>
    public MainWindow(IViewModelLocator locator) : base(locator)
    {
        InitializeComponent();
    }
}
