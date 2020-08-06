using OpenQA.Selenium;

namespace PageObjModels.POM
{
    public class LoginPage : LoginObjs
    {
        private IWebElement errorMsg => _seleniumDriver.FindElement(By.Id("error"));

        public LoginPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://uat.spartaglobal.academy/";
        }

        public string GetErrorMsg() => errorMsg.Text;
    }
}