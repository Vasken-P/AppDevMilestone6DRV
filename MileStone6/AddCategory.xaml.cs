using System.Windows;

namespace MileStone6
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        Presenter p;
        public AddCategory(Presenter p)
        {
            this.p = p;
            InitializeComponent();
            CategoryTypes.ItemsSource = p.GetCategoryTypeNames();
        }
        private void CancelButton_CLicked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CategoryDescription.Text) && CategoryTypes.SelectedIndex != -1)
            {
                p.AddCategory(CategoryDescription.Text, CategoryTypes.SelectedIndex);
            }
            else
            {
                return;
            }
        }
    }
}
