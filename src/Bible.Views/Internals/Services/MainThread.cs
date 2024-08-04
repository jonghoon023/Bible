using Avalonia.Threading;
using Bible.Abstractions.Views;

namespace Bible.Views.Internals.Services;

/// <summary>
/// <see cref="IMainThread" /> 의 구현체입니다.
/// </summary>
internal sealed class MainThread : IMainThread
{
    /// <inheritdoc cref="IMainThread.Invoke(Action)" />
    public void Invoke(Action callback)
    {
        Dispatcher.UIThread.Invoke(callback);
    }

    /// <inheritdoc cref="IMainThread.Invoke{T}(Func{T})" />
    public T Invoke<T>(Func<T> callback)
    {
        return Dispatcher.UIThread.Invoke(callback);
    }

    /// <inheritdoc cref="IMainThread.InvokeAsync(Action)" />
    public async Task InvokeAsync(Action callback)
    {
        await Dispatcher.UIThread.InvokeAsync(callback);
    }

    /// <inheritdoc cref="IMainThread.InvokeAsync(Func{Task})" />
    public Task InvokeAsync(Func<Task> callback)
    {
        return Dispatcher.UIThread.InvokeAsync(callback);
    }
}
