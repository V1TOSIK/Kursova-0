using System;
using System.Collections.Generic;
using System.Linq;
namespace Kursova.Modul.Data
{
  public class CombinedData
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string ExerciseName { get; set; }
    public double ConsumedCalories { get; set; }
    public double BurnedCalories { get; set; }
    public int Steps { get; set; }
    public double Traveled { get; set; }
    public int Pulse { get; set; }
    public string Pressure { get; set; }
    public string VolumeOxygenInBlood { get; set; }
  }
}
