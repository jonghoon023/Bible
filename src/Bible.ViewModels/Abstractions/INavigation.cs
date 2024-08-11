namespace Bible.ViewModels.Abstractions;

/// <summary>
/// Page 를 이동할 수 있도록 돕는 Navigaton Service 입니다.
/// </summary>
public interface INavigation
{
    /// <summary>
    /// 이전 Page 로 이동합니다.
    /// </summary>
    /// <returns> 이전 Page 로 이동하는데 성공했으면 <see langword="true" /> 를 반환하고, 실패했으면 <see langword="false" /> 를 반환합니다. </returns>
    bool Back();

    /// <summary>
    /// Page 를 이동합니다.
    /// </summary>
    /// <typeparam name="TViewModel"> <see cref="PageViewModelBase" /> 를 상속받는 Class 입니다. </typeparam>
    void NavigateTo<TViewModel>()
        where TViewModel : PageViewModelBase;

    /// <summary>
    /// Page 를 이동합니다.
    /// </summary>
    /// <typeparam name="TViewModel"> <see cref="PageViewModelBase" /> 를 상속받는 Class 입니다. </typeparam>
    /// <param name="arguments"> <typeparamref name="TViewModel" /> 객체를 생성할 때 필요한 매개변수들입니다. </param>
    void NavigateTo<TViewModel>(params object[] arguments)
        where TViewModel : PageViewModelBase;
}
