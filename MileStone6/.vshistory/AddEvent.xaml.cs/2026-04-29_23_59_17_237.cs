using System;
using System.Windows;

namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window, ViewInterface
    {
        private string defaultDate = DateTime.Today.ToString("dd-MM-yyyy");
        private Presenter p;

        public AddEvent(string databasePath)
        {
            InitializeComponent();
            p = new Presenter(this, databasePath);
            eventCategory.ItemsSource = p.GetCategoryNames();

            // Set default date picker value
            eventDate.SelectedDate = DateTime.ParseExact(defaultDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        public void ShowMessage(string message)
        {
            ErrorBox.Text = message;
        }

        public void ShowError(string message)
        {
            ErrorBox.Text = message;
            // Optional: ErrorBox.Foreground = System.Windows.Media.Brushes.Red;
        }

        // Close() is already provided by the Window base class

        public void DisplayCurrentFile(string fileName)
        {
            this.Title = "Current file: " + fileName;
        }

        public void GetFileName()
        {
            // Implementation logic if needed
        }

        public void GetFolderName()
        {
            // Implementation logic if needed
        }

        public void OpenFileExplorer()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Database files (*.db)|*.db";

            if (dialog.ShowDialog() == true)
            {
                // Logic to handle the file path would go here
            }
        }

        public void LoadLastUsedFile()
        {
            // Implementation logic if needed
        }

        public int GetRepeatDays()
        {
            // Defaulting to 1 day as per previous logic; 
            // you might want to link this to a UI TextBox later
            return 1;
        }

        public void ResetFields()
        {
            eventDetails.Text = string.Empty;
            eventDuration.Text = string.Empty;
            eventCategory.SelectedIndex = -1;
            eventDate.SelectedDate = DateTime.ParseExact(defaultDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        public void AskToLeave()
        {
            MessageBoxResult result = MessageBox.Show("Would you like to leave?", "Exit", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        public void ConfirmUnsavedChanges()
        {
            MessageBoxResult result = MessageBox.Show("You have unsaved changes. Proceed anyway?", "Unsaved Changes", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        public void ToCategoryWindowFromEvents()
        {
            EventGrid.IsHitTestVisible = false;
            AddCategory w = new AddCategory(this, p, databasePath);
            w.Show();
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

        private void ToLeaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            p.Leaving();
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