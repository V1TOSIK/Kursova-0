using System.Windows.Controls;
using System.Windows;

namespace Kursova.View.UserInterface.Pages
{
  public partial class RegistrationPage : Page
  {
    public RegistrationPage()
    {
      InitializeComponent();
    }

    private void Button_Registr_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Authorization_Click(object sender, RoutedEventArgs e)
    {
      Authorization authorizationPage = new Authorization();
      Window parentWindow = Window.GetWindow(this);
      if (parentWindow != null)
      {
        parentWindow.Content = authorizationPage;
      }

    }
  }
}
