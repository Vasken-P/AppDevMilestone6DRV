using System.Windows;

namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddCategory : Window, ViewInterface
    {
        public Presenter p;
        public AddCategory(string databasePath)
        {
            p = new Presenter(this, databasePath);
            public AddEvent? sourceEventWindow = null;
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
                p = new Presenter(this);
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

                this.Close();
            }
            else
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            p.AddCategory(CategoryDescription.Text, CategoryTypes.SelectedIndex);
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

        public void ShowError(string message)
        {
            ErrorBox.Text = message;
            //BorderBrush = "Crimson" BorderThickness = "5"
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
            return "";
        }

        public string GetFolderName()
        {
            return "";
        }

        public string OpenFileExplorer()
        {
            return "";
        }

        public string LoadLastUsedFile()
        {
            return "";
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
            //throw new NotImplementedException();

            CategoryDescription.Text = string.Empty;
            CategoryTypes.SelectedIndex = -1;
        }

        public void ToCategoryWindowFromEvents()
        {
            throw new NotImplementedException();
        }
    }
}