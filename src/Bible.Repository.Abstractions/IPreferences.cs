using System.Diagnostics.CodeAnalysis;

namespace Bible.Repository.Abstractions;

/// <summary>
/// 기본 Settings 값들을 관리하는 Preferences Service 입니다.
/// </summary>
[SuppressMessage("Naming", "CA1716:식별자는 키워드와 달라야 합니다.", Justification = "Preferences 는 Get 과 Set 함수가 있어야 해요.")]
public interface IPreferences
{
    /// <summary>
    /// <see cref="string" /> 형식의 값을 가져옵니다.
    /// </summary>
    /// <param name="key"> 저장되어 있는 값을 찾을 수 있는 Key 입니다. </param>
    /// <param name="defaultValue"> 저장되어 있는 값을 찾을 수 없을 때 반환할 기본 값입니다. </param>
    /// <param name="sharedName"> 저장되어 있는 값을 찾을 수 있는 공유된 이름입니다. </param>
    /// <returns> <paramref name="key" /> 값으로 저장되어 있는 <see cref="string" /> 값을 찾아 반환합니다. 그러나 찾을 수 없으면 <paramref name="defaultValue" /> 값을 반환합니다. </returns>
    string Get(string key, string defaultValue, string? sharedName = null);

    /// <summary>
    /// <see cref="string" /> 형식의 값을 저장합니다.
    /// </summary>
    /// <param name="key"> 저장되어 있는 값을 찾을 수 있는 Key 입니다. </param>
    /// <param name="value"> 저장할 값입니다. </param>
    /// <param name="sharedName"> 값을 저장할 공유된 이름입니다. </param>
    void Set(string key, string value, string? sharedName = null);
}
