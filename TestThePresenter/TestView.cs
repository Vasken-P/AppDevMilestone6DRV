using MileStone6Presenter;

namespace TestThePresenter
{
    public class TestView : ViewInterface
    {

        public bool calledShowMessage;
        public bool calledShowError;

        public bool calledResetFields;

        public Presenter p;
        private DateTime mockeventDate = DateTime.Today.Date.AddDays(1);
        private int mockEventCategory;
        private string mockEventDetails = "";
        private string mockEventDuration = "";

        private string mockCategoryDescription = "";
        private int mockCategoryType;

        [Fact]
        public void ConstructorSuccess()
        {
            //Arrange
            //Act
            TestView view = new TestView();
            p = new Presenter(view);

            //Assert
            Assert.IsType<Presenter>(p);
        }

        [Fact]
        public void AddEventSuccess()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledResetFields = false;
            calledResetFields = false;

            //Act
            mockEventCategory = 1;
            mockEventDetails = "ADetail";
            mockEventDuration = "5";
            p.AddEvent(mockeventDate, mockEventCategory, mockEventDuration, mockEventDetails);

            //Assert
            Assert.True(calledShowMessage);
            Assert.True(calledResetFields);

            p.RemoveEvent(0);

        }

        [Fact]
        public void AddEventFailBadCategory()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledResetFields = false;
            calledShowError = false;

            //Act
            mockEventCategory = -1;
            mockEventDetails = "ADetail";
            mockEventDuration = "5";
            p.AddEvent(mockeventDate, mockEventCategory, mockEventDuration, mockEventDetails);

            //Assert
            Assert.True(calledShowError);
            Assert.True(!calledResetFields);

        }

        [Fact]
        public void AddEventFailBadDuration()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledResetFields = false;
            calledShowError = false;

            //Act
            mockEventCategory = 1;
            mockEventDetails = "ADetail";
            p.AddEvent(mockeventDate, mockEventCategory, "mockeventDuration", mockEventDetails);

            //Assert
            Assert.True(calledShowError);
            Assert.True(!calledResetFields);

        }

        [Fact]
        public void AddEventFailBadDetails()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledResetFields = false;
            calledShowError = false;

            //Act
            mockEventCategory = 1;
            mockEventDetails = "";
            mockEventDuration = "5";
            p.AddEvent(mockeventDate, mockEventCategory, mockEventDuration, mockEventDetails);

            //Assert
            Assert.True(calledShowError);
            Assert.True(!calledResetFields);

        }


        //
        //      CATEGORIES
        //
        [Fact]
        public void AddCategorySuccess()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledResetFields = false;
            calledResetFields = false;

            //Act           
            mockCategoryDescription = "ACategory";
            mockCategoryType = 1;
            p.AddCategory(mockCategoryDescription, mockCategoryType);

            //Assert
            Assert.True(calledShowMessage);
            Assert.True(calledResetFields);

            p.RemoveCategory(4);

        }
        [Fact]
        public void AddCategoryFailBadDescription()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledResetFields = false;
            calledShowError = false;

            //Act
            mockCategoryDescription = "";
            mockCategoryType = 1;
            p.AddCategory(mockCategoryDescription, mockCategoryType);
            
            //Assert
            Assert.True(calledShowError);
            Assert.True(!calledResetFields);

        }
        [Fact]
        public void AddCategoryFailBadType()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledResetFields = false;
            calledShowError = false;

            //Act
            mockCategoryDescription = "ADescription";
            mockCategoryType = -1;
            p.AddCategory(mockCategoryDescription, mockCategoryType);

            //Assert
            Assert.True(calledShowError);
            Assert.True(!calledResetFields);

        }

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
    }
}