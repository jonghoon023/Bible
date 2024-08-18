using Bible.Crawler.Abstractions.Structures;
using Bible.Repository.Abstractions.Structures;

namespace Bible.Repository.Abstractions;

/// <summary>
/// 성경 정보를 가지고 있는 저장소입니다.
/// </summary>
public interface IBibleRepository
{
    /// <summary>
    /// Repository 를 초기화합니다.
    /// </summary>
    /// <param name="versionType"> 초기화할 성경 역본입니다. </param>
    /// <remarks> 처음으로 호출하면 Web 에서 Data 를 읽어와 초기화하고, 이미 초기화되어 있으면 아무 작업도 수행하지 않습니다. </remarks>
    /// <returns> 초기화하는데 성공했다면 <see langword="true" /> 를 반환하고, 실패했다면 <see langword="false" /> 를 반환합니다. </returns>
    Task<bool> InitializedAsync(VersionType versionType);

    /// <summary>
    /// Repository 를 초기화합니다.
    /// </summary>
    /// <param name="versionType"> 초기화할 성경 역본입니다. </param>
    /// <param name="forceReload"> 강제로 다시 Web 에서 Data 를 읽어와 초기화할지 여부입니다. </param>
    /// <returns> 초기화하는데 성공했다면 <see langword="true" /> 를 반환하고, 실패했다면 <see langword="false" /> 를 반환합니다. </returns>
    Task<bool> InitializedAsync(VersionType versionType, bool forceReload);

    /// <summary>
    /// 성경 구절을 가져옵니다.
    /// </summary>
    /// <param name="booksType"> 성경 책명입니다. </param>
    /// <param name="chapter"> 성경의 장 수입니다. </param>
    /// <param name="verse"> 성경의 절 수입니다. </param>
    /// <returns> 성경 구절 정보가 담긴 <see cref="Verse" /> 구조체를 반환합니다. </returns>
    Task<Verse> GetVerse(BooksType booksType, int chapter, int verse);
}
