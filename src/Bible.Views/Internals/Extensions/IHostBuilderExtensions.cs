using System.Text.RegularExpressions;
using Bible.Abstractions.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Bible.Views.Internals.Extensions;

/// <summary>
/// <see cref="IHostBuilder" /> 에 대한 확장 함수가 있는 정적 Class 입니다.
/// </summary>
internal static partial class IHostBuilderExtensions
{
    private const string VersionPattern = "{Version}";

    /// <summary>
    /// Serilog 를 통해 File 에 Log 를 기록하는 File Logger 를 등록합니다.
    /// </summary>
    /// <param name="hostBuilder"> <see cref="IHostBuilder" /> 의 구현체입니다. </param>
    /// <returns> File 에 Log 를 기록하는 File Logger 를 등록 후 <see cref="IHostBuilder" /> 을 반환합니다. </returns>
    public static IHostBuilder UseSerilogWithFile(this IHostBuilder hostBuilder)
    {
        return hostBuilder.UseSerilog((hostingContext, provider, loggerConfiguration) =>
        {
            UpdateLogFilePath(provider, hostingContext.Configuration);
            loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration)
                .ReadFrom.Services(provider);
        });
    }

    /// <summary>
    /// Log File 의 경로를 갱신합니다.
    /// </summary>
    /// <param name="provider"> <see cref="IServiceProvider" /> 의 구현체입니다. </param>
    /// <param name="configuration"> <see cref="IConfiguration" /> 의 구현체입니다. </param>
    /// <seealso href="https://stackoverflow.com/a/75988212" />
    private static void UpdateLogFilePath(IServiceProvider provider, IConfiguration configuration)
    {
        IAppInfo appInfo = provider.GetRequiredService<IAppInfo>();
        foreach (KeyValuePair<string, string?> keyValuePair in configuration.AsEnumerable())
        {
            if (LogFilePathRegex().IsMatch(keyValuePair.Key) && !string.IsNullOrEmpty(keyValuePair.Value))
            {
                string logFilePath = Path.Combine(appInfo.AppDataDirectory, configuration[keyValuePair.Key] ?? string.Empty);
                configuration[keyValuePair.Key] = logFilePath.Replace(VersionPattern, appInfo.Version.ToString(), StringComparison.OrdinalIgnoreCase);
            }
        }
    }

    [GeneratedRegex("^Serilog:WriteTo.*Args:path$", RegexOptions.IgnoreCase, "ko-KR")]
    private static partial Regex LogFilePathRegex();
}
