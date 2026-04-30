using System.Windows;
namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window, ViewInterface
    {
        private Presenter p;
        string defaultDate = DateTime.Now.AddMinutes(30).ToString("HH:mm dd/MM/yyyy");
        
        public AddEvent()
        {
            InitializeComponent();
            p = new Presenter(this);
            eventCategory.ItemsSource = p.GetCategoryNames();
            // default today date
            eventDate.SelectedDate = DateTime.ParseExact(defaultDate, "HH:mm dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
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
            ErrorBox.Text = message;
        }



        public void ResetFields()
        {
            eventDetails.Text = string.Empty;
            eventDuration.Text = string.Empty;
            eventCategory.SelectedIndex = -1;
            eventDate.SelectedDate = DateTime.ParseExact(defaultDate, "HH:mm dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
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

            //int savedCategory = eventCategory.SelectedIndex;
            //DateTime? savedDate = eventDate.SelectedDate;

            //eventDetails.Text = string.Empty;
            //eventDuration.Text = string.Empty;

            //eventCategory.SelectedIndex = savedCategory;

            //eventDate.SelectedDate = savedDate;
            return 1;

            return savedCategory;

        }

        public void AskToLeave()
        {
            MessageBoxResult result = MessageBox.Show("Would you like to leave", "Exit", button: MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
            
        }
        private void ToLeaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            p.Leaving();
        }

        public void ConfirmUnsavedChanges()
        {
            throw new NotImplementedException();
        }

        public void ToCategoryWindowFromEvents()
        {
            EventGrid.IsHitTestVisible = false;
            AddCategory w = new AddCategory(this, p);
            w.Show();

            
        }
        private void ConveniantAddCatButton_Click(object sender, RoutedEventArgs e)
        {
            p.ToCategoryWindow();
        }
        public void ReturnToEventsWindow(Presenter presfromCat)
        {
            p = presfromCat;
            EventGrid.IsHitTestVisible = true;
            eventCategory.ItemsSource = p.GetCategoryNames();
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
