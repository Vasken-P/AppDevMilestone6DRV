using System.Windows;
using System.Windows.Controls;
using MileStone6;
namespace MileStone6
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window, ViewInterface
    {
        private string defaultDate = DateTime.Today.ToString("dd-MM-yyyy");

        public Presenter p;
        public AddEvent()
        {
            p = new Presenter(this);
            InitializeComponent();
            eventCategory.ItemsSource = p.GetCategoryNames();
        }
        private void CancelButton_CLicked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(eventDetails.Text))
            {
                showerrorinbox(eventDetails, "Details cannot be void");
            }
            else if (eventCategory.SelectedIndex == -1)
            {
                showerrorinbox(eventCategory, "Category cannot be void");
                return;
            }
            else if (eventDate.SelectedDate == null)
            {
                showerrorinbox(eventDate, "Date cannot be void");
                return;
            }
            else if (!int.TryParse(eventDuration.Text, out int duration))
            {
                showerrorinbox(eventDuration, "Duration cannot be void or a non integer");
                return;
            }
            else
            {
                p.AddEvent(DateTime.Parse(eventDate.SelectedDate.ToString()), eventCategory.SelectedIndex, int.Parse(eventDuration.Text), eventDetails.Text);
              
            }

        }


        private void showerrorinbox(Control ct, string message)
        {
            ErrorBox.Text = message;
            //BorderBrush = "Crimson" BorderThickness = "5"
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
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

        public void SetCategories(List<string> categories)
        {
            throw new NotImplementedException();
        }

        public void ResetFields()
        {
            eventCategory.SelectedIndex = -1;
            eventDetails.Text = string.Empty;
            eventDate.SelectedDate = DateTime.Parse(defaultDate);
            eventDuration.Text = string.Empty;

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

        public void ConfirmUnsavedChanges()
        {
            throw new NotImplementedException();
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
