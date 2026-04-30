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

            _calendar = new HomeCalendar("TestDBFile.db");
            //_calendar = new HomeCalendar("C:\\Users\\vaske\\OneDrive\\Desktop\\AppDev\\AppDevMilestone6DRV\\PresenterLibrary\\DatabaseFiles\\TestDBFile.db");
            _typenames = new List<string>();
            _categorynames = new List<string>();
            _view = v;
        }


        //========================
        // CATEGORY
        //========================

        public void AddCategory(string description, int type)
        {
            if (string.IsNullOrEmpty(description))

            {
                _view.ShowError("Description cannot be void");
                return;
            }


            if (type == -1)
            {
                _view.ShowError("Choose a type");
                return;
            }

            foreach (Category category in _calendar.categories.List())
            {
                if (category.Description == description)
                {
                    _view.ShowError("Category already exists");
                    return;
                }
            }

            _calendar.categories.Add(description, (Category.CategoryType)type);

            _view.ShowMessage("Category added");
            _view.ResetFields();

        }

        public void RemoveCategory(int id)
        {
            _calendar.categories.Delete(id);

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
        //========================
        // EVENT
        //========================
        public void AddEvent(DateTime startingTime, int categoryID, string durationInMinutes, string details)
        {
            if (string.IsNullOrEmpty(details))
            {
                _view.ShowError("Details cannot be empty");
                return;
            }

            if (categoryID == -1)
            {
                _view.ShowError("Choose a category");
                return;
            }

            // Note: DateTime is a value type, so it can't be null.
            // If needed, check against a default value instead:
            if (startingTime == default(DateTime))
            {
                _view.ShowError("Date cannot be empty");
                return;
            }

            if (!int.TryParse(durationInMinutes, out int duration))
            {
                _view.ShowError("Duration must be a valid integer");
                return;
            }

            _calendar.events.Add(startingTime, categoryID, duration, details);

            _view.ShowMessage($"{details} event has been added");

            // Choose ONE behavior depending on your UX:
            _view.ResetFields();           // clears everything
                                           // _view.KeepCategoryAndDate(); // keeps some selections
        }

        public void ToCategoryWindow()
        {
            _view.ToCategoryWindowFromEvents();
        }
        public void RemoveEvent(int id)
        {
            _calendar.events.Delete(id);
        }
        public void Leaving()
        {
            _view.AskToLeave();
        }

        //for testing only
        public void CloseCalendar()
        {
            _calendar.CloseDB();
        }
    }
}
