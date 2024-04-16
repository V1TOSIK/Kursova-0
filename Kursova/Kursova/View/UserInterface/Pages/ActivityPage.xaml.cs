using Kursova.Modul;
using Kursova.Modul.Data;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Kursova.View.UserInterface.Pages
{
  public partial class ActivityPage : Page
  {
    private MyDBContext context;
    private UserData user;
    private UserDate todayUserDate;
    public ActivityPage(MyDBContext context,UserData user, UserDate todayUserDate)
    {
      this.context = context;
      this.user = user;
      this.todayUserDate = todayUserDate;
      InitializeComponent();
    }
   
    public void SaveActivityData() {
      try
      {
        if (todayUserDate != null || todayUserDate.Activity != null || todayUserDate.Activity.Capacity == 0)
        {
          todayUserDate.Activity = new List<UserActivity>();
        }
        if (todayUserDate != null)
        {
          todayUserDate.Activity.Add(new UserActivity()
          {
            ExerciseName = ExerciseBox.inputText.Text,
            ConsumedCalories = double.Parse(Calories_upvolumeBox.inputText.Text),
            BurnedCalories = double.Parse(Calories_downvolumeBox.inputText.Text),
            Steps = int.Parse(StepsBox.inputText.Text),
            Traveled = double.Parse(TraveledBox.inputText.Text),
          });
          ClearText();
          context.SaveChanges();
        }
        else { MessageBox.Show("today == null"); }
      }
      catch (Exception ex)
      {

        MessageBox.Show($"error: {ex}");
      }
    }
    private void ClearText()
    {
      ExerciseBox.inputText.Text = string.Empty;
      Calories_upvolumeBox.inputText.Text = string.Empty;
      Calories_downvolumeBox.inputText.Text = string.Empty;
      StepsBox.inputText.Text = string.Empty;
      TraveledBox.inputText.Text = string.Empty;
    }
  }
}
