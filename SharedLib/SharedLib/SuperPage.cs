using OpenQA.Selenium;

namespace SharedLib
{
    public class SuperPage : IPage
    {
        private IWebElement spartaLogo => _seleniumDriver.FindElement(By.Id(".logoHeader"));

        protected IWebDriver _seleniumDriver;
        protected string _url;
        
        public SuperPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void Visit()
        {
            _seleniumDriver.Navigate().GoToUrl(_url);
        }

        public void MaximisePage()
        {
            _seleniumDriver.Manage().Window.Maximize();
        }

        public string GetCurrentUrl() => _seleniumDriver.Url;
        public void ClickLogo() => spartaLogo.Click();
    }
}