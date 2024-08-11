namespace Bible.Abstractions.Views;

/// <summary>
/// 모든 Window Class 가 구현해야 하는 Interface 입니다.
/// </summary>
public interface IWindow
{
    /// <summary>
    /// Window 를 엽니다.
    /// </summary>
    void Show();

    /// <summary>
    /// Window 를 숨깁니다.
    /// </summary>
    void Hide();

    /// <summary>
    /// Window 를 닫습니다.
    /// </summary>
    void Close();
}
