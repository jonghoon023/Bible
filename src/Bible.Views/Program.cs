using Avalonia;
using Bible.ViewModels.Extensions;
using Bible.Views.Internals.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Bible.Views;

/// <summary>
/// Program 의 진입점이 되는 정적 Class 입니다.
/// </summary>
internal static class Program
{
    private const string ApplicationNameSectionName = "Application:Name";
    private static IHost? _host;

    /// <summary>
	/// Initialization code. Don't use any Avalonia, third-party APIs or any SynchronizationContext-reliant code before AppMain is called: things aren't initialized yet and stuff might break.
	/// </summary>
	/// <param name="args"> 매개변수들입니다. </param>
    [STAThread]
    public static void Main(string[] args)
    {
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
            {
                context.HostingEnvironment.ApplicationName = context.Configuration.GetValue<string>(ApplicationNameSectionName) ?? context.HostingEnvironment.ApplicationName;
#if DEBUG
                context.HostingEnvironment.EnvironmentName = Environments.Staging;
#endif
                builder.SetBasePath(AppContext.BaseDirectory);
                builder.AddEnvironmentVariables();
                builder.AddAppSettings(context.HostingEnvironment);
            })
            .ConfigureServices((context, services) =>
            {
                services.UseViewModel(context.Configuration);
                services.AddSingleton<App>();
                services.AddSingleton<MainWindow>();

                services.AddSingletonSerivices();
                services.AddOperatingSystemServices();
            })
            .ConfigureLogging(builder => builder.ClearProviders())
            .UseSerilogWithFile();

        _host = hostBuilder.Build();

#pragma warning disable CA1031 // 일반적인 예외 형식을 catch하지 마세요.
        try
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        catch (Exception e)
        {
            Log.Fatal(e, "Application 실행 중 매우 심각한 문제가 발생했습니다.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
#pragma warning restore CA1031 // 일반적인 예외 형식을 catch하지 마세요.
    }

    /// <summary>
	/// Avalonia configuration, don't remove; also used by visual designer.
	/// </summary>
	/// <returns> <see cref="AppBuilder" /> 객체를 가져옵니다. </returns>
	/// <exception cref="ArgumentException"> <see cref="_host" /> 의 값이 올바르지 않을 때 발생합니다. </exception>
    public static AppBuilder BuildAvaloniaApp()
    {
        if (_host != null)
        {
            _host.Start();
            return AppBuilder.Configure(_host.Services.GetRequiredService<App>)
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
        }

        throw new ArgumentException("Unable to start the Application because the Host cannot be executed.");
    }
}
