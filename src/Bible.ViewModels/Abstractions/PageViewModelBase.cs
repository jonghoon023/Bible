namespace Bible.ViewModels.Abstractions;

/// <summary>
/// Page 의 ViewModel Class 들이 상속받아야 하는 추상 Class 입니다.
/// </summary>
/// <param name="navigation"> Page 를 이동할 수 있는 <see cref="INavigation" /> 의 구현체입니다. </param>
public abstract class PageViewModelBase(INavigation navigation) : ViewModelBase
{
    /// <summary>
    /// Page 를 이동하는 기능을 제공하는 <see cref="INavigation" /> 의 구현체를 가져옵니다.
    /// </summary>
    public INavigation Navigation => navigation;
}
