using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileStone6Presenter
{
    public interface ViewInterface
    {
        // general basic things for the view
        void ShowMessage(string message);
        void ShowError(string message);
        void Close();

        // file/startup
        void DisplayCurrentFile(string fileName);
        void GetFileName();
        void GetFolderName();
        void OpenFileExplorer();
        void LoadLastUsedFile();



        // add event
        int GetRepeatDays();
        void SetDefaultDate(string date);
        void SetDefaultTime(string time);
        void SetCategories(List<string> categories);
        void ResetFields();
        void KeepCategoryAndDate();


        // add category
        string GetCategoryDescription();
        void ClearCategoryFields();

        // closing
        void ConfirmUnsavedChanges();




    }
}
