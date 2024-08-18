using Bible.Repository.Abstractions.Structures;

namespace Bible.Repository;

/// <summary>
/// 성경 구절 정보를 담고 있는 Entity Class 입니다.
/// </summary>
/// <param name="book"> 성경 책 정보입니다. </param>
/// <param name="chapter"> 성경 책의 Chapter 정보입니다. </param>
/// <param name="verse"> 성경 책의 Verse 정보입니다. </param>
/// <param name="verseText"> 성경 구절 정보입니다. </param>
internal sealed class VerseEntity(BooksType book, int chapter, int verse, string verseText)
{
    /// <summary>
    /// 성경 책 정보를 가져옵니다.
    /// </summary>
    public BooksType Book => book;

    /// <summary>
    /// 성경 책의 Chapter 정보를 가져옵니다.
    /// </summary>
    public int Chapter => chapter;

    /// <summary>
    /// 성경 책의 Verse 정보를 가져옵니다.
    /// </summary>
    public int Verse => verse;

    /// <summary>
    /// 성경 구절 정보를 가져옵니다.
    /// </summary>
    public string VerseText => verseText;
}
