using Calendar;
namespace MileStone6Presenter
{
    public class Presenter
    {
        private readonly ViewInterface _view;
        private HomeCalendar _calendar;
<<<<<<< HEAD
        private List<string> typenames;
        private List<string> categorynames;
=======

     


        private List<string> _typenames;
        private List<string> _categorynames;
>>>>>>> View



        public Presenter(ViewInterface v)
        {
<<<<<<< HEAD
            _calendar = new HomeCalendar("C:\\Users\\vaske\\OneDrive\\Desktop\\AppDev\\AppDevMilestone6DRV\\PresenterLibrary\\DatabaseFiles\\TestDBFile.db");
            typenames = new List<string>();
            categorynames = new List<string>();
            _view = v;
        }
        public void AddCategory(string description, int type)
        {
            if (string.IsNullOrEmpty(description))
=======
            _calendar = new HomeCalendar("TestDBFile.db");
            _typenames = new List<string>();
            _categorynames = new List<string>();
            _view = v;
        }
        //public void AddCategory(string description, int type)
        //{
        //    if (string.IsNullOrEmpty(description))
        //    {
        //        _view.ShowError("Description cannot be void");
        //        return;
        //    }
        //    else if (type == -1)
        //    {
        //        _view.ShowError("Category cannot be void");
        //        return;
        //    }
        //    else
        //    {
        //        _calendar.categories.Add(description, (Category.CategoryType)type);
        //        _view.ShowMessage(description + " category has been added");
        //        _view.ResetFields();
        //    }

        //}
        //========================
        // CATEGORY
        //========================

        public void AddCategory(string description, int type)
        {
            if (description == "")
>>>>>>> View
            {
                _view.ShowError("Description cannot be void");
                return;
            }
<<<<<<< HEAD
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
=======

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
        
>>>>>>> View
        public void RemoveCategory(int id)
        {
            _calendar.categories.Delete(id);

        }
<<<<<<< HEAD
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
=======
        //public void AddEvent(DateTime startingTime, int categoryID, string durationInMinutes, string details)
        //{
        //    if (string.IsNullOrEmpty(details))
        //    {
        //        _view.ShowError("Details cannot be void");
        //    }
        //    else if (categoryID == -1)
        //    {
        //        _view.ShowError("Category cannot be void");
        //        return;
        //    }
        //    else if (startingTime == null)
        //    {
        //        _view.ShowError("Date cannot be void");
        //        return;
        //    }
        //    else if (!int.TryParse(durationInMinutes, out int duration))
        //    {
        //        _view.ShowError("Duration cannot be void or a non integer");
        //        return;
        //    }
        //    _calendar.events.Add(startingTime, categoryID, int.Parse(durationInMinutes), details);
        //    _view.ShowMessage(details + " event has been added");
        //    _view.ResetFields();
        //}

  
  
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
            if (details == "")
            {
                _view.ShowError("Details cannot be void");
                return;
            }
            if (categoryID == -1)
            {
                _view.ShowError("Choose a category");
                return;
            }

            int duration;

            if (!int.TryParse(durationInMinutes, out duration))
            {
                _view.ShowError("Duration must be an integer");
                return;
            }
            _calendar.events.Add(startingTime, categoryID, duration, details);
            _view.ShowMessage("Event added");
            // _view.ResetFields();

            _view.KeepCategoryAndDate();
        }

>>>>>>> View
        public void RemoveEvent(int id)
        {
            _calendar.events.Delete(id);
        }
<<<<<<< HEAD
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
            foreach (Category category in _calendar.categories.List())
            {
                categorynames.Add(category.Description);
            }
            return categorynames;
        }
=======

>>>>>>> View

        //for testing only
        public void CloseCalendar()
        {
            _calendar.CloseDB();
        }
    }
}
