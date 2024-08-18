using Bible.Repository.Abstractions.Structures;
using Microsoft.EntityFrameworkCore;

namespace Bible.Repository;

/// <summary>
/// 성경 정보가 있는 <see cref="DbContext" /> Class 입니다.
/// </summary>
internal sealed class BibleContext : DbContextBase
{
    /// <summary>
	/// <see cref="BibleContext" /> 를 초기화합니다.
	/// </summary>
	/// <param name="options"> <see cref="BibleContext" /> 에 대한 Database 구성이 담긴 <see cref="DbContextOptions{TContext}" /> 객체입니다. </param>
	public BibleContext(DbContextOptions<BibleContext> options) : base(options)
    {
        Verses = Set<VerseEntity>();
    }

    /// <summary>
	/// 성경 구절 목록을 가져옵니다.
	/// </summary>
	public DbSet<VerseEntity> Verses { get; }

    /// <inheritdoc cref="DbContext.OnModelCreating(ModelBuilder)" />
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VerseEntity>(buildAction => buildAction
            .Property(propertyExpression => propertyExpression.Book)
            .HasConversion(book => book.ToString(), book => Enum.Parse<BooksType>(book)));

        base.OnModelCreating(modelBuilder);
    }
}
