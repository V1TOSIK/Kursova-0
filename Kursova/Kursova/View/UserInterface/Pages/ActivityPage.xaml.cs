using Kursova.Modul;
using Kursova.Modul.Data;
using System.Windows.Controls;

namespace Kursova.View.UserInterface.Pages
{
  public partial class ActivityPage : Page
  {
    private MyDBContext context;
    private UserData user;
    public ActivityPage(MyDBContext context,UserData user)
    {
      this.context = context;
      this.user = user;
      InitializeComponent();
    }

  }
}
