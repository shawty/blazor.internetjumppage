using Microsoft.Extensions.DependencyInjection;

namespace IntranetV6.BlazorUtils
{
  public static class BlazorUtils
  {
    public static IServiceCollection AddBlazorUtils(this IServiceCollection services)
    {
      return services.AddSingleton<UtilsInterop>();
    }

  }
}
