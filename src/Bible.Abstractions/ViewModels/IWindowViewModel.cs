namespace Bible.Abstractions.ViewModels;

/// <summary>
/// Window UI 객체의 ViewModel 이 구현해야 하는 Interface 입니다.
/// </summary>
public interface IWindowViewModel : IViewModel
{
    /// <summary>
    /// Window 창을 닫고 있을 때 발생합니다.
    /// </summary>
    /// <returns> Window 창을 닫는 것을 취소하려면 <see langword="true" /> 를 반환하고, 취소하지 않으려면 <see langword="false" /> 를 반환해야 합니다. </returns>
    bool OnClosing();

    /// <summary>
    /// Window 창이 닫혔을 때 발생합니다.
    /// </summary>
    void OnClosed();
}
