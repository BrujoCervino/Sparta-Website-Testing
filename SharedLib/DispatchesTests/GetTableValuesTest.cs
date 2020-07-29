using NUnit.Framework;
using PageObjectModels;

namespace DispatchesTests
{
    public class GetTableValuesTest
    {
        private SpartaWebsite _website;
        private const int _sleepTime = 5;

        [SetUp]
        public void Setup()
        {
            _website = new SpartaWebsite("chrome", _sleepTime, _sleepTime);
            _website.loginPage.MaximisePage();
        }

        [Test]
        public void DriverWorkingTest()
        {
            _website.loginPage.Visit();
            Assert.That(_website.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));
        }

        [Test]
        public void GetTableValues_ReturnValues()
        { // Fragile test, Will have to look further into it when further
            _website.loginPage.Visit();
            _website.loginPage.EnterUsername(LoginConfigReader.Username);
            _website.loginPage.EnterPassword(LoginConfigReader.Password);
            _website.loginPage.SubmitLoginInfo();
            _website.dispatchesPage.Visit();
            _website.dispatchesPage.GetTableContent();

            Assert.That(_website.dispatchesPage.dispatchesList[0].Name, Is.EqualTo("Will Millington"));
        }

        [TearDown]
        public void TearDown()
        {
            _website.Close();
        }
    }
}