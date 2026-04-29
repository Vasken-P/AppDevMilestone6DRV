using System.Windows;

namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddCategory : Window, ViewInterface
    {
        public Presenter p;
        public AddCategory()
        {
            p = new Presenter(this);
            InitializeComponent();
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
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
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

        public void ConfirmUnsavedChanges()
        {
            throw new NotImplementedException();
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

        public void KeepCategoryAndDate()
        {
            throw new NotImplementedException();
        }

        public string GetCategoryDescription()
        {
            throw new NotImplementedException();
        }

        public void ClearCategoryFields()
        {
            throw new NotImplementedException();
        }
    }
}
