using Kursova.Modul.Data;
using System.Data.Entity;

namespace Kursova.Modul
{
  public class MyDBContext : DbContext
  {
    public MyDBContext() : base("DBConnectionString") {

    }
    public DbSet<UserData> Users { get; set; }
    public DbSet<UserActivity> Activities { get; set; }
    public DbSet<UserHealth> Healths { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserData>()
          .HasOptional(ud => ud.Activity)
          .WithRequired(a => a.User)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<UserData>()
          .HasMany(ud => ud.Healths)
          .WithRequired(h => h.User)
          .HasForeignKey(h => h.UserId);
    }
  }
}
