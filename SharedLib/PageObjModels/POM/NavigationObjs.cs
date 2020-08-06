﻿using OpenQA.Selenium;

namespace PageObjectModels
{
    public abstract class NavigationObjs : SuperPage
    {
        public NavigationObjs(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
        }

        private IWebElement dispatches => _seleniumDriver.FindElement(By.CssSelector("[href *='/dispatches']"));
        private IWebElement results => _seleniumDriver.FindElement(By.CssSelector("[href *='/results']"));
        private IWebElement polls => _seleniumDriver.FindElement(By.CssSelector("[href *='/polls']"));
        private IWebElement logout => _seleniumDriver.FindElement(By.CssSelector("[href *='/logout']"));
        public void ClickDispatches() => dispatches.Click();
        public void ClickResults() => results.Click();
        public void ClickPolls() => polls.Click();
        public void Clicklogout() => logout.Click();
    }
}