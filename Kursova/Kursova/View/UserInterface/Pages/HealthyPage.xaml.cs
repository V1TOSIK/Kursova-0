using Kursova.Modul;
using Kursova.Modul.Data;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using System;

namespace Kursova.View.UserInterface.Pages
{
  public partial class HealthyPage : Page
  {
    private MyDBContext context;
    private UserData user;
    private UserDate todayUserDate;
    public HealthyPage(MyDBContext context, UserData user, UserDate todayUserDate)
    {
      InitializeComponent();
      this.context = context;
      this.user = user;
      this.todayUserDate = todayUserDate;
    }
    public void SaveHealthData() {
      if (todayUserDate != null || todayUserDate.Health == null || todayUserDate.Health.Count == 0) { todayUserDate.Health = new List<UserHealth>(); }
      if (todayUserDate != null) {
        todayUserDate.Health.Add(new UserHealth()
        {
          Pulse = int.Parse( PulseBox.inputText.Text),
          Pressure = PressureBox.inputText.Text,
          VolumeOxygenInBlood = OxygenInBloodBox.inputText.Text,
        }
        );
        context.SaveChanges();
        ClearText();
      }
      else { MessageBox.Show("today == null"); }
    }
    private void ClearText()
    {
      PulseBox.inputText.Text = string.Empty;
      PressureBox.inputText.Text = string.Empty;
      OxygenInBloodBox.inputText.Text = string.Empty;
    }
  }
}
