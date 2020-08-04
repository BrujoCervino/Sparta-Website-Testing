using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace PageObjectModels.POM
{
    public class CodinGame : SuperPage
    {
        private IWebElement startButton => _seleniumDriver.FindElement(By.CssSelector("#root > div > div > div > div:nth-child(2) > div > div > button"));
        private IWebElement tOSCheckBox => _seleniumDriver.FindElement(By.CssSelector("body > div.ReactModalPortal > div > div > div > div.c0135 > p.c0141 > span > label"));
        private IWebElement beginButton => _seleniumDriver.FindElement(By.CssSelector("body > div.ReactModalPortal > div > div > div > div.c0137 > button.c0138.c0140"));
        private IReadOnlyCollection<IWebElement> answers => _seleniumDriver.FindElements(By.CssSelector("#root > div.c0150.c0151 > div > div > div > div.Pane.vertical.Pane2 > div > div.c01154 > div > div.c01132 > div > div.c01136.c01137 > form"));
        private IWebElement nextSubmitButton => _seleniumDriver.FindElement(By.CssSelector("#root > div.c0150.c0151 > div > div > div > div.Pane.vertical.Pane2 > div > div.c01154 > div > div.c01133 > button"));
        private IWebElement select1Question => _seleniumDriver.FindElement(By.CssSelector("#root > div.c0150.c0151 > div > div > div > div > div > div > div.c01102 > div > div:nth-child(1) > div.c0191.c01101 > span > button"));
        private IWebElement select2Question => _seleniumDriver.FindElement(By.CssSelector("#root > div.c0150.c0151 > div > div > div > div > div > div > div.c01102 > div > div:nth-child(2) > div.c0191.c01101 > span > button"));
        private IWebElement select3Question => _seleniumDriver.FindElement(By.CssSelector("#root > div.c0150.c0151 > div > div > div > div > div > div > div.c01102 > div > div:nth-child(3) > div.c0191.c01101 > span > button"));
        private IWebElement select4Question => _seleniumDriver.FindElement(By.CssSelector("#root > div.c0150.c0151 > div > div > div > div > div > div > div.c01102 > div > div:nth-child(4) > div.c0191.c01101 > span > button"));
        private IWebElement endTest => _seleniumDriver.FindElement(By.CssSelector("#root > div.c0150.c0151 > div > div > div > header > button"));
        private IWebElement confEnd => _seleniumDriver.FindElement(By.CssSelector("body > div:nth-child(7) > div > div > div > div.c01109 > button:nth-child(2)"));

        public CodinGame(IWebDriver seleniumDriver, string testUrl) : base(seleniumDriver)
        {
            _url = testUrl;
        }


        public void Click1Question() => select1Question.Click();
        public void Click2Question() => select2Question.Click();
        public void Click3Question() => select3Question.Click();
        public void Click4Question() => select4Question.Click();
        public void ClickEndTest() => endTest.Click();
        public void ClickConfEnd() => confEnd.Click();
        public void ClickstartButton() => startButton.Click();
        public void ClickTOSCheckBox() => tOSCheckBox.Click();
        public void ClickbeginButton() => beginButton.Click();
        public void ClicknextSubmitButton() => nextSubmitButton.Click();
        public void ClickRandomAnswer()
        {
            Random rnd = new Random();
            var lis = new List<IWebElement>();
            foreach (IWebElement element in answers)
            {
                lis.Add(element);
            }
            lis[rnd.Next(lis.Count)].Click();
            lis.Clear();
        }        
    }
}