using Calendar;
namespace MileStone6Presenter
{
    public class Presenter
    {
        private readonly ViewInterface _view;
        private HomeCalendar _calendar;

        private List<string> _typenames;
        private List<string> _categorynames;


        public Presenter(ViewInterface v)
        {
            _calendar = new HomeCalendar("TestDBFile.db");)
            _typenames = new List<string>();
            _categorynames = new List<string>();
            _view = v;
        }
        public void AddCategory(string description, int type)
        {
            if (string.IsNullOrEmpty(description))
            {
                _view.ShowError("Description cannot be void");
                return;
            }
            else if (type == -1)
            {
                _view.ShowError("Category cannot be void");
                return;
            }
            else
            {
                _calendar.categories.Add(description, (Category.CategoryType)type);
                _view.ShowMessage(description + " category has been added");
                _view.ResetFields();
            }

        }
        public void RemoveCategory(int id)
        {
            _calendar.categories.Delete(id);

        }
        public void AddEvent(DateTime startingTime, int categoryID, string durationInMinutes, string details)
        {
            if (string.IsNullOrEmpty(details))
            {
                _view.ShowError("Details cannot be void");
            }
            else if (categoryID == -1)
            {
                _view.ShowError("Category cannot be void");
                return;
            }
            else if (startingTime == null)
            {
                _view.ShowError("Date cannot be void");
                return;
            }
            else if (!int.TryParse(durationInMinutes, out int duration))
            {
                _view.ShowError("Duration cannot be void or a non integer");
                return;
            }
            _calendar.events.Add(startingTime, categoryID, int.Parse(durationInMinutes), details);
            _view.ShowMessage(details + " event has been added");
            _view.ResetFields();
        }
        public void RemoveEvent(int id)
        {
            _calendar.events.Delete(id);
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
            foreach (Category category in _calendar.categories.List())
            {
                _categorynames.Add(category.Description);
            }
            return _categorynames;
        }

        //for testing only
        public void CloseCalendar()
        {
            _calendar.CloseDB();
        }
    }
}
