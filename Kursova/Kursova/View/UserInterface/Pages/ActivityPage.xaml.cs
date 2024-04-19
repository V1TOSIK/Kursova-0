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
    public ActivityPage(MyDBContext context, UserData user, UserDate todayUserDate)
    {
      this.context = context;
      this.user = user;
      this.todayUserDate = todayUserDate;
      InitializeComponent();
    }

    public void SaveActivityData() {
      try
      {
        if (todayUserDate == null || todayUserDate.Activity == null || todayUserDate.Activity.Capacity == 0)
        {
          todayUserDate.Activity = new List<UserActivity>();
        }


        if (todayUserDate != null)
        {
          string message = ChekingActivity(out string exerciseData, out double consumedCaloriesData, out double burnedCalories, out int stepsData, out double traveledData);
                 
          if (message == string.Empty)
          {
            todayUserDate.Activity.Add(new UserActivity()
            {
              ExerciseName = exerciseData,
              ConsumedCalories = consumedCaloriesData,
              BurnedCalories = burnedCalories,
              Steps = stepsData,
              Traveled = traveledData,
            });
            context.SaveChanges();
            ClearText();
          }
          else MessageBox.Show(message);
          
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
    private string ChekingActivity(out string exerciseData, out double consumedCaloriesData, out double burnedCalories, out int stepsData, out double traveledData)
    {
      string message = string.Empty;

      if (ExerciseBox.inputText.Text == null) { exerciseData = string.Empty; }
      else { exerciseData = ExerciseBox.inputText.Text; }

      if (double.TryParse(Calories_upvolumeBox.inputText.Text, out consumedCaloriesData))
      {
        if (consumedCaloriesData < 0) message += "Ви не можете отримати вiд'ємну кiлькiсть калорiй!\n";
        if (consumedCaloriesData > 15000) message += "Отримати таку кiлькiсть калорiй за 1 день неможливо!\n";
      }

      if (double.TryParse(Calories_downvolumeBox.inputText.Text, out burnedCalories)) {
        if(burnedCalories < 0){ message += "Ви не можете спалити вiд'ємну кiлькiсть калорiй!\n"; }
        if (burnedCalories > 20000) { message += "Спалити таку кiлькiсть калорiй за 1 день неможливо!\n"; }
      }

      if (int.TryParse(StepsBox.inputText.Text, out stepsData))
      {
        if(stepsData < 0) { message += "Кiлькiсть крокiв не може бути вiд'ємною!\n"; }
      }

      if (double.TryParse(TraveledBox.inputText.Text, out traveledData))
      {
        if (traveledData < 0) { message += "Кількість пройдених км не може бути від'ємною!\n"; }
      }

      return message;
    }
  }
}
