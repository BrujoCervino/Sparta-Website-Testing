using OpenQA.Selenium;

namespace PageObjectModels
{
    public class SuperPage : IPage
    {
        private IWebElement spartaLogo => _seleniumDriver.FindElement(By.Id("logoHeader"));
        private IWebElement pageTitle => _seleniumDriver.FindElement(By.ClassName("sparta_page_header"));

        protected IWebDriver _seleniumDriver;
        protected string _url;

        public SuperPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void Visit() => _seleniumDriver.Navigate().GoToUrl(_url);
        public void MaximisePage() => _seleniumDriver.Manage().Window.Maximize();
        public string GetCurrentUrl() => _seleniumDriver.Url;
        public string GetPageTitle() => pageTitle.Text;
        public void ClickLogo() => spartaLogo.Click();
        public void ClickTitle() => pageTitle.Click();
    }
}