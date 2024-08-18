using System.Diagnostics.CodeAnalysis;
using Bible.Crawler.Abstractions;
using Bible.Crawler.Abstractions.Structures;
using Bible.Repository.Abstractions;
using Bible.Repository.Abstractions.Structures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bible.Repository;

/// <summary>
/// <see cref="IBibleRepository" /> 의 구현체입니다.
/// </summary>
/// <param name="logger"> Log 를 작성할 수 있는 <see cref="ILogger{TCategoryName}" /> 의 구현체입니다. </param>
/// <param name="contextFactory"> <see cref="BibleContext" /> 객체를 생성하는 <see cref="IDbContextFactory{TContext}" /> 의 구현체입니다. </param>
/// <param name="crawlerFactory"> <see cref="IBibleCrawlerFactory" /> 의 구현체입니다. </param>
[SuppressMessage("Reliability", "CA2007:대기된 작업에 대해 ConfigureAwait 호출 고려", Justification = "https://github.com/dotnet/roslyn-analyzers/issues/5712")]
internal sealed partial class BibleRepository(ILogger<BibleRepository> logger, IDbContextFactory<BibleContext> contextFactory, IBibleCrawlerFactory crawlerFactory) : IBibleRepository
{
    /// <inheritdoc cref="IBibleRepository.InitializedAsync(VersionType)" />
    public Task<bool> InitializedAsync(VersionType versionType)
    {
        return InitializedAsync(versionType, false);
    }

    /// <inheritdoc cref="IBibleRepository.InitializedAsync(VersionType, bool)" />
    public async Task<bool> InitializedAsync(VersionType versionType, bool forceReload)
    {
        await using BibleContext context = await CreateContextAsync().ConfigureAwait(false);
        bool isNotEmpty = await context.Verses.AsNoTracking().AnyAsync().ConfigureAwait(false);

        if (forceReload || !isNotEmpty)
        {
            IBibleCrawler crawler = crawlerFactory.CreateGodpiaCrawler(versionType);
            await foreach (Book book in crawler.GetBooksAsync())
            {
                await foreach (Chapter chapter in crawler.GetChaptersAsync(book))
                {
                    await foreach (Verse verse in crawler.GetVersesAsync(chapter))
                    {
                        VerseEntity entity = new VerseEntity(ConverToBooksType(book.Name), chapter.Value, verse.Value, verse.Text);
                        await context.AddAsync(entity).ConfigureAwait(false);
                    }
                }
            }
        }

        return false;
    }

    /// <inheritdoc cref="IBibleRepository.GetVerse(BooksType, int, int)" />
    public Task<Verse> GetVerse(BooksType booksType, int chapter, int verse)
    {
        throw new NotImplementedException();
    }

    private async Task<BibleContext> CreateContextAsync()
    {
        BibleContext context = await contextFactory.CreateDbContextAsync().ConfigureAwait(false);
        bool isCreated = await context.Database.EnsureCreatedAsync().ConfigureAwait(false);
        if (isCreated)
        {
            LogToEnsureCreated(logger);
        }

        return context;
    }

    private BooksType ConverToBooksType(string bookName)
    {
        return bookName switch
        {
            "창" or "창세기" => BooksType.Genesis,
            "출" or "출애굽기" => BooksType.Exodus,
            "레" or "레위기" => BooksType.Leviticus,
            "민" or "민수기" => BooksType.Numbers,
            "신" or "신명기" => BooksType.Deuteronomy,
            "수" or "여호수아" => BooksType.Joshua,
            "삿" or "사사기" => BooksType.Judges,
            "룻" or "룻기" => BooksType.Ruth,
            "삼상" or "사무엘상" => BooksType.Samuel1,
            "삼하" or "사무엘하" => BooksType.Samuel2,
            "왕상" or "열왕기상" => BooksType.Kings1,
            "왕하" or "열왕기하" => BooksType.Kings2,
            "대상" or "역대상" => BooksType.Chronicles1,
            "대하" or "역대하" => BooksType.Chronicles2,
            "스" or "에스라" => BooksType.Ezra,
            "느" or "느헤미야" => BooksType.Nehemiah,
            "에" or "에스더" => BooksType.Esther,
            "욥" or "욥기" => BooksType.Job,
            "시" or "시편" => BooksType.Psalms,
            "잠" or "잠언" => BooksType.Proverbs,
            "전" or "전도서" => BooksType.Ecclesiastes,
            "아" or "아가" => BooksType.SongOfSongs,
            "사" or "이사야" => BooksType.Isaiah,
            "렘" or "예레미야" => BooksType.Jeremiah,
            "애" or "예레미야애가" => BooksType.Lamentations,
            "겔" or "에스겔" => BooksType.Ezekiel,
            "단" or "다니엘" => BooksType.Daniel,
            "호" or "호세아" => BooksType.Hosea,
            "욜" or "요엘" => BooksType.Joel,
            "암" or "아모스" => BooksType.Amos,
            "옵" or "오바댜" => BooksType.Obadiah,
            "욘" or "요나" => BooksType.Jonah,
            "미" or "미가" => BooksType.Micah,
            "나" or "나훔" => BooksType.Nahum,
            "합" or "하박국" => BooksType.Habakkuk,
            "습" or "스바냐" => BooksType.Zephaniah,
            "학" or "학개" => BooksType.Haggai,
            "슥" or "스가랴" => BooksType.Zechariah,
            "말" or "말라기" => BooksType.Malachi,
            "마" or "마태복음" => BooksType.Matthew,
            "막" or "마가복음" => BooksType.Mark,
            "눅" or "누가복음" => BooksType.Luke,
            "요" or "요한복음" => BooksType.John,
            "행" or "사도행전" => BooksType.Acts,
            "롬" or "로마서" => BooksType.Romans,
            "고전" or "고린도전서" => BooksType.Corinthians1,
            "고후" or "고린도후서" => BooksType.Corinthians2,
            "갈" or "갈라디아서" => BooksType.Galatians,
            "엡" or "에베소서" => BooksType.Ephesians,
            "빌" or "빌립보서" => BooksType.Philippians,
            "골" or "골로새서" => BooksType.Colossians,
            "살전" or "데살로니가전서" => BooksType.Thessalonians1,
            "살후" or "데살로니가후서" => BooksType.Thessalonians2,
            "딤전" or "디모데전서" => BooksType.Timothy1,
            "딤후" or "디모데후서" => BooksType.Timothy2,
            "딛" or "디도서" => BooksType.Titus,
            "몬" or "빌레몬서" => BooksType.Philemon,
            "히" or "히브리서" => BooksType.Hebrews,
            "약" or "야고보서" => BooksType.James,
            "벧전" or "베드로전서" => BooksType.Peter1,
            "벧후" or "베드로후서" => BooksType.Peter2,
            "요일" or "요한일서" => BooksType.John1,
            "요이" or "요한이서" => BooksType.John2,
            "요삼" or "요한삼서" => BooksType.John3,
            "유" or "유다서" => BooksType.Jude,
            "계" or "요한계시록" => BooksType.Revelation,
            _ => throw new ArgumentException($"{bookName} does not exist.")
        };
    }

    [LoggerMessage(LogLevel.Debug, "The database has been successfully created.")]
    private static partial void LogToEnsureCreated(ILogger logger);
}
