using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileStone6
{
    internal interface ViewInterface
    {
        // general basic things for the view
        void ShowMessage(string message);
        void Close();

        // file/startup
        void DisplayCurrentFile(string fileName);
        void GetFileName();
        void GetFolderName();
        void OpenFileExplorer();
        void LoadLastUsedFile();


        // add event
        string GetEventDescription();
        string GetStartDate();
        string GetStartTime();
        string GetCategory();
        int GetRepeatDays();
        void SetDefaultDate(string date);
        void SetDefaultTime(string time);
        void SetCategories(List<string> categories);
        void ResetEventFields();
        void KeepCategoryAndDate();


        // add category
        string GetCategoryDescription();
        void ClearCategoryFields();

        // navigation
        void NavigateToAddEvent();
        void NavigateToAddCategory();

        // closing
        void ConfirmUnsavedChanges();




    }
}
