using MileStone6Presenter;

namespace TestThePresenter
{
    public class TestView : ViewInterface
    {

        public bool calledShowMessage;
        public bool calledShowError;
        public bool calledClearEvents;
        public bool calledResetFields;
        public Presenter p;
        private DateTime mockeventDate = DateTime.Today.Date.AddDays(1);
        private int mockeventCategory;
        private string mockeventDetails;
        private string mockeventDuration;

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
        public void AddCategorySuccess()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledClearEvents = false;
            calledResetFields = false;

            //Act
            mockeventCategory = 1;
            mockeventDetails = "ADetail";
            mockeventDuration = "5";
            p.AddEvent(mockeventDate, mockeventCategory, mockeventDuration, mockeventDetails);

            //Assert
            Assert.True(calledShowMessage);
            Assert.True(calledResetFields);

        }
        public void AddCategoryFailBadCategory()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledClearEvents = false;
            calledShowError = false;

            //Act
            mockeventCategory = -1;
            mockeventDetails = "ADetail";
            mockeventDuration = "5";
            p.AddEvent(mockeventDate, mockeventCategory, mockeventDuration, mockeventDetails);

            //Assert
            Assert.True(calledShowError);
            Assert.True(!calledResetFields);

        }
        public void AddCategoryFailBadDuration()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledClearEvents = false;
            calledShowError = false;

            //Act
            mockeventCategory = 1;
            mockeventDetails = "ADetail";
            p.AddEvent(mockeventDate, mockeventCategory, "mockeventDuration", mockeventDetails);

            //Assert
            Assert.True(calledShowError);
            Assert.True(!calledResetFields);

        }
        public void AddCategoryFailBadDetails()
        {
            //Arrange
            TestView view = new TestView();
            p = new Presenter(view);
            calledClearEvents = false;
            calledShowError = false;

            //Act
            mockeventCategory = 1;
            mockeventDetails = "";
            mockeventDuration = "5";
            p.AddEvent(mockeventDate, mockeventCategory, mockeventDuration, mockeventDetails);

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