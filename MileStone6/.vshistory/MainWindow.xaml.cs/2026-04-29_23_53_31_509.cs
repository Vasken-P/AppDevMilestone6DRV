using System;
using System.Windows;
using Microsoft.Win32;

namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ViewInterface
    {
        private Presenter _presenter;
        private string _databasePath;

        public MainWindow()
        {
            InitializeComponent();

            // First time setup logic
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Choose or create a database file";
            dialog.Filter = "Database files (*.db)|*.db";
            dialog.FileName = "MyCalendar.db";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _databasePath = dialog.FileName;
                _presenter = new Presenter(this, _databasePath);
                MessageBox.Show("File selected: " + _databasePath);
            }
            else
            {
                MessageBox.Show("You must select a file to continue.");
                this.Close();
            }
        }

        #region Navigation / Event Handlers
        private void ToAddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Fixed: Removed duplicate variable declaration from merge
            AddCategory w = new AddCategory(_databasePath);
            w.Show();
            this.Close();
        }

        private void ToAddEventButton_Click(object sender, RoutedEventArgs e)
        {
            AddEvent w = new AddEvent(_databasePath);
            w.Show();
            this.Close();
        }

        private void ToLeaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            AskToLeave();
        }
        #endregion

        #region ViewInterface Implementation

        // General
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        new public void Close() // 'new' to clarify we are implementing the interface method
        {
            base.Close();
        }

        // File/Startup
        public void DisplayCurrentFile(string fileName)
        {
            this.Title = "Current file: " + fileName;
        }

        public void GetFileName()
        {
            if (!string.IsNullOrEmpty(_databasePath))
                System.IO.Path.GetFileName(_databasePath);
        }

        public void GetFolderName()
        {
            if (!string.IsNullOrEmpty(_databasePath))
                System.IO.Path.GetDirectoryName(_databasePath);
        }

        public void OpenFileExplorer()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Database files (*.db)|*.db";

            if (dialog.ShowDialog() == true)
            {
                _databasePath = dialog.FileName;
            }
        }

        public void LoadLastUsedFile()
        {
            // Placeholder for persistence logic
        }

        // Add Event Specifics
        public int GetRepeatDays()
        {
            return 0; // Not applicable for MainWindow
        }

        public void ResetFields()
        {
            // No fields to reset on MainWindow
        }

        // Closing & Navigation
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
            MessageBox.Show("You have unsaved changes.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ToCategoryWindowFromEvents()
        {
            // Implementing missing interface method
            AddCategory w = new AddCategory(_databasePath);
            w.Show();
            this.Close();
        }

        #endregion
    }
}