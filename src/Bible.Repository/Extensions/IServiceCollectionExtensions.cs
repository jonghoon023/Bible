using Bible.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.Repository.Extensions;

/// <summary>
/// <see cref="IServiceCollection" /> 에 대한 확장 함수가 있는 정적 Class 입니다.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
	/// <see cref="IBibleRepository" /> 의 구현체를 등록합니다.
	/// </summary>
	/// <remarks> <see cref="IBibleRepository" /> 구현체의 생명 주기는 <see cref="ServiceLifetime.Singleton" /> 입니다. </remarks>
	/// <param name="services"> <see cref="IServiceCollection" /> 의 구현체입니다. </param>
	/// <param name="configuration"> <see cref="IConfiguration" /> 의 구현체입니다. </param>
	/// <returns> <see cref="IBibleRepository" /> 의 구현체를 등록 후 <see cref="IServiceCollection" /> 을 반환합니다. </returns>
	public static IServiceCollection AddBibleRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<BibleContext>(optionsAction =>
        {
            string? connectionString = configuration.GetConnectionString(nameof(BibleContext));
            optionsAction.UseSqlite(connectionString);
        });

        return services.AddSingleton<IBibleRepository, BibleRepository>();
    }
}
