using NUnit.Framework;
using PageObjectModels;
using System;
using System.Threading;

namespace ResultsTests
{
    // Will probably get rid of this and switch to {Gherkin+Selenium+NUNit}. This is just proof of concept that Selenium is working
    public class ResultsPageShould
    {
        [TestCase("chrome")]
        [TestCase("firefox")]
        public void CanAccessResultsPage(in string driverName)
        {
            // Arrange, act
            SpartaWebsite spartaWebsite = new SpartaWebsite(driverName);
            spartaWebsite.resultsPage.Visit();
            spartaWebsite.resultsPage.UsernameBox.SendKeys(LoginConfigReader.Username);
            spartaWebsite.resultsPage.PasswordBox.SendKeys(LoginConfigReader.Password);
            spartaWebsite.resultsPage.SubmitButton.Click();
            spartaWebsite.resultsPage.Visit();
            spartaWebsite.resultsPage.UpdateButton.Click();
            // Assert
            Assert.That(spartaWebsite.SeleniumDriver.Url, Is.EqualTo(PagesConfigReader.PollsUrl));
        }
    }
}
