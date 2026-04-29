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

namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        
        public MainWindow()
        {   
            InitializeComponent();
        }

        public void ClearCategoryFields()
        {
            throw new NotImplementedException();
        }

        private void ToAddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategory w = new AddCategory();
            w.Show();
            this.Close();           
        }

        private void ToAddEventButton_Click(object sender, RoutedEventArgs e)
        {
            AddEvent w = new AddEvent();
            w.Show();
            this.Close();
        }
    }
}