using Bible.ViewModels.Abstractions;

namespace Bible.ViewModels.Pages;

/// <summary>
/// <c> MainPage </c> 의 ViewModel Class 입니다.
/// </summary>
/// <param name="navigation"> <see cref="INavigation" /> 의 구현체입니다. </param>
public sealed class MainPageViewModel(INavigation navigation) : PageViewModelBase(navigation)
{
}
