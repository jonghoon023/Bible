using Bible.Abstractions.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bible.ViewModels.Abstractions;

/// <summary>
/// <see cref="IViewModel" /> 의 구현체입니다.
/// </summary>
public abstract class ViewModelBase : ObservableRecipient, IViewModel
{
    /// <inheritdoc cref="IViewModel.OnInitialized" />
    public virtual void OnInitialized()
    {
    }

    /// <inheritdoc cref="IViewModel.OnInitializedAsync" />
    public virtual Task OnInitializedAsync()
    {
        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IViewModel.OnTemplateApplied" />
    public virtual void OnTemplateApplied()
    {
    }

    /// <inheritdoc cref="IViewModel.OnLoaded" />
    public virtual void OnLoaded()
    {
    }

    /// <inheritdoc cref="IViewModel.OnLoadedAsync" />
    public virtual Task OnLoadedAsync()
    {
        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IViewModel.OnUnloaded" />
    public virtual void OnUnloaded()
    {
    }

    /// <inheritdoc cref="IViewModel.OnUnloadedAsync" />
    public virtual Task OnUnloadedAsync()
    {
        return Task.CompletedTask;
    }
}
