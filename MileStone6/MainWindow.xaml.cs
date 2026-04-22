using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MileStone6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Presenter p;
        public MainWindow()
        {
            if (p is null)
            {
                p = new Presenter();
            }
            InitializeComponent();
        }

        private void ToAddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategory w = new AddCategory(p);
            w.Show();
            this.Close();           
        }

        private void ToAddEventButton_Click(object sender, RoutedEventArgs e)
        {
            AddEvent w = new AddEvent(p);
            w.Show();
            this.Close();
        }
    }
}