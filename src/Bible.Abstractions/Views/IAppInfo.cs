namespace Bible.Abstractions.Views;

/// <summary>
/// Application 의 정보를 가지고 있는 Service 입니다.
/// </summary>
public interface IAppInfo
{
    /// <summary>
    /// Application 이 Packaging 되어 있는지 여부를 가져옵니다.
    /// </summary>
    bool IsPackaged { get; }

    /// <summary>
    /// Application 의 Version 을 가져옵니다.
    /// </summary>
    Version Version { get; }

    /// <summary>
    /// Cache Directory 경로를 가져옵니다.
    /// </summary>
    string CacheDirectory { get; }

    /// <summary>
    /// AppData Directory 경로를 가져옵니다.
    /// </summary>
    string AppDataDirectory { get; }
}
