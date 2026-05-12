using System;
using System.Collections.Generic;
using System.Windows;

namespace MileStone6Presenter
{
    public partial class AddCategory : Window, ViewInterface
    {
        public Presenter p;
        public AddEvent? sourceEventWindow = null;

        public AddCategory(AddEvent? sourceEventWindow, Presenter? presFromEvents, string databasePath)
        {
            InitializeComponent();

            if (sourceEventWindow != null && presFromEvents != null)
            {
                p = presFromEvents;
                this.sourceEventWindow = sourceEventWindow;
                // Safely disable button if it exists in XAML
                if (CloseButton != null) CloseButton.IsEnabled = false;
            }
            else
            {
                p = new Presenter(this, "");
            }

            CategoryTypes.ItemsSource = p.GetCategoryTypeNames();
        }


        public void ShowMessage(string message)
        {
            ErrorBox.Text = message;
        }

        public void ShowError(string message)
        {
            ErrorBox.Text = message;
        }

        new public void Close()
        {
            base.Close();
        }

        public void DisplayCurrentFile(string fileName) { }
        public void GetFileName() { }
        public void GetFolderName() { }
        public void OpenFileExplorer() { }
        public void LoadLastUsedFile() { }

        public void ResetFields()
        {
            CategoryDescription.Text = string.Empty;
            CategoryTypes.SelectedIndex = -1;
        }

        public void ClearCategoryFields()
        {
            ResetFields();
        }

        public int GetRepeatDays() => 0; // Not applicable

        public void ToCategoryWindowFromEvents() { /* Already here */ }

        public void ConfirmUnsavedChanges()
        {
            MessageBox.Show("Unsaved changes will be lost.");
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
            MessageBoxResult result = MessageBox.Show("Would you like to leave?", "Exit", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void ToLeaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            p.Leaving();
        }

        public void SetCategories(List<string> categories) { }
        public void SetDefaultDate(string date) { }
        public void SetDefaultTime(string time) { }
        public void KeepCategoryAndDate() { }
        public string GetCategoryDescription()
        {
            return CategoryDescription.Text;
        }
    }
}