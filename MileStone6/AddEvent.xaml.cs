using System.Windows;

namespace MileStone6
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        Presenter p;
        public AddEvent(Presenter p)
        {
            this.p = p;
            InitializeComponent();
            eventCategory.ItemsSource = p.GetCategoryNames();
        }
        private void CancelButton_CLicked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(eventDetails.Text) && eventCategory.SelectedIndex != -1 && !string.IsNullOrEmpty(eventDate.Text) && !string.IsNullOrEmpty(eventDuration.Text))
            {
                p.AddEvent(DateTime.Parse(eventDate.Text), eventCategory.SelectedIndex, int.Parse(eventDuration.Text), eventDetails.Text);
            }
            else
            {
                return;
            }

        }
    }
}
