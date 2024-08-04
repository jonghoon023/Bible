namespace Bible.Abstractions.ViewModels;

/// <summary>
/// 모든 ViewModel Class 가 구현해야 하는 Interface 입니다.
/// </summary>
public interface IViewModel
{
    /// <summary>
    /// View 가 <c> Initialized </c> 되었을 때 실행되는 함수입니다.
    /// </summary>
    void OnInitialized();

    /// <summary>
    /// View 가 <c> Initialized </c> 되었을 때 실행되는 비동기 함수입니다.
    /// </summary>
    Task OnInitializedAsync();

    /// <summary>
    /// Template 이 적용되었을 때 발생합니다.
    /// </summary>
    void OnTemplateApplied();

    /// <summary>
    /// View 가 <c> Load </c> 되었을 때 실행되는 함수입니다.
    /// </summary>
    void OnLoaded();

    /// <summary>
    /// View 가 <c> Load </c> 되었을 때 실행되는 비동기 함수입니다.
    /// </summary>
    Task OnLoadedAsync();

    /// <summary>
    /// View 가 <c> Unload </c> 되었을 때 실행되는 함수입니다.
    /// </summary>
    void OnUnloaded();

    /// <summary>
    /// View 가 <c> Unload </c> 되었을 때 실행되는 비동기 함수입니다.
    /// </summary>
    Task OnUnloadedAsync();
}
