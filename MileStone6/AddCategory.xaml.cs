using System.Windows;

namespace MileStone6
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

        public void ClearCategoryFields()
        {
            throw new NotImplementedException();
        }

        public void ConfirmUnsavedChanges()
        {
            throw new NotImplementedException();
        }

        public void DisplayCurrentFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public string GetCategoryDescription()
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

        public int GetRepeatDays()
        {
            throw new NotImplementedException();
        }

        public void KeepCategoryAndDate()
        {
            throw new NotImplementedException();
        }

        public void LoadLastUsedFile()
        {
            throw new NotImplementedException();
        }

        public void OpenFileExplorer()
        {
            throw new NotImplementedException();
        }

        public void ResetEventFields()
        {
            throw new NotImplementedException();
        }

        public void SetCategories(List<string> categories)
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

        public void ShowMessage(string message)
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
            if (string.IsNullOrEmpty(CategoryDescription.Text) && CategoryTypes.SelectedIndex != -1)
            {
                p.AddCategory(CategoryDescription.Text, CategoryTypes.SelectedIndex);
            }
            else
            {
                return;
            }
        }
    }
}
