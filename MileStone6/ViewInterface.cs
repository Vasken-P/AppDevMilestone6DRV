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


        // if ( i = 0 ; i < j; i++) so like we are making an if statment right now to like check things out and to work stuff out making things work out to be perfect and great to make sureb that everything works out 

    }
}
