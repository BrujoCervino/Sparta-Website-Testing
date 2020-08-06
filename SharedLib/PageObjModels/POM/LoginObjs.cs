using OpenQA.Selenium;
using PageObjModels;

namespace PageObjModels.POM
{
    public abstract class LoginObjs : SpartaPages
    {
        protected IWebElement loginButton => _seleniumDriver.FindElement(By.Id("logout_link"));
        protected IWebElement userNameTextBox => _seleniumDriver.FindElement(By.Name("username"));
        protected IWebElement passwordTextBox => _seleniumDriver.FindElement(By.Name("password"));
        protected IWebElement submitButton => _seleniumDriver.FindElement(By.CssSelector(".btn"));

        protected LoginObjs(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
        }

        public void ClickLoginPageButton() => loginButton.Click();

        public void SubmitLoginInfo() => submitButton.Click();

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
    }
}