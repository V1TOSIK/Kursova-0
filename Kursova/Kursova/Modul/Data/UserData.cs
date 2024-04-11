using System;
using System.Collections.Generic;

namespace Kursova.Modul.Data
{
  public class UserData
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public ICollection<DateTime> Datetime { get; set; }

    public int UserId { get; set; }
    public virtual UserActivity Activity { get; set; }
    public virtual List<UserHealth> Healths { get; set; }

  }
}
