using System;
using Microsoft.AspNetCore.Identity;
using VND.Fw.Domain;

namespace VND.Fw.Infrastructure.EfCore.Identity
{
  public class ApplicationUser : IdentityUser<Guid>, IEntity
  {
    public string LastName
    {
      get;
      set;
    }

    public string FirstName
    {
      get;
      set;
    }
  }
}
