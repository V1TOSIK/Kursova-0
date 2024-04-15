using Kursova.Modul;
using Kursova.Modul.Data;
using System.Windows.Controls;

namespace Kursova.View.UserInterface.Pages
{
  public partial class HealthyPage : Page
  {
    private MyDBContext context;
    private UserData user;
    public HealthyPage(MyDBContext context, UserData user)
    {
      InitializeComponent();
      this.context = context;
      this.user = user;
    }
  }
}
