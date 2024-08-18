namespace Bible.Repository.Abstractions.Structures;

/// <summary>
/// 성경 책 목록입니다.
/// </summary>
public enum BooksType
{
    /// <summary>
    /// 구약의 창세기입니다.
    /// </summary>
    Genesis,

    /// <summary>
    /// 구약의 출애굽기입니다.
    /// </summary>
    Exodus,

    /// <summary>
    /// 구약의 레위기입니다.
    /// </summary>
    Leviticus,

    /// <summary>
    /// 구약의 민수기입니다.
    /// </summary>
    Numbers,

    /// <summary>
    /// 구약의 신명기입니다.
    /// </summary>
    Deuteronomy,

    /// <summary>
    /// 구약의 여호수아입니다.
    /// </summary>
    Joshua,

    /// <summary>
    /// 구약의 사사기입니다.
    /// </summary>
    Judges,

    /// <summary>
    /// 구약의 룻기입니다.
    /// </summary>
    Ruth,

    /// <summary>
    /// 구약의 사무엘상입니다.
    /// </summary>
    Samuel1,

    /// <summary>
    /// 구약의 사무엘하입니다.
    /// </summary>
    Samuel2,

    /// <summary>
    /// 구약의 열왕기상입니다.
    /// </summary>
    Kings1,

    /// <summary>
    /// 구약의 열왕기하입니다.
    /// </summary>
    Kings2,

    /// <summary>
    /// 구약의 역대상입니다.
    /// </summary>
    Chronicles1,

    /// <summary>
    /// 구약의 역대하입니다.
    /// </summary>
    Chronicles2,

    /// <summary>
    /// 구약의 에스라입니다.
    /// </summary>
    Ezra,

    /// <summary>
    /// 구약의 느헤미야입니다.
    /// </summary>
    Nehemiah,

    /// <summary>
    /// 구약의 에스더입니다.
    /// </summary>
    Esther,

    /// <summary>
    /// 구약의 욥기입니다.
    /// </summary>
    Job,

    /// <summary>
    /// 구약의 시편입니다.
    /// </summary>
    Psalms,

    /// <summary>
    /// 구약의 잠언입니다.
    /// </summary>
    Proverbs,

    /// <summary>
    /// 구약의 전도서입니다.
    /// </summary>
    Ecclesiastes,

    /// <summary>
    /// 구약의 아가입니다.
    /// </summary>
    SongOfSongs,

    /// <summary>
    /// 구약의 이사야입니다.
    /// </summary>
    Isaiah,

    /// <summary>
    /// 구약의 예레미야입니다.
    /// </summary>
    Jeremiah,

    /// <summary>
    /// 구약의 예레미야애가입니다.
    /// </summary>
    Lamentations,

    /// <summary>
    /// 구약의 에스겔입니다.
    /// </summary>
    Ezekiel,

    /// <summary>
    /// 구약의 다니엘입니다.
    /// </summary>
    Daniel,

    /// <summary>
    /// 구약의 호세아입니다.
    /// </summary>
    Hosea,

    /// <summary>
    /// 구약의 요엘입니다.
    /// </summary>
    Joel,

    /// <summary>
    /// 구약의 아모스입니다.
    /// </summary>
    Amos,

    /// <summary>
    /// 구약의 오바댜입니다.
    /// </summary>
    Obadiah,

    /// <summary>
    /// 구약의 요나입니다.
    /// </summary>
    Jonah,

    /// <summary>
    /// 구약의 미가입니다.
    /// </summary>
    Micah,

    /// <summary>
    /// 구약의 나훔입니다.
    /// </summary>
    Nahum,

    /// <summary>
    /// 구약의 하박국입니다.
    /// </summary>
    Habakkuk,

    /// <summary>
    /// 구약의 스바냐입니다.
    /// </summary>
    Zephaniah,

    /// <summary>
    /// 구약의 학개입니다.
    /// </summary>
    Haggai,

    /// <summary>
    /// 구약의 스가랴입니다.
    /// </summary>
    Zechariah,

    /// <summary>
    /// 구약의 말라기입니다.
    /// </summary>
    Malachi,

    /// <summary>
    /// 신약의 마태복음입니다.
    /// </summary>
    Matthew,

    /// <summary>
    /// 신약의 마가복음입니다.
    /// </summary>
    Mark,

    /// <summary>
    /// 신약의 누가복음입니다.
    /// </summary>
    Luke,

    /// <summary>
    /// 신약의 요한복음입니다.
    /// </summary>
    John,

    /// <summary>
    /// 신약의 사도행전입니다.
    /// </summary>
    Acts,

    /// <summary>
    /// 신약의 로마서입니다.
    /// </summary>
    Romans,

    /// <summary>
    /// 신약의 고린도전서입니다.
    /// </summary>
    Corinthians1,

    /// <summary>
    /// 신약의 고린도후서입니다.
    /// </summary>
    Corinthians2,

    /// <summary>
    /// 신약의 갈라디아서입니다.
    /// </summary>
    Galatians,

    /// <summary>
    /// 신약의 에베소서입니다.
    /// </summary>
    Ephesians,

    /// <summary>
    /// 신약의 빌립보서입니다.
    /// </summary>
    Philippians,

    /// <summary>
    /// 신약의 골로새서입니다.
    /// </summary>
    Colossians,

    /// <summary>
    /// 신약의 데살로니가전서입니다.
    /// </summary>
    Thessalonians1,

    /// <summary>
    /// 신약의 데살로니가후서입니다.
    /// </summary>
    Thessalonians2,

    /// <summary>
    /// 신약의 디모데전서입니다.
    /// </summary>
    Timothy1,

    /// <summary>
    /// 신약의 디모데후서입니다.
    /// </summary>
    Timothy2,

    /// <summary>
    /// 신약의 디도서입니다.
    /// </summary>
    Titus,

    /// <summary>
    /// 신약의 빌레몬서입니다.
    /// </summary>
    Philemon,

    /// <summary>
    /// 신약의 히브리서입니다.
    /// </summary>
    Hebrews,

    /// <summary>
    /// 신약의 야고보서입니다.
    /// </summary>
    James,

    /// <summary>
    /// 신약의 베드로전서입니다.
    /// </summary>
    Peter1,

    /// <summary>
    /// 신약의 베드로후서입니다.
    /// </summary>
    Peter2,

    /// <summary>
    /// 신약의 요한1서입니다.
    /// </summary>
    John1,

    /// <summary>
    /// 신약의 요한2서입니다.
    /// </summary>
    John2,

    /// <summary>
    /// 신약의 요한3서입니다.
    /// </summary>
    John3,

    /// <summary>
    /// 신약의 유다서입니다.
    /// </summary>
    Jude,

    /// <summary>
    /// 신약의 요한계시록입니다.
    /// </summary>
    Revelation
}
