using IntranetV6.Shared;
using System.Collections.Generic;

namespace IntranetV6.Server.Services
{
  public class Users
  {
    private readonly Dictionary<int, User> _userData = new Dictionary<int, User>()
    {
      {1, new User(){ Id = 1, NickName = "Shawty", FullName = "Peter Shaw", Password = "NOT USED", Avatar = "Avatar-1.gif"} },
    };

    private Emails _emails;
    private Links _links;

    public Users(Emails emails, Links links)
    {
      _emails = emails;
      _links = links;
    }

    public User GetUser(int userId)
    {
      User result = _userData.ContainsKey(userId) ? _userData[userId] : null;
      if (result == null)
      {
        return null;
      }

      result.Emails = _emails.GetEmailsForUser(result.Id);
      result.Links = _links.GetLinksForUser(result.Id);

      return result;
    }

    public List<User> GetAll()
    {
      List<User> results = new List<User>();
      foreach (var user in _userData)
      {
        results.Add(user.Value);
      }
      return results;
    }

  }
}
