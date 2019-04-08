using IntranetV6.Client.DataModels;
using IntranetV6.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntranetV6.Client.Services
{
  public class Users
  {
    private HttpClient _httpClient;

    public Users(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public LoginResponse Authenticate(string userName, string password)
    {
      if (userName == "shawty" && password == "letmein")
      {        
        return new LoginResponse()
        {
          LoginName = userName,
          EmailAddress = "shawty@example.com",
          DisplayName = "Peter Shaw",
          Roles = new List<string>() { "admin", "user" },
          Success = true
        };
      }

      return new LoginResponse()
      {
        Success = false
      };
    }

    public async Task<List<User>> FetchAllUsers()
    {
      return await _httpClient.GetJsonAsync<List<User>>("api/users/all");
    }

  }
}
