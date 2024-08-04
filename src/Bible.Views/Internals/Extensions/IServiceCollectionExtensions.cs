using Avalonia.Platform;
using Bible.Abstractions.Views;
using Bible.Views.Internals.Services;
using Bible.Views.Platforms.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bible.Views.Internals.Extensions;

/// <summary>
/// <see cref="IServiceCollection" /> 에 대한 확장 함수가 있는 정적 Class 입니다.
/// </summary>
internal static class IServiceCollectionExtensions
{
    /// <summary>
	/// <see cref="ServiceLifetime.Singleton" /> 인 Service 들을 등록합니다.
	/// </summary>
	/// <param name="services"> <see cref="IServiceCollection" /> 의 구현체입니다. </param>
	/// <returns> <see cref="ServiceLifetime.Singleton" /> 인 Service 들을 <see cref="IServiceCollection" /> 구현체에 등록 후 <see cref="IServiceCollection" /> 을 반환합니다. </returns>
	public static IServiceCollection AddSingletonSerivices(this IServiceCollection services)
    {
        services.AddSingleton<ViewLocator>();
        services.AddSingleton<IMainThread, MainThread>();

        return services;
    }

    /// <summary>
	/// OS 종속성이 있는 Service 들을 <see cref="IServiceCollection" /> 구현체에 등록합니다.
	/// </summary>
	/// <param name="services"> <see cref="IServiceCollection" /> 의 구현체입니다. </param>
	/// <returns> OS 종속성이 있는 Service 들을 <see cref="IServiceCollection" /> 구현체에 등록 후 <see cref="IServiceCollection" /> 을 반환합니다. </returns>
	public static IServiceCollection AddOperatingSystemServices(this IServiceCollection services)
    {
#if WINDOWS
        services.AddSingleton<IAppInfo, WindowsAppInfo>();
#else
#endif
        return services;
    }
}
