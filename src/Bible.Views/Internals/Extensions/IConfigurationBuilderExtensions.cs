using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Bible.Views.Internals.Extensions;

/// <summary>
/// <see cref="IConfigurationBuilder" /> 에 대한 확장 함수가 있는 정적 Class 입니다.
/// </summary>
internal static class IConfigurationBuilderExtensions
{
    /// <summary>
    /// <c> appsettings.json </c> File 을 등록합니다.
    /// </summary>
    /// <param name="configurationBuilder"> <see cref="IConfigurationBuilder" /> 의 구현체입니다. </param>
    /// <param name="environment"> <see cref="IHostEnvironment" /> 의 구현체입니다. </param>
    /// <returns> <c> appsettings.json </c> File 을 등록 후 등록한 <see cref="IConfigurationBuilder" /> 의 구현체를 반환합니다. </returns>
    public static IConfigurationBuilder AddAppSettings(this IConfigurationBuilder configurationBuilder, IHostEnvironment environment)
    {
        configurationBuilder.AddJsonFile("appsettings.json", false, true);

        if (environment.IsStaging())
        {
            configurationBuilder.AddJsonFile("appsettings.Staging.json", true);
        }

        return configurationBuilder;
    }
}
