using Bible.Abstractions.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Reflection;
using Windows.Storage;

namespace Bible.Views.Internals.Platforms.Windows;

/// <summary>
/// <c> Windows </c> OS 환경의 Application 정보를 가진 <see cref="IAppInfo" /> 의 구현체입니다.
/// </summary>
internal sealed class WindowsAppInfo : IAppInfo
{
    private const string ApplicationNameSectionName = "Application:Name";

    private readonly string _appName;
    private readonly Assembly _assembly;
    private readonly IConfiguration _configuration;

    private bool? _isPackaged;
    private Version? _version;
    private string _cacheDirectory;
    private string _appDataDirectory;

    /// <summary>
    /// <see cref="WindowsAppInfo" /> 를 초기화합니다.
    /// </summary>
    /// <param name="environment"> <see cref="IHostEnvironment" /> 의 구현체입니다. </param>
    /// <param name="configuration"> <see cref="IConfiguration" /> 의 구현체입니다. </param>
    public WindowsAppInfo(IHostEnvironment environment, IConfiguration configuration)
    {
        _appName = environment.ApplicationName;
        _assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
        _cacheDirectory = _appDataDirectory = string.Empty;
        _configuration = configuration;
    }

    /// <inheritdoc cref="IAppInfo.IsPackaged" />
    public bool IsPackaged
    {
        get
        {
            if (!_isPackaged.HasValue)
            {
                _isPackaged = false;

#pragma warning disable CA1031 // 일반적인 예외 형식을 catch하지 마세요.
                try
                {
                    _isPackaged = ApplicationData.Current != null;
                }
                catch (InvalidOperationException e)
                {
                    Debug.WriteLine(e, "Packaging 되어 있는 Application 에서만 사용 가능합니다.");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e, "알 수 없는 오류로 Application 의 Data Directory 경로를 가져올 수 없습니다.");
                }
#pragma warning restore CA1031 // 일반적인 예외 형식을 catch하지 마세요.
            }

            return _isPackaged.Value;
        }
    }


    /// <inheritdoc cref="IAppInfo.Name" />
    public string Name => _configuration.GetValue<string>(ApplicationNameSectionName) ?? string.Empty;

    /// <inheritdoc cref="IAppInfo.Version" />
    public Version Version
    {
        get
        {
            if (_version == null)
            {
                _version = _assembly.GetName().Version ?? new Version(0, 0, 0, 0);
            }

            return _version;
        }
    }

    /// <inheritdoc cref="IAppInfo.CacheDirectory" />
    public string CacheDirectory
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_cacheDirectory))
            {
                _cacheDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _appName, "Cache");
            }

            return _cacheDirectory;
        }
    }

    /// <inheritdoc cref="IAppInfo.AppDataDirectory" />
    public string AppDataDirectory
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_appDataDirectory))
            {
                _appDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _appName, "Data");
            }

            return _appDataDirectory;
        }
    }
}
