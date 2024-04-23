﻿using Kursova.Modul;
using Kursova.Modul.Data;
using Kursova.View.UserInterface.Pages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Kursova
{
  public partial class MainWindow : Window
  {
    private MyDBContext context = new MyDBContext();
    private UserData user = new UserData();
    private UserDate todayUserDate;
    private ActivityPage activityPage;
    private HealthyPage healthyPage;
    public MainWindow(UserData user, MyDBContext context)
    {
      InitializeComponent();
      this.context = context;
      this.user = user;

    }
    private void SaveDataButton_Click(object sender, RoutedEventArgs e)
    {
      if (activityPage != null && mainFrame.Content == activityPage) activityPage.SaveActivityData();
      if (healthyPage != null && mainFrame.Content == healthyPage) healthyPage.SaveHealthData();
      
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      

      DateTimeBlock.Text = DateTime.Today.ToString("dd.MM.yyyy");
      DateTime today = DateTime.Today;
      try
      {
        bool userTimeExists = context.Dates.Any(t => t.UserId == user.Id && t.Datetime == today);

        if (userTimeExists)
        {
          todayUserDate = context.Dates.FirstOrDefault(t => t.UserId == user.Id && t.Datetime == today);
        }
        else
        {
          todayUserDate = new UserDate()
          {
            Datetime = today,
            UserId = user.Id,
          };
          context.Dates.Add(todayUserDate);
          context.SaveChanges();
          MessageBox.Show("Нову дату було створено!");
        }
        if (activityPage == null) activityPage = new ActivityPage(context, user, todayUserDate);
        if (healthyPage == null) healthyPage = new HealthyPage(context, user, todayUserDate);
      }
      catch (Exception ex)
      {
        MessageBox.Show("error: " + ex.Message);
        throw;
      }
    }
    private void activity_button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      Frame parentFrame = mainFrame;
      if (parentFrame != null)
      {
        parentFrame.Content = activityPage;
      }
    }
    
    private void health_page_button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      Frame parentWindow = mainFrame;
      if (parentWindow != null)
      {
        parentWindow.Content = healthyPage;
      }
    }

    private void archive_page_button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      ArchivePage archivePage = new ArchivePage(context, user, todayUserDate);
      Frame parentWindow = mainFrame;
      if (parentWindow != null)
      {
        parentWindow.Content = archivePage;
      }

    }
  }
}
