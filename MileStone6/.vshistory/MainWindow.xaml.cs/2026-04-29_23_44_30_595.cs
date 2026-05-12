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

            //First time setup here
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Choose or create a database file";
            dialog.Filter = "Database files (*.db)|*.db";
            dialog.FileName = "MyCalendar.db";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _databasePath = dialog.FileName;

                // create presenter using DI 
                _presenter = new Presenter(this, _databasePath);

                MessageBox.Show("File selected: " + _databasePath);
            }
            else
            {
                MessageBox.Show("You must select a file to continue.");
                this.Close();
            }

        }

        public void ClearCategoryFields()
        {
            throw new NotImplementedException();
        }

        private void ToAddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategory w = new AddCategory(_databasePath);
            AddCategory w = new AddCategory(null, null);
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
            MessageBoxResult result = MessageBox.Show("Would you like to leave", "Exit", button: MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        // ======================== 
        // ViewInterface METHODS 
        // ======================== 

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error");
        }

        public void Close()
        {
            base.Close();
        }

        public void DisplayCurrentFile(string fileName)
        {
            this.Title = "Current file: " + fileName;
        }

        public string GetFileName()
        {
            return System.IO.Path.GetFileName(_databasePath);
        }

        public string GetFolderName()
        {
            return System.IO.Path.GetDirectoryName(_databasePath);
        }

        public string OpenFileExplorer()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Database files (*.db)|*.db";

            if (dialog.ShowDialog() == true)
            {
                _databasePath = dialog.FileName;
                return _databasePath;
            }

            return null;
        }

        public string LoadLastUsedFile()
        {
            // Simple version (no persistence yet) 
            return _databasePath;
        }

        public int GetRepeatDays()
        {
            return 0; // not used in MainWindow 
        }

        public void ResetFields()
        {
            // nothing to reset here 
        }

        public void AskToLeave()
        {
            ToLeaveButton_Clicked(null, null);
        }

        public void ConfirmUnsavedChanges()
        {
            MessageBox.Show("You have unsaved changes.");
        }

    }
}