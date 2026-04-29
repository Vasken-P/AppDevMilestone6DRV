using MileStone6Presenter;

namespace TestThePresenter
{
    public class TestView : ViewInterface
    {
        public Presenter p;
        public DateTime mockeventDate = DateTime.Today.Date.AddDays(1);

        public bool calledShowMessage;
        public bool calledShowError;

        public bool calledResetFields;


        public int mockEventCategory;
        public string mockEventDetails = "";
        public string mockEventDuration = "";

        public string mockCategoryDescription = "";
        public int mockCategoryType;

        public bool calledAskToLeave;

        public void ShowMessage(string message)
        {
            calledShowMessage = true;
        }
        public void ShowError(string message)
        {
            calledShowError = true;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void DisplayCurrentFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void GetFileName()
        {
            throw new NotImplementedException();
        }

        public void GetFolderName()
        {
            throw new NotImplementedException();
        }

        public void OpenFileExplorer()
        {
            throw new NotImplementedException();
        }

        public void LoadLastUsedFile()
        {
            throw new NotImplementedException();
        }

        public int GetRepeatDays()
        {
            throw new NotImplementedException();
        }

        public void SetDefaultDate(string date)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultTime(string time)
        {
            throw new NotImplementedException();
        }

        public void SetCategories(List<string> categories)
        {
            throw new NotImplementedException();
        }

        public void ResetFields()
        {
            calledResetFields = true;
        }

        public void KeepCategoryAndDate()
        {
            throw new NotImplementedException();
        }

        public string GetCategoryDescription()
        {
            throw new NotImplementedException();
        }

        public void ClearCategoryFields()
        {
            throw new NotImplementedException();
        }

        public void ConfirmUnsavedChanges()
        {
            throw new NotImplementedException();
        }

        public void AskToLeave()
        {
            calledAskToLeave = true;
        }

    }


    public class UnitTest
    {
        [Fact]
        public void ConstructorSuccess()
        {
            //Arrange
            //Act
            TestView view = new TestView();
            view.p = new Presenter(view);

            //Assert
            Assert.IsType<Presenter>(view.p);
        }

        //
        //      Events
        //

        [Fact]
        public void AddEventSuccess()
        {
            //Arrange
            TestView view = new TestView();
            view.p = new Presenter(view);
            view.calledResetFields = false;
            view.calledResetFields = false;

            //Act
            view.mockEventCategory = 1;
            view.mockEventDetails = "ADetail";
            view.mockEventDuration = "5";
            view.p.AddEvent(view.mockeventDate, view.mockEventCategory, view.mockEventDuration, view.mockEventDetails);

            //Assert
            Assert.True(view.calledShowMessage);
            Assert.True(view.calledResetFields);

            view.p.RemoveEvent(0);

        }

        [Fact]
        public void AddEventFailBadCategory()
        {
            //Arrange
            TestView view = new TestView();
            view.p = new Presenter(view);
            view.calledResetFields = false;
            view.calledShowError = false;

            //Act
            view.mockEventCategory = -1;
            view.mockEventDetails = "ADetail";
            view.mockEventDuration = "5";
            view.p.AddEvent(view.mockeventDate, view.mockEventCategory, view.mockEventDuration, view.mockEventDetails);

            //Assert
            Assert.True(view.calledShowError);
            Assert.True(!view.calledResetFields);
        }

        [Fact]
        public void AddEventFailBadDuration()
        {
            //Arrange
            TestView view = new TestView();
            view.p = new Presenter(view);
            view.calledResetFields = false;
            view.calledShowError = false;

            //Act
            view.mockEventCategory = 1;
            view.mockEventDetails = "ADetail";
            view.p.AddEvent(view.mockeventDate, view.mockEventCategory, "mockeventDuration", view.mockEventDetails);

            //Assert
            Assert.True(view.calledShowError);
            Assert.True(!view.calledResetFields);

        }

        [Fact]
        public void AddEventFailBadDetails()
        {
            //Arrange
            TestView view = new TestView();
            view.p = new Presenter(view);
            view.calledResetFields = false;
            view.calledShowError = false;

            //Act
            view.mockEventCategory = 1;
            view.mockEventDetails = "";
            view.mockEventDuration = "5";
            view.p.AddEvent(view.mockeventDate, view.mockEventCategory, view.mockEventDuration, view.mockEventDetails);

            //Assert
            Assert.True(view.calledShowError);
            Assert.True(!view.calledResetFields);

        }

        //
        //      CATEGORIES
        //

        [Fact]
        public void AddCategorySuccess()
        {
            //Arrange
            TestView view = new TestView();
            view.p = new Presenter(view);
            view.calledResetFields = false;
            view.calledResetFields = false;

            //Act           
            view.mockCategoryDescription = "ACategory";
            view.mockCategoryType = 1;
            view.p.AddCategory(view.mockCategoryDescription, view.mockCategoryType);

            //Assert
            Assert.True(view.calledShowMessage);
            Assert.True(view.calledResetFields);

            List<string> catlist = view.p.GetCategoryNames();
            view.p.RemoveCategory(catlist.Count()-1);

        }
        [Fact]
        public void AddCategoryFailBadDescription()
        {
            //Arrange
            TestView view = new TestView();
            view.p = new Presenter(view);
            view.calledResetFields = false;
            view.calledShowError = false;

            //Act
            view.mockCategoryDescription = "";
            view.mockCategoryType = 1;
            view.p.AddCategory(view.mockCategoryDescription, view.mockCategoryType);

            //Assert
            Assert.True(view.calledShowError);
            Assert.True(!view.calledResetFields);

        }
        [Fact]
        public void AddCategoryFailBadType()
        {
            //Arrange
            TestView view = new TestView();
            view.p = new Presenter(view);
            view.calledResetFields = false;
            view.calledShowError = false;

            //Act
            view.mockCategoryDescription = "ADescription";
            view.mockCategoryType = -1;
            view.p.AddCategory(view.mockCategoryDescription, view.mockCategoryType);

            //Assert
            Assert.True(view.calledShowError);
            Assert.True(!view.calledResetFields);

        }

        //
        //      LEAVING
        //

        [Fact]
        public void AskToLeaveCalled()
        {
            //Arrange
            TestView view = new TestView();
            view.p = new Presenter(view);
            view.calledAskToLeave = false;

            //Act
            view.p.Leaving();

            //Assert
            Assert.True(view.calledAskToLeave);
        }
    }
}