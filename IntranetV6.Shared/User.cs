using System.Collections.Generic;

namespace IntranetV6.Shared
{
  public class User
  {
    public int Id { get; set; }
    public string NickName { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
    public List<UserEmail> Emails { get; set; }
    public List<UserLink> Links { get; set; }

    public User()
    {
      Emails = new List<UserEmail>();
      Links = new List<UserLink>();
    }

  }
}
