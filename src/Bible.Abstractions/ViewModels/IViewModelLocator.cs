namespace Bible.Abstractions.ViewModels;

/// <summary>
/// ViewModel 을 관리하는 Locator Interface 입니다.
/// </summary>
public interface IViewModelLocator
{
    /// <summary>
    /// <typeparamref name="TViewModel" /> 객체를 가져옵니다.
    /// </summary>
    /// <typeparam name="TViewModel"> <see cref="IViewModel" /> Interface 를 구현하고 있는 Class 입니다. </typeparam>
    /// <param name="viewType"> View 의 Type 입니다. </param>
    /// <param name="parameters"> ViewModel 객체를 생성할 때 필요한 매개변수들입니다. </param>
    /// <returns>
    ///	<typeparamref name="TViewModel" /> 객체를 필요에 따라 생성하여 반환합니다. <br />
    ///	만약 <typeparamref name="TViewModel" /> 객체를 생성하여 가져올 수 없으면 <see langword="null" /> 을 반환합니다.
    /// </returns>
    /// <exception cref="ArgumentException"> <paramref name="viewType" /> 의 Assembly 형식이 <typeparamref name="TViewModel" /> 의 Assembly 형식과 동일할 때 발생합니다. </exception>
    TViewModel? GetViewModel<TViewModel>(Type viewType, params object[] parameters)
        where TViewModel : class, IViewModel;

    /// <summary>
    /// <typeparamref name="TViewModel" /> 객체를 가져옵니다.
    /// </summary>
    /// <typeparam name="TViewModel"> <see cref="IViewModel" /> Interface 를 구현하고 있는 Class 입니다. </typeparam>
    /// <param name="viewModelName"> ViewModel 의 이름입니다. </param>
    /// <param name="parameters"> ViewModel 객체를 생성할 때 필요한 매개변수들입니다. </param>
    /// <returns>
    ///	<typeparamref name="TViewModel" /> 객체를 필요에 따라 생성하여 반환합니다. <br />
    ///	만약 <typeparamref name="TViewModel" /> 객체를 생성하여 가져올 수 없으면 <see langword="null" /> 을 반환합니다.
    /// </returns>
    TViewModel? GetViewModel<TViewModel>(string viewModelName, params object[] parameters)
        where TViewModel : class, IViewModel;
}
