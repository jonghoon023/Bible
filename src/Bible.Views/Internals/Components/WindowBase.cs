using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Bible.Abstractions.ViewModels;
using Bible.Abstractions.Views;

namespace Bible.Views.Internals.Components;

/// <summary>
/// 모든 <see cref="Window" /> UI 객체가 상속받아야 하는 추상 Class 입니다.
/// </summary>
internal abstract class WindowBase : Window, IWindow
{
    /// <summary>
    /// <see cref="WindowBase" /> 를 초기화합니다.
    /// </summary>
    /// <param name="locator"> <see cref="IViewModelLocator" /> 의 구현체입니다. </param>
    protected WindowBase(IViewModelLocator locator)
    {
        ArgumentNullException.ThrowIfNull(locator);
        DataContext = locator.GetViewModel<IWindowViewModel>(GetType(), this);
    }

    /// <inheritdoc cref="Window.Show()" />
    public override void Show()
    {
        Dispatcher.UIThread.Invoke(base.Show);
    }

    /// <inheritdoc cref="Window.Hide()" />
    public override void Hide()
    {
        Dispatcher.UIThread.Invoke(base.Hide);
    }

    /// <inheritdoc cref="StyledElement.OnInitialized" />
    protected override void OnInitialized()
    {
        base.OnInitialized();
        if (DataContext is IViewModel viewModel)
        {
            viewModel.OnInitialized();
            Dispatcher.UIThread.Invoke(async () => await viewModel.OnInitializedAsync().ConfigureAwait(false));
        }
    }

    /// <inheritdoc cref="Control.OnLoaded(RoutedEventArgs)" />
    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (DataContext is IViewModel viewModel)
        {
            viewModel.OnLoaded();
            Dispatcher.UIThread.Invoke(async () => await viewModel.OnLoadedAsync().ConfigureAwait(false));
        }
    }

    /// <inheritdoc cref="Control.OnUnloaded(RoutedEventArgs)" />
    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);
        if (DataContext is IViewModel viewModel)
        {
            viewModel.OnUnloaded();
            Dispatcher.UIThread.Invoke(async () => await viewModel.OnUnloadedAsync().ConfigureAwait(false));
        }
    }

    /// <inheritdoc cref="Window.OnClosing(WindowClosingEventArgs)" />
    protected override void OnClosing(WindowClosingEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        e.Cancel = (DataContext as IWindowViewModel)?.OnClosing() ?? false;
        base.OnClosing(e);
    }

    /// <inheritdoc cref="TopLevel.OnClosed(EventArgs)" />
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        (DataContext as IWindowViewModel)?.OnClosed();
    }
}
