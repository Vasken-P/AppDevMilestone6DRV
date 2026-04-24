using Calendar;

namespace MileStone6
{
    public class Presenter
    {
        private HomeCalendar _calendar;
        private List<string> typenames;
        private List<string> categorynames;
        public HomeCalendar Calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }

        public Presenter()
        {
           
            Calendar = new HomeCalendar("C:\\Users\\vaske\\OneDrive\\Desktop\\AppDev\\AppDevMilestone6DRV\\MileStone6\\DatabaseFiles\\TestDBFile.db");
            typenames = new List<string>();
            categorynames = new List<string>();
        }
        public void AddCategory(string description, int type)
        {
            Calendar.categories.Add(description, (Category.CategoryType)type);
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
