using Bible.Abstractions.ViewModels;
using Bible.Abstractions.Views;
using Bible.ViewModels.Abstractions;
using Bible.ViewModels.Messages;
using Bible.ViewModels.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace Bible.ViewModels;

/// <summary>
/// <c> MainWindow </c> 의 ViewModel Class 입니다.
/// </summary>
/// <remarks>
/// <see cref="MainWindowViewModel" /> 를 초기화합니다.
/// </remarks>
/// <param name="logger"> Log 를 작성할 수 있는 <see cref="ILogger{TCategoryName}" /> 의 구현체입니다. </param>
/// <param name="window"> 실제 Window UI 객체가 구현하고 있는 <see cref="IWindow" /> 의 구현체입니다. </param>
/// <param name="navigation"> <see cref="INavigation" /> 의 구현체입니다. </param>
public sealed partial class MainWindowViewModel(ILogger<MainWindowViewModel> logger, IWindow window, INavigation navigation) : WindowViewModelBase(window), IRecipient<NavigationRequestMessage>
{
    [ObservableProperty]
    private IViewModel? _contentPage;

    /// <inheritdoc cref="IRecipient{TMessage}.Receive(TMessage)" />
    public void Receive(NavigationRequestMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);
        ContentPage = message.ViewModel;
    }

    /// <inheritdoc cref="ViewModelBase.OnLoadedAsync" />
    public override Task OnLoadedAsync()
    {
        navigation.NavigateTo<MainPageViewModel>();
        return Task.CompletedTask;
    }
}
