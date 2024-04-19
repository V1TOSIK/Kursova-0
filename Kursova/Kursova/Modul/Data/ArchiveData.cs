using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Kursova.Modul.Data
{
  public class ArchiveData
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DateId { get; set; }
    public DateTime ArchiveDateTime { get; set; }
    public string ExerciseName { get; set; }
    public double ConsumedCalories { get; set; }
    public double BurnedCalories { get; set; }
    public int Steps { get; set; }
    public double Traveled { get; set; }
    public int Pulse { get; set; }
    public string Pressure { get; set; }
    public string VolumeOxygenInBlood { get; set; }
  }
  /* public class DataRepository
   {
     private MyDBContext context;

     public DataRepository(MyDBContext context)
     {
       this.context = context;
     }

     public static List<ArchiveData> GetCombinedData(MyDBContext context, int userId)
     {
       var combinedData = (from activity in context.Activities
                           join date in context.Dates on activity.DateId equals date.Id
                           join health in context.Healths on date.Id equals health.DateId
                           where date.UserId == userId
                           select new ArchiveData
                           {
                             UserId = date.UserId,
                             DateId = date.Id,
                             ArchiveDateTime = date.Datetime,
                             ExerciseName = activity.ExerciseName,
                             ConsumedCalories = activity.ConsumedCalories,
                             BurnedCalories = activity.BurnedCalories,
                             Steps = activity.Steps,
                             Traveled = activity.Traveled,
                             Pulse = health.Pulse,
                             Pressure = health.Pressure,
                             VolumeOxygenInBlood = health.VolumeOxygenInBlood
                           }).ToList();

       return combinedData;
     }*/
}

