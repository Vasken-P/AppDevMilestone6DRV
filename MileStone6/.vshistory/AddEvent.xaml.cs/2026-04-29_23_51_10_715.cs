using System;
using System.Windows;

namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window, ViewInterface
    {
        // Fixed: Ensure the string format matches the parsing logic later
        private string defaultDate = DateTime.Today.ToString("dd-MM-yyyy");
        private Presenter p; // Removed 'readonly' because ReturnToEventsWindow reassigns it

        public AddEvent(string databasePath)
        {
            InitializeComponent();
            p = new Presenter(this, databasePath);
            eventCategory.ItemsSource = p.GetCategoryNames();

            // Fixed: Default date initialization to match the "dd-MM-yyyy" format
            eventDate.SelectedDate = DateTime.ParseExact(defaultDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        private void CancelButton_CLicked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (eventDate.SelectedDate.HasValue)
            {
                p.AddEvent(eventDate.SelectedDate.Value, eventCategory.SelectedIndex, eventDuration.Text, eventDetails.Text);
            }
            else
            {
                ShowError("Please select a date.");
            }
        }

        public void ShowError(string message)
        {
            ErrorBox.Text = message;
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
            eventDate.SelectedDate = DateTime.ParseExact(defaultDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        public void DisplayCurrentFile(string fileName)
        {
            this.Title = "Current file: " + fileName;
        }

        public string GetFileName() => "";

        public string GetFolderName() => "";

        public string OpenFileExplorer()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Database files (*.db)|*.db";

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return "";
        }

        public string LoadLastUsedFile() => "";

        public int GetRepeatDays()
        {
            return 1; // Removed unreachable return statement below this
        }

        public void AskToLeave()
        {
            MessageBoxResult result = MessageBox.Show("Would you like to leave", "Exit", MessageBoxButton.OKCancel);
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
            // Implementation needed based on your business logic
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
            this.p = presfromCat;
            EventGrid.IsHitTestVisible = true;
            eventCategory.ItemsSource = p.GetCategoryNames();
        }
    }
}