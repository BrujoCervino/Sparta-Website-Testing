using OpenQA.Selenium;

namespace PageObjectModels
{
    public class SuperPage : IPage
    {
        private IWebElement spartaLogo => _seleniumDriver.FindElement(By.Id(".logoHeader"));
        private IWebElement pageTitle => _seleniumDriver.FindElement(By.Id("page_title")) == null ? _seleniumDriver.FindElement(By.Id("login_title")) : _seleniumDriver.FindElement(By.Id("page_title"));
        private IWebElement dispatches => _seleniumDriver.FindElement(By.CssSelector("[href *='/dispatches']"));
        private IWebElement results => _seleniumDriver.FindElement(By.CssSelector("[href *='/results']"));
        private IWebElement polls => _seleniumDriver.FindElement(By.CssSelector("[href *='/polls']"));
        private IWebElement logout => _seleniumDriver.FindElement(By.CssSelector("[href *='/logout']"));

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

        public void ClickDispatches() => dispatches.Click();
        public void ClickResults() => results.Click();
        public void ClickPolls() => polls.Click();
        public void Clicklogout() => logout.Click();
    }
}