using data.Context;
using data.Repository;
using domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace crossCutting.DependencyInjection
{
  public class ConfigureRepository
  {
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
      string connectionString = "Server=localhost;Port=3306;Database=DPSP;User Id=root;Password=@12345678#;";
      serviceCollection.AddDbContext<MyContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
  }
}
