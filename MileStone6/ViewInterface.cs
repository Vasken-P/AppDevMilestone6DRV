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


        // add category
        string GetDescription();
        void ClearFields();

        // add event
        string GetEventDescription();
        //string GetStartDate();
        //string GetStartTime();
        //string GetCategory();
        void SetDefaultDate(string date);
        void SetDefaultTime(string time);

        void ResetEventFields();
        void DisplayCurrentFile(string fileName);



    }
}
