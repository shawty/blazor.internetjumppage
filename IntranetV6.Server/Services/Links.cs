using IntranetV6.Shared;
using System.Collections.Generic;

namespace IntranetV6.Server.Services
{
  public class Links
  {
    private readonly List<UserLink> _petersLinks = new List<UserLink>()
    {
      new UserLink() { Id = 5, DispalyText = "Lidnug.org", LinkDestination = "http://www.lidnug.org/" },
      new UserLink() { Id = 6, DispalyText = "My Blog", LinkDestination = "http://shawtyds.wordpress.com/" },
      new UserLink() { Id = 9, DispalyText = "I Can Has Cheeze Burger", LinkDestination = "http://icanhascheezburger.com/" },
      new UserLink() { Id = 12, DispalyText = "CH9 Download tool", LinkDestination = "http://dayngo.com/channel9" }
    };

    public List<UserLink> GetLinksForUser(int userId)
    {
      switch (userId)
      {
        case 1:
          return _petersLinks;

        default:
          return new List<UserLink>();
      }
    }

  }
}
