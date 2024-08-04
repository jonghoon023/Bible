namespace Bible.Abstractions.Views;

/// <summary>
/// UI Thread 에서 작업을 실행시킬 수 있도록 돕는 Service 입니다.
/// </summary>
public interface IMainThread
{
    /// <summary>
    /// UI Thread 에서 작업을 실행합니다.
    /// </summary>
    /// <param name="callback"> 실행할 작업입니다. </param>
    void Invoke(Action callback);

    /// <summary>
    /// UI Thread 에서 작업을 실행 후 결과를 가져옵니다.
    /// </summary>
    /// <typeparam name="T"> 작업을 실행 후 반환할 결과의 형식입니다. </typeparam>
    /// <param name="callback"> 실행할 작업입니다. </param>
    /// <returns> 작업을 실행 후 결과를 <typeparamref name="T" /> 형식의 값으로 반환합니다. </returns>
    T Invoke<T>(Func<T> callback);

    /// <summary>
    /// UI Thread 에서 작업을 비동기로 실행합니다.
    /// </summary>
    /// <param name="callback"> 실행할 작업입니다. </param>
    Task InvokeAsync(Action callback);

    /// <summary>
    /// UI Thread 에서 작업을 비동기로 실행합니다.
    /// </summary>
    /// <param name="callback"> 실행할 작업입니다. </param>
    Task InvokeAsync(Func<Task> callback);
}
