using OpenQA.Selenium;

namespace PageObjModels
{
    public class SuperPage : IPage
    {

        protected IWebDriver _seleniumDriver;
        protected string _url;

        public SuperPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void Visit() => _seleniumDriver.Navigate().GoToUrl(_url);
        public void MaximisePage() => _seleniumDriver.Manage().Window.Maximize();
        public string GetCurrentUrl() => _seleniumDriver.Url;

    }
}