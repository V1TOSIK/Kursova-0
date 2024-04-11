namespace Kursova.Modul.Data
{
  public class UserHealth
  {
    public int Id { get; set; }
    public string Pulse { get; set; }
    public string Pressure { get; set; }
    public string VolumeOxygenInBlood { get; set; }

    public int UserId { get; set; }
    public virtual UserData User { get; set; }
  }
}
