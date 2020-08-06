using OpenQA.Selenium;

namespace PageObjModels
{
    public abstract class SpartaPages : SuperPage
    {
        private IWebElement spartaLogo => _seleniumDriver.FindElement(By.Id("logoHeader"));
        private IWebElement pageTitle => _seleniumDriver.FindElement(By.ClassName("sparta_page_header"));

        protected SpartaPages(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
        }

        public string GetPageTitle() => pageTitle.Text;
        public void ClickLogo() => spartaLogo.Click();
        public void ClickTitle() => pageTitle.Click();
    }
}