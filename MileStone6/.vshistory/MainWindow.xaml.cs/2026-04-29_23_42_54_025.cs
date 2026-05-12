Eggishtrain
eggishtrain
Online

Eggishtrain — 4/1/2026 11:50 PM
Remove losing node from the linked list
Update head if needed
Decrease count
Update it for the next round (skip exit)
Loop until one person remains
Print the final loser
Eggishtrain — 4/4/2026 1:02 AM

Eggishtrain — 4/4/2026 1:05 PM

Eggishtrain — 4/6/2026 12:41 AM
Porter(2009), Elliott(2021), and Cusack(2020),
Eggishtrain — 4/6/2026 10:41 PM
from end (towards chapter 44)- 37 chapters
from start (towards chapter 44)- 54 chapters
Eggishtrain — 4/8/2026 12:11 AM

Eggishtrain — 4/12/2026 5:09 PM
using System.Security.Cryptography.X509Certificates;
using TicTacToe;
using static TicTacToeGame.Program;

namespace TicTacToeGame
{

message.txt
4 KB
Eggishtrain — 4/15/2026 11:14 PM
https://youtu.be/chyjBpdyYjE
YouTube
Born Zero
ALL MY CHILDREN DO X!! | Choujin X CHAPTER 56.2 manga review plus MORE

Eggishtrain — 4/20/2026 9:48 PM



Eggishtrain — 4/20/2026 10:01 PM
\
Image
Eggishtrain — 4/23/2026 1:03 AM
https://www.reddit.com/r/languagelearning/comments/5zzzik/can_someone_eli5_the_language_levels_a1_b2_c1_etc/
r/languagelearning
Can someone ELI5 the language levels? (A1, B2, C1, etc)
I've googled it and found some info on it, but I don't think, that I've ever really got what communication at those levels…
From the languagelearning community on Reddit: "Can someone ELI5 the language levels? (A1, B2, C1, etc)"

Reddit
Eggishtrain — 11:39 PM
add event:
using System.Windows;
namespace MileStone6Presenter
    {
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>

message.txt
5 KB
add category:
using System.Windows;

namespace MileStone6Presenter
        {
    /// <summary>
    /// Interaction logic for Window1.xaml

message.txt
5 KB
main window:
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

message.txt
5 KB
﻿
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
<<<<<<< HEAD
                        AddCategory w = new AddCategory(_databasePath);
=======
            AddCategory w = new AddCategory(null, null);
>>>>>>> 99cefde13fd894fef450a1e90fcd99643b80fb47
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
                        // Optional: display in UI (label, title, etc.) 
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
