using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Bible.Views.Internals.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.Views;

/// <summary>
/// <see cref="App" /> 의 Code Behind 입니다.
/// </summary>
/// <remarks>
/// <see cref="App" /> 을 초기화합니다,
/// </remarks>
/// <param name="provider"> <see cref="IServiceProvider" /> 의 구현체입니다. </param>
public class App(IServiceProvider provider) : Application
{
    private readonly IServiceProvider _provider = provider;

    /// <inheritdoc cref="Application.Initialize" />
    public override void Initialize()
    {
        DataTemplates.Add(_provider.GetRequiredService<ViewLocator>());
        AvaloniaXamlLoader.Load(this);
    }

    /// <inheritdoc cref="Application.OnFrameworkInitializationCompleted" />
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = _provider.GetRequiredService<MainWindow>();
        }

        base.OnFrameworkInitializationCompleted();
    }

}
