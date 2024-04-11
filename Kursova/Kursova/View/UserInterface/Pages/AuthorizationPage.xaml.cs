using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Kursova.View.UserControls;

namespace Kursova.View.UserInterface.Pages
{
  public partial class Authorization : Page
  {
    public Authorization()
    {
      InitializeComponent();
    }
    

    private void Button_Authorization_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }

    private void Button_Registration_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      RegistrationPage registrationPage = new RegistrationPage();
      Window parentWindow = Window.GetWindow(this);
      if (parentWindow != null)
      {
        parentWindow.Content = registrationPage;
      }

    }
  }
}
