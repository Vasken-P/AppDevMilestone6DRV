using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar;

namespace MileStone6
{
    internal class Presenter
    {
        private HomeCalendar _calendar;
        public HomeCalendar Calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }

        public Presenter()
        {
            Calendar = new HomeCalendar("C:\\Users\\2483776\\Source\\Repos\\Web2Milestone6DRV\\MileStone6\\DatabaseFiles\\DatabaseFile.db");
        }
        public void AddCategory(string description, Category.CategoryType type)
        {
            Calendar.categories.Add(description, type);
        }
        public void RemoveCategory(int id)
        {
            Calendar.categories.Delete(id);
            
        }
        public void AddEvent(DateTime startingTime, int categoryID, int durationInMinutes, string details)
        {
            Calendar.events.Add(startingTime, categoryID, durationInMinutes, details);
        }
        public void RemoveEvent(int id)
        {
            Calendar.events.Delete(id);
        }
        
    }
}
