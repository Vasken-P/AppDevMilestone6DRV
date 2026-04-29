using Calendar;

namespace MileStone6
{
    public class Presenter
    {
        private HomeCalendar _calendar;
        private List<string> _typenames;
        private List<string> _categorynames;
        public HomeCalendar Calendar
        {
           get { return _calendar; }
        }

        public Presenter(string filepath)
        {
            _calendar = new HomeCalendar(filepath);
            _typenames = new List<string>();
            _categorynames = new List<string>();
        }
        //public void AddCategory(string description, int type)
        //{
        //    Calendar.categories.Add(description, (Category.CategoryType)type);
        //}
        // story about preventing duplicate category
        public bool AddCategory(string description,int type)
        {
            foreach (Category category in _calendar.categories.List())
            {
                if (category.Description.ToLower() == description)
                {
                    return false;
                }
            }

            _calendar.categories.Add(description, (Category.CategoryType)type);
            return true;
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
            _typenames.Clear();
            foreach (string type in Enum.GetNames<Category.CategoryType>())
            {
                _typenames.Add(type);
            }
            return _typenames;
        }
        public List<string> GetCategoryNames()
        {
            _categorynames.Clear();
            foreach (Category category in Calendar.categories.List())
            {
                _categorynames.Add(category.Description);
            }
            return _categorynames;
        }
    }
}
