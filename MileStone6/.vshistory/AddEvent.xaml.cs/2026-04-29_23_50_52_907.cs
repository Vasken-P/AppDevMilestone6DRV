using System.Windows;
using Microsoft.Win32;

namespace MileStone6Presenter
{
    public partial class AddCategory : Window, ViewInterface
    {
        public Presenter p;
        private AddEvent? sourceEventWindow;

        public AddCategory(string databasePath)
        {
            InitializeComponent();
            p = new Presenter(this, databasePath);
            CategoryTypes.ItemsSource = p.GetCategoryTypeNames();
        }

        public AddCategory(AddEvent? sourceEventWindow, Presenter? presFromEvents)
        {
            InitializeComponent();

            if (sourceEventWindow != null && presFromEvents != null)
            {
                p = presFromEvents;
                this.sourceEventWindow = sourceEventWindow;
                CloseButton.IsEnabled = false;
            }
            else
            {
                throw new ArgumentException("Presenter and source window must not be null");
            }

            CategoryTypes.ItemsSource = p.GetCategoryTypeNames();
        }

        public void ResetFields()
        {
            CategoryDescription.Text = string.Empty;
            CategoryTypes.SelectedIndex = -1;
        }

        public void SetCategories(List<string> categories)
        {
            throw new NotImplementedException();
        }

        private void CancelButton_CLicked(object sender, RoutedEventArgs e)
        {
            if (sourceEventWindow != null)
            {
                sourceEventWindow.Show();
                sourceEventWindow.ReturnToEventsWindow(p);
                base.Close();
            }
            else
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                base.Close();
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            p.AddCategory(CategoryDescription.Text, CategoryTypes.SelectedIndex);
        }

        public void AskToLeave()
        {
            MessageBoxResult result = MessageBox.Show("Would you like to leave", "Exit", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                base.Close();
            }
        }

        private void ToLeaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            p.Leaving();
        }

        public void ShowError(string message)
        {
            ErrorBox.Text = message;
        }

        public void ShowMessage(string message)
        {
            ErrorBox.Text = message;
        }

        public void ConfirmUnsavedChanges()
        {
            MessageBox.Show("You have unsaved changes.");
        }

        public void DisplayCurrentFile(string fileName)
        {
            this.Title = "Current file: " + fileName;
        }

        public string GetFileName()
        {
            return p.GetDatabasePath();
        }

        public string GetFolderName()
        {
            return System.IO.Path.GetDirectoryName(p.GetDatabasePath());
        }

        public string OpenFileExplorer()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Database files (*.db)|*.db";

            if (dialog.ShowDialog() == true)
            {
                p.SetDatabasePath(dialog.FileName);
                return dialog.FileName;
            }

            return p.GetDatabasePath();
        }

        public string LoadLastUsedFile()
        {
            return p.GetDatabasePath();
        }

        public int GetRepeatDays()
        {
            return 0;
        }

        public void SetDefaultDate(string date)
        {
        }

        public void SetDefaultTime(string time)
        {
        }

        public void KeepCategoryAndDate()
        {
        }

        public string GetCategoryDescription()
        {
            return CategoryDescription.Text;
        }

        public void ClearCategoryFields()
        {
            CategoryDescription.Text = string.Empty;
            CategoryTypes.SelectedIndex = -1;
        }

        public void ToCategoryWindowFromEvents()
        {
            throw new NotImplementedException();
        }
    }
}