using System.Collections.Generic;

namespace IntranetV6.Client.DataModels
{
  public class LoginResponse
  {
    public string LoginName { get; set; }
    public string EmailAddress { get; set; }
    public string DisplayName { get; set; }
    public List<string> Roles { get; set; }
    public bool Success { get; set; }
  }

}
