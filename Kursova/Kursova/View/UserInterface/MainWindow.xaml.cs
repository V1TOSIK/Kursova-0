using Kursova.Modul;
using Kursova.Modul.Data;
using Kursova.View.UserInterface.Pages;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Kursova
{
  public partial class MainWindow : Window
  {
    private MyDBContext context = new MyDBContext();
    private UserData user = new UserData();
    public MainWindow(UserData user, MyDBContext context)
    {
      InitializeComponent();
      this.context = context;
      this.user = user;
    }
    private void SaveDataButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      DateTimeBlock.Text = DateTime.Today.ToString("dd.MM.yyyy");
      DateTime today = DateTime.Today;
      try
      {
        bool userDateExists = context.Users.Any(d => d.Id == user.Id);
        bool userTimeExists = context.Dates.Any(t => t.Id == user.Id && t.Datetime == today);

        if (!userDateExists && !userTimeExists)
        {
          
        }
        context.SaveChanges();
      }
      catch (Exception ex)
      {
        MessageBox.Show("error: " + ex.Message);
        throw;
      }
    }

    private void activity_button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      ActivityPage activityPage = new ActivityPage(context, user);
      Frame parentFrame = mainFrame;
      if (parentFrame != null)
      {
        parentFrame.Content = activityPage;
      }
    }

    private void health_page_button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      HealthyPage healthyPage = new HealthyPage(context, user);
      Frame parentWindow = mainFrame;
      if (parentWindow != null)
      {
        parentWindow.Content = healthyPage;
      }
    }

    private void archive_page_button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      ArchivePage archivePage = new ArchivePage(context, user);
      Frame parentWindow = mainFrame;
      if (parentWindow != null)
      {
        parentWindow.Content = archivePage;
      }

    }
  }
}
