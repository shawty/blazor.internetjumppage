using Blazored.LocalStorage;
using IntranetV6.BlazorUtils;
using IntranetV6.Client.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IntranetV6.Client
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      // DI SIngletons
      services.AddSingleton<ApplicationState>();

      // DI Transients
      services.AddTransient<Users>();

      // Other adds from NuGet and 3rd party libs
      services.AddBlazoredLocalStorage();
      services.AddBlazorUtils();
    }

    public void Configure(IComponentsApplicationBuilder app)
    {
      app.AddComponent<App>("app");
    }
  }
}
