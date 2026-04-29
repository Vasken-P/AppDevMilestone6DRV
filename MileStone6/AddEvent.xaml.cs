using System.Windows;
namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window, ViewInterface
    {
        private string defaultDate = DateTime.Today.ToString("dd-MM-yyyy");
        private readonly Presenter p;
        public AddEvent()
        {
            InitializeComponent();
            p = new Presenter(this);
            eventCategory.ItemsSource = p.GetCategoryNames();

            // default today date
            eventDate.SelectedDate = DateTime.Today;
        }
        private void CancelButton_CLicked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            p.AddEvent(DateTime.Parse(eventDate.SelectedDate.ToString()!), eventCategory.SelectedIndex, eventDuration.Text, eventDetails.Text);
        }


        public void ShowError(string message)
        {
            ErrorBox.Text = message;
            //BorderBrush = "Crimson" BorderThickness = "5"
        }

        public void ShowMessage(string message)
        {

            MessageBox.Show(message);

        }

        public void DisplayCurrentFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void GetFileName()
        {
            throw new NotImplementedException();
        }

        public void GetFolderName()
        {
            throw new NotImplementedException();
        }

        public void OpenFileExplorer()
        {
            throw new NotImplementedException();
        }

        public void LoadLastUsedFile()
        {
            throw new NotImplementedException();
        }

        public int GetRepeatDays()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultDate(string date)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultTime(string time)
        {
            throw new NotImplementedException();
        }

        public void SetCategories(List<string> categories)
        {
            throw new NotImplementedException();
        }

        public void ResetFields()
        {
            eventCategory.SelectedIndex = -1;
            eventDetails.Text = string.Empty;
            eventDate.SelectedDate = DateTime.Parse(defaultDate);
            eventDuration.Text = string.Empty;

        }

        public void KeepCategoryAndDate()
        {

            int savedCategory = eventCategory.SelectedIndex;
            DateTime? savedDate = eventDate.SelectedDate;

            eventDetails.Text = string.Empty;
            eventDuration.Text = string.Empty;

            eventCategory.SelectedIndex = savedCategory;

            eventDate.SelectedDate = savedDate;

        }

        public string GetCategoryDescription()
        {
            throw new NotImplementedException();
        }

        public void ClearCategoryFields()
        {
            throw new NotImplementedException();
        }

        public void ConfirmUnsavedChanges()
        {
            throw new NotImplementedException();
        }


        //private void eventDuration_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{
        //    if (char.IsLetter(eventDuration.Text[eventDuration.Text.Length - 1]))
        //    {
        //        eventDuration.Text = eventDuration.Text.Remove(eventDuration.Text[eventDuration.Text.Length - 1]);
        //    }
        //}
    }
}
