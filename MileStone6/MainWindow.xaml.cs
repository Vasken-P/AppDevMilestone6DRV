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
using MileStone6Presenter;


namespace MileStone6Presenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , ViewInterface
    {
        private Presenter p;
        public MainWindow()
        {
            InitializeComponent();
            p = new Presenter(this);
        }

        //public void GetFolderName()
        //{
        //     System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog()
            
              
        //        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            p.FolderChosen(dialog.SelectedPath);
        //        }
            
        //}

        public void GetFileName()
        {
            var dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Filter = "Database (*.db)|*.db";
            if (dlg.ShowDialog() == true)
            {
                string name = System.IO.Path.GetFileName(dlg.FileName);
                p.FileChosen(name);
            }
        }

        public void DisplayCurrentFile(string filePath)
        {
            MessageBox.Show("File chosen: " + filePath);
        }

        private void ChooseFileButton_Click(object sender, RoutedEventArgs e)
        {
            p.ChooseFolder();
        }

        public void ClearCategoryFields()
        {
            throw new NotImplementedException();
        }

        private void ToAddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategory w = new AddCategory(null, null);
            w.Show();
            this.Close();           
        }

        private void ToAddEventButton_Click(object sender, RoutedEventArgs e)
        {
            AddEvent w = new AddEvent();
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
    }
}