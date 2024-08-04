using System.Diagnostics;
using System.Reflection;
using Bible.Abstractions.Views;
using Microsoft.Extensions.Hosting;
using Windows.ApplicationModel;
using Windows.Storage;

namespace Bible.Views.Platforms.Windows;

/// <summary>
/// <c> Windows </c> 의 정보를 가지고 있는 <see cref="Abstractions.Views.IAppInfo" /> 의 구현체입니다.
/// </summary>
internal sealed class WindowsAppInfo : IAppInfo
{
    private readonly string _appName;
    private readonly Assembly _assembly;

    private bool? _isPackaged;
    private Version? _version;
    private string _cacheDirectory;
    private string _appDataDirectory;

    /// <summary>
    /// <see cref="WindowsAppInfo" /> 를 초기화합니다.
    /// </summary>
    /// <param name="environment"> <see cref="IHostEnvironment" /> 의 구현체입니다. </param>
    public WindowsAppInfo(IHostEnvironment environment)
    {
        _appName = environment.ApplicationName;
        _assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
        _cacheDirectory = _appDataDirectory = string.Empty;
    }

    /// <inheritdoc cref="Abstractions.Views.IAppInfo.IsPackaged" />
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

    /// <inheritdoc cref="Abstractions.Views.IAppInfo.Version" />
    public Version Version
    {
        get
        {
            if (_version == null)
            {
                _version = _assembly.GetName().Version ?? new Version(0, 0, 0, 0);
                if (IsPackaged)
                {
                    PackageVersion packageVersion = Package.Current.Id.Version;
                    _version = new Version(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
                }
            }

            return _version;
        }
    }

    /// <inheritdoc cref="Abstractions.Views.IAppInfo.CacheDirectory" />
    public string CacheDirectory
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_cacheDirectory))
            {
                _cacheDirectory = IsPackaged ? ApplicationData.Current.LocalCacheFolder.Path : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _appName, "Cache");
            }

            return _cacheDirectory;
        }
    }

    /// <inheritdoc cref="Abstractions.Views.IAppInfo.AppDataDirectory" />
    public string AppDataDirectory
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_appDataDirectory))
            {
                _appDataDirectory = IsPackaged ? ApplicationData.Current.LocalFolder.Path : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _appName, "Data");
            }

            return _appDataDirectory;
        }
    }
}
