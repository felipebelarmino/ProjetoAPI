using domain.Services.User;
using Microsoft.Extensions.DependencyInjection;
using services;

namespace crossCutting.DependencyInjection
{
  public class ConfigureService
  {
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
      
      serviceCollection.AddTransient<IUserService, UserService>();
    }
   
  }
}