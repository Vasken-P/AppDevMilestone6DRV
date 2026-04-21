using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileStone6
{
    internal interface ViewInterface
    {
        void ShowMessage(string message);
        string GetDescription();
        void ClearFields();
        void Close();
    }
}
