using System.Collections.Concurrent;
using Bible.Abstractions.ViewModels;
using Bible.ViewModels.Abstractions;
using Bible.ViewModels.Messages;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bible.ViewModels.Internals;

/// <summary>
/// <see cref="INavigation" /> 의 구현체입니다.
/// </summary>
/// <param name="provider"> <see cref="IServiceProvider" /> 의 구현체입니다. </param>
/// <param name="logger"> Log 를 작성할 수 있는 <see cref="ILogger{TCategoryName}" /> 의 구현체입니다. </param>
/// <param name="messenger"> <see cref="IMessenger" /> 의 구현체입니다. </param>
/// <param name="locator"> <see cref="IViewModelLocator" /> 의 구현체입니다. </param>
internal sealed partial class Navigation(IServiceProvider provider, ILogger<Navigation> logger, IMessenger messenger, IViewModelLocator locator) : INavigation
{
    private const string ItemSeparator = ", ";
    private static readonly object[] EmptyArray = [];
    private readonly ConcurrentStack<PageViewModelBase> _navigationStack = [];

    /// <inheritdoc cref="INavigation.Back" />
    public bool Back()
    {
        if (_navigationStack.TryPop(out PageViewModelBase? viewModel))
        {
            NavigateToPage(viewModel);
        }

        return false;
    }

    /// <inheritdoc cref="INavigation.NavigateTo{TViewModel}()" />
    public void NavigateTo<TViewModel>() where TViewModel : PageViewModelBase
    {
        NavigateTo<TViewModel>(EmptyArray);
    }

    /// <inheritdoc cref="INavigation.NavigateTo{TViewModel}(object?[])" />
    public void NavigateTo<TViewModel>(params object[] arguments) where TViewModel : PageViewModelBase
    {
        NavigateToCore(typeof(TViewModel), arguments);
    }

    /// <inheritdoc cref="INavigation.NavigateTo{TViewModel}(object?[])" />
    private void NavigateToCore(Type viewModelType, params object[] arguments)
    {
        Type? currentPageType = _navigationStack.LastOrDefault()?.GetType();
        if (!viewModelType.Equals(currentPageType))
        {
            object[] args = arguments ?? [];
            PageViewModelBase? pageViewModel = provider.GetService(viewModelType) is PageViewModelBase viewModel ? viewModel : ActivatorUtilities.CreateInstance(provider, viewModelType, args) as PageViewModelBase;

            if (pageViewModel != null)
            {
                string argumentsList = string.Join(ItemSeparator, args.Select(arg => arg.ToString()));

                NavigateToPage(pageViewModel);
                LogSuccessfullyNavigated(logger, viewModelType.Name, argumentsList);
            }
        }
    }

    private void NavigateToPage(PageViewModelBase viewModel)
    {
        _navigationStack.Push(viewModel);
        messenger.Send(new NavigationRequestMessage(viewModel));
    }

    [LoggerMessage(LogLevel.Information, "Successfully navigated to {ViewModelName}. Arguments: [{ArgumentsList}]")]
    private static partial void LogSuccessfullyNavigated(ILogger logger, string viewModelName, string argumentsList);
}
