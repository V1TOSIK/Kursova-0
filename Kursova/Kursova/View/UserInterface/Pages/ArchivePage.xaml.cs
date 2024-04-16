using Kursova.Modul;
using Kursova.Modul.Data;
using System.Linq;
using System.Windows.Controls;

namespace Kursova.View.UserInterface.Pages
{
  public partial class ArchivePage : Page
  {
    private MyDBContext context;
    private UserData user;
    private UserDate todayUserDate;
    public ArchivePage(MyDBContext context, UserData user, UserDate todayUserDate)
    {
      InitializeComponent();
      this.context = context;
      this.user = user;
      this.todayUserDate = todayUserDate;
      LoadData();
    }
    private void LoadData()
    {
        var combinedData = (from activity in context.Activities
                            join health in context.Healths on activity.DateId equals health.DateId
                            select new CombinedData
                            {
                              Date = activity.Date.Datetime,
                              ExerciseName = activity.ExerciseName,
                              ConsumedCalories = activity.ConsumedCalories,
                              BurnedCalories = activity.BurnedCalories,
                              Steps = activity.Steps,
                              Traveled = activity.Traveled,
                              Pulse = health.Pulse,
                              Pressure = health.Pressure,
                              VolumeOxygenInBlood = health.VolumeOxygenInBlood
                            }).ToList();

        myDataGrid.ItemsSource = combinedData;
      /*myDataGrid.ItemsSource = context.Activities.ToList();
      myDataGrid.ItemsSource = context.Healths.ToList();*/
    }
  }
}
