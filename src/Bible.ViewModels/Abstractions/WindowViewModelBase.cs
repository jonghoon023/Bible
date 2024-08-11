using Bible.Abstractions.ViewModels;
using Bible.Abstractions.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bible.ViewModels.Abstractions;

/// <summary>
/// Window 의 <see cref="IWindowViewModel" /> 의 구현체입니다.
/// </summary>
public abstract partial class WindowViewModelBase : ViewModelBase, IWindowViewModel
{
    private readonly IWindow _window;

    [ObservableProperty]
    private string _title;

    /// <summary>
    /// <see cref="WindowViewModelBase" /> 를 초기화합니다.
    /// </summary>
    /// <param name="window"> 실제 Window UI 객체가 구현하고 있는 <see cref="IWindow" /> 의 구현체입니다. </param>
    protected WindowViewModelBase(IWindow window)
    {
        _window = window;
        _title = string.Empty;

        IsActive = true;
    }

    /// <inheritdoc cref="IWindowViewModel.OnClosing" />
    public virtual bool OnClosing()
    {
        return false;
    }

    /// <inheritdoc cref="IWindowViewModel.OnClosed" />
    public virtual void OnClosed()
    {
        IsActive = false;
    }

    /// <summary>
    /// Window 창을 엽니다.
    /// </summary>
    protected void Show()
    {
        _window.Show();
    }

    /// <summary>
    /// Window 창을 숨깁니다.
    /// </summary>
    protected void Hide()
    {
        _window.Hide();
    }

    /// <summary>
    /// Window 창을 닫습니다.
    /// </summary>
    protected void Close()
    {
        _window.Close();
    }
}
