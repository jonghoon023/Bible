using Microsoft.EntityFrameworkCore;

namespace Bible.Repository;

/// <summary>
/// Database 의 추상 Context Class 입니다.
/// </summary>
internal abstract class DbContextBase : DbContext
{
    private const string MemoryConnectionString = "Filename=:memory:";

    /// <summary>
    /// <see cref="DbContextBase" /> 를 초기화합니다.
    /// </summary>
    /// <param name="options"> <see cref="DbContextOptions" /> 객체입니다. </param>
    protected DbContextBase(DbContextOptions options) : base(options)
    {
        if (Database.GetDbConnection().ConnectionString.Contains(MemoryConnectionString, StringComparison.OrdinalIgnoreCase))
        {
            Database.EnsureDeleted();
        }

        Database.OpenConnection();
    }

    /// <inheritdoc cref="DbContext.Dispose" />
    public override void Dispose()
    {
        Database.CloseConnection();
        base.Dispose();
    }
}
