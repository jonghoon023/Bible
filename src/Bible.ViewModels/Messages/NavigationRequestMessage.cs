using Bible.ViewModels.Abstractions;

namespace Bible.ViewModels.Messages;

/// <summary>
/// Page Navigation 을 요청하는 Message Class 입니다.
/// </summary>
/// <param name="viewModel"> 이동할 새로운 Page 의 ViewModel 객체입니다. </param>
public sealed class NavigationRequestMessage(PageViewModelBase viewModel)
{
    /// <summary>
    /// 이동할 새로운 Page 의 ViewModel 객체를 가져옵니다.
    /// </summary>
    public PageViewModelBase ViewModel => viewModel;
}
