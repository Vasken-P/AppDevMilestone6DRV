using Calendar;
using MileStone6;

namespace MileStone6
{
    public class Presenter
    {
        private readonly ViewInterface _view;
        private HomeCalendar _calendar;
        private List<string> typenames;
        private List<string> categorynames;
        public HomeCalendar Calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }

        public Presenter(ViewInterface v)
        {
            Calendar = new HomeCalendar("C:\\Users\\vaske\\OneDrive\\Desktop\\AppDev\\AppDevMilestone6DRV\\MileStone6\\DatabaseFiles\\TestDBFile.db");
            typenames = new List<string>();
            categorynames = new List<string>();
            _view = v;
        }
        public void AddCategory(string description, int type)
        {
            Calendar.categories.Add(description, (Category.CategoryType)type);
            _view.ShowMessage(description + " category has been added");
            _view.ResetFields();
        }
        public void RemoveCategory(int id)
        {
            Calendar.categories.Delete(id);

        }
        public void AddEvent(DateTime startingTime, int categoryID, int durationInMinutes, string details)
        {
            Calendar.events.Add(startingTime, categoryID, durationInMinutes, details);
            _view.ShowMessage(details+" event has been added");
            _view.ResetFields();
        }
        public void RemoveEvent(int id)
        {
            Calendar.events.Delete(id);
        }
        public List<string> GetCategoryTypeNames()
        {
            typenames.Clear();
            foreach (string type in Enum.GetNames<Category.CategoryType>())
            {
                typenames.Add(type);
            }
            return typenames;
        }
        public List<string> GetCategoryNames()
        {
            categorynames.Clear();
            foreach (Category category in Calendar.categories.List())
            {
                categorynames.Add(category.Description);
            }
            return categorynames;
        }
    }
}
