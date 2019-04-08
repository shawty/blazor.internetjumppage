using IntranetV6.Shared;
using System.Collections.Generic;

namespace IntranetV6.Server.Services
{
  public class Emails
  {
    private readonly List<UserEmail> _petersEmails = new List<UserEmail>()
    {
      new UserEmail() { Id = 3, Email = "shawty.d.ds@googlemail.com", Description = "External Web Mail Account"},
      new UserEmail() { Id = 4, Email = "shawty_ds@yahoo.com", Description = "The place where the rubbish and the spam gets sent to"},
    };

    public List<UserEmail> GetEmailsForUser(int userId)
    {
      switch (userId)
      {
        case 1:
          return _petersEmails;

        default:
          return new List<UserEmail>();
      }
    }

  }
}
