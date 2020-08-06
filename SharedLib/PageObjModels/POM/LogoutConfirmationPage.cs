using OpenQA.Selenium;

namespace PageObjModels.POM
{
    public class LogoutConfirmationPage : LoginObjs
    {
        private IWebElement SuccessMsg => _seleniumDriver.FindElement(By.Id("success"));

        public LogoutConfirmationPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://uat.spartaglobal.academy/login?loggedout=true";
        }

        public string GetSuccessMsg() => SuccessMsg.Text;
    }
}