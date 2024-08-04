using Avalonia.Controls.Primitives;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Avalonia;
using Bible.Abstractions.ViewModels;

namespace Bible.Views.Internals.Components;

/// <summary>
/// 모든 Components 객체가 상속받아야 하는 추상 Class 입니다.
/// </summary>
internal abstract class ComponentsBase : UserControl
{
    /// <summary>
    /// <see cref="ComponentsBase" /> 를 초기화합니다.
    /// </summary>
    protected ComponentsBase()
    {
        TemplateApplied += OnTemplateApplied;
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

    private void OnTemplateApplied(object? sender, TemplateAppliedEventArgs e)
    {
        (DataContext as IViewModel)?.OnTemplateApplied();
    }
}
