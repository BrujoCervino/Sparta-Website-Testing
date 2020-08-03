using OpenQA.Selenium;
using PageObjectModels;

namespace ResultsPageObject
{
    public class ResultsPage : SuperPage
    {
        public IWebElement UsernameBox => _seleniumDriver.FindElement(By.Name("username"));
        public IWebElement PasswordBox => _seleniumDriver.FindElement(By.Name("password"));
        public IWebElement SubmitButton => _seleniumDriver.FindElement(By.Name("submit"));
        public IWebElement UpdateButton => _seleniumDriver.FindElement(By.TagName("button"));

        public ResultsPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = PagesConfigReader.ResultsUrl;
        }
    }
}