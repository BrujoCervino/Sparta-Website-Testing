using OpenQA.Selenium;

namespace PageObjectModels.POM
{
    public class LoginPage : SuperPage
    {
        private IWebElement userNameTextBox => _seleniumDriver.FindElement(By.Name("username"));
        private IWebElement passwordTextBox => _seleniumDriver.FindElement(By.Name("password"));
        private IWebElement submitButton => _seleniumDriver.FindElement(By.CssSelector(".btn"));
        private IWebElement errorMsg => _seleniumDriver.FindElement(By.Id("error"));
        private IWebElement loginButton => _seleniumDriver.FindElement(By.Id("logout_link"));

        public LoginPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://uat.spartaglobal.academy/";
        }

        public void EnterUsername(string username)
        {
            userNameTextBox.Clear();
            userNameTextBox.SendKeys(username);
        }
        
        public void EnterPassword(string password)
        {
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(password);
        }

        public string GetErrorMsg() => errorMsg.Text;

        public void ClickLoginPageButton() => loginButton.Click();

        public void SubmitLoginInfo() => submitButton.Click();
    }
}