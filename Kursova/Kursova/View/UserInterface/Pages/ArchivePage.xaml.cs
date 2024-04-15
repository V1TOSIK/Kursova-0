using Kursova.Modul;
using Kursova.Modul.Data;
using System.Linq;
using System.Windows.Controls;

namespace Kursova.View.UserInterface.Pages
{
  public partial class ArchivePage : Page
  {
    private MyDBContext context;
    private UserData user;
    public ArchivePage(MyDBContext context, UserData user)
    {
      InitializeComponent();
      this.context = context;
      this.user = user;
      LoadData();
    }
    private void LoadData()
    {
      dataGrid.ItemsSource = context.Users.ToList();
    }
  }
}
