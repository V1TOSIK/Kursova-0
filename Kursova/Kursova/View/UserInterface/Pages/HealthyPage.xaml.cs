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
      if (todayUserDate == null || todayUserDate.Health == null || todayUserDate.Health.Count == 0) { todayUserDate.Health = new List<UserHealth>(); }

      if (todayUserDate != null) {

        string message = ChekingHealth(out int pulse, out string pressure, out string volumeOxygenInBlood);

        if (message == string.Empty)
        {
          todayUserDate.Health.Add(new UserHealth()
          {
            Pulse = pulse,
            Pressure = pressure,
            VolumeOxygenInBlood = volumeOxygenInBlood,
          }
        );
          context.SaveChanges();
          ClearText();
        }
        else MessageBox.Show( message );
        
      }
      else { MessageBox.Show("today == null"); }
    }
    private void ClearText()
    {
      PulseBox.inputText.Text = string.Empty;
      PressureBox.inputText.Text = string.Empty;
      OxygenInBloodBox.inputText.Text = string.Empty;
    }
    private string ChekingHealth(out int pulse, out string pressure, out string volumeOxygenInBlood)
    {
      string message = string.Empty;

      if (int.TryParse(PulseBox.inputText.Text, out pulse))
      {
        if (pulse < 0) message += "Пульс не може бути від'ємним!\n";
        if (pulse > 300) message += "Такий пульс неможливий!\n";
      }

      if (PressureBox.inputText.Text == null) { pressure = string.Empty; }
      else { pressure = PressureBox.inputText.Text; }

      if (OxygenInBloodBox.inputText.Text == null) { volumeOxygenInBlood = string.Empty; }
      else { volumeOxygenInBlood = OxygenInBloodBox.inputText.Text; }

      return message;
    }
  }
}
