using NUnit.Framework;
using PageObjModels;
using SharedTestTools;

namespace ResultsTests
{
    // Will probably get rid of this and switch to {Gherkin+Selenium+NUNit}. This is just proof of concept that Selenium is working
    public class ResultsPageShould
    {
        private SpartaWebsite spartaWebsite;

        [SetUp]
        public void Setup()
        {
            // Todo: Add some way of passing a browser name into the driver here.
        }

        [TestCase("chrome")]
        [TestCase("firefox")]
        public void CanAccessResultsPage(in string driverName)
        {
            // Arrange, act
            spartaWebsite = new SpartaWebsite(driverName);
            TestTools.Login(spartaWebsite);

            spartaWebsite.resultsPage.Visit();
            spartaWebsite.resultsPage.ClickUpdatebutton();
            // Assert
            Assert.That(spartaWebsite.SeleniumDriver.Url, Is.EqualTo(PagesConfigReader.PollsUrl));
        }

        [Test]
        public void CanAccessResultsTable()
        {
            // Arrange, act
            spartaWebsite = new SpartaWebsite("chrome");
            TestTools.Login(spartaWebsite);
            spartaWebsite.resultsPage.Visit();

            // Assert
            Assert.That(spartaWebsite.resultsPage.GetCSharpResults().Count, Is.GreaterThanOrEqualTo(1));
        }

        [TearDown]
        public void Teardown()
        {
            spartaWebsite.Close();
        }
    }
}
