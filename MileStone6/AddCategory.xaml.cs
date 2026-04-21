using System.Windows;

namespace MileStone6
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void CancelButton_CLicked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
