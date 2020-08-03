using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModels;

namespace DispatchesTests
{
    [TestFixture]
    public class NavBarShould
    {
        [SetUp]
        public void Setup()
        {

        }
        
        [TestCase("Results", "Polls")]
        public void GivenIAmOnThe_X_Page_TheSpartaLogoShould_SendMeToThe_Y_Page(in string initialPage, in string destinationPage)
        {
            SpartaWebsite sw = new SpartaWebsite("Chrome");
            sw.SeleniumDriver.Navigate().GoToUrl(PagesConfigReader.BaseUrl + initialPage.ToLower());

            IWebElement thing = sw.SeleniumDriver.FindElement(By.LinkText(destinationPage));
            thing.Click();


            Assert.That(sw.SeleniumDriver.Url, Is.EqualTo(PagesConfigReader.PollsUrl));
        }
    }
}
