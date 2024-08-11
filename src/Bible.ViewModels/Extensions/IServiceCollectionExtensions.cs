using Bible.Abstractions.ViewModels;
using Bible.ViewModels.Abstractions;
using Bible.ViewModels.Internals;
using Bible.ViewModels.Pages;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.ViewModels.Extensions;

/// <summary>
/// <see cref="IServiceCollection" /> 에 대한 확장 함수가 있는 정적 Class 입니다.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// ViewModel 을 사용할 수 있도록 <see cref="IServiceCollection" /> 구현체에 필요한 요소들을 등록합니다.
    /// </summary>
    /// <param name="services"> <see cref="IServiceCollection" /> 의 구현체입니다. </param>
    /// <param name="configuration"> <see cref="IConfiguration" /> 의 구현체입니다. </param>
    /// <returns> ViewModel 을 사용할 수 있도록 <see cref="IServiceCollection" /> 구현체에 필요한 요소들을 등록 후 <see cref="IServiceCollection" /> 을 반환합니다. </returns>
    public static IServiceCollection UseViewModel(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddSingleton<IViewModelLocator, ViewModelLocator>()
            .AddSingleton<INavigation, Navigation>()
            .AddSingleton<IMessenger>(_ => WeakReferenceMessenger.Default)
            .AddViewModels();
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services
            .AddSingleton<MainPageViewModel>();
    }
}
