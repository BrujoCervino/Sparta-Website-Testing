using OpenQA.Selenium;
using PageObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjModels.POM
{
    public class LogoutConfirmationPage : SuperPage
    {
        private IWebElement userNameTextBox => _seleniumDriver.FindElement(By.Name("username"));
        private IWebElement passwordTextBox => _seleniumDriver.FindElement(By.Name("password"));
        private IWebElement submitButton => _seleniumDriver.FindElement(By.CssSelector(".btn"));
        private IWebElement SuccessMsg => _seleniumDriver.FindElement(By.Id("success"));
        private IWebElement loginButton => _seleniumDriver.FindElement(By.Id("logout_link"));

        public LogoutConfirmationPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://uat.spartaglobal.academy/login?loggedout=true";
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

        public string GetSuccessMsg() => SuccessMsg.Text;

        public void ClickLoginPageButton() => loginButton.Click();

        public void SubmitLoginInfo() => submitButton.Click();
    }

}
