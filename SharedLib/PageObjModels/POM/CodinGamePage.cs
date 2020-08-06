using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace PageObjModels.POM
{
    public class CodinGame : SuperPage
    {
        static Random _rnd = new Random();

        private IWebElement startButton => _seleniumDriver.FindElement(By.CssSelector("div[data-test=AssessmentTile] button"));
        private IWebElement tOSCheckBox => _seleniumDriver.FindElement(By.CssSelector("div[data-test=AssessmentStartPopup] label"));
        private IWebElement beginButton => _seleniumDriver.FindElement(By.CssSelector("div[data-test=AssessmentStartPopup] button[data-test=accept]"));
        private IReadOnlyCollection<IWebElement> answers => _seleniumDriver.FindElements(By.CssSelector("#root > div.c0150.c0151 > div > div > div > div.Pane.vertical.Pane2 > div > div.c01154 > div > div.c01132 > div > div.c01136.c01137 > form"));
        private IWebElement nextSubmitButton => _seleniumDriver.FindElement(By.CssSelector("#root > div.c0150.c0151 > div > div > div > div.Pane.vertical.Pane2 > div > div.c01154 > div > div.c01133 > button"));   
        private IWebElement selectQuestion(int num) => _seleniumDriver.FindElement(By.CssSelector($"#root > div.c0150.c0151 > div > div > div > div > div > div > div.c01102 > div > div:nth-child({num}) > div.c0191.c01101 > span > button"));
        private IWebElement endTest => _seleniumDriver.FindElement(By.CssSelector("#root > div.c0150.c0151 > div > div > div > header > button"));
        private IWebElement confEnd => _seleniumDriver.FindElement(By.CssSelector("body > div:nth-child(7) > div > div > div > div.c01109 > button:nth-child(2)"));

        public CodinGame(IWebDriver seleniumDriver, string testUrl) : base(seleniumDriver)
        {
            _url = testUrl;
        }

        public void ClickQuestion(int num) => selectQuestion(num).Click();       
        public void ClickEndTest() => endTest.Click();
        public void ClickConfEnd() => confEnd.Click();
        public void ClickstartButton() => startButton.Click();
        public void ClickTOSCheckBox() => tOSCheckBox.Click();
        public void ClickbeginButton() => beginButton.Click();
        public void ClicknextSubmitButton() => nextSubmitButton.Click();

        public void ClickRandomAnswer()
        {
            
            var lis = new List<IWebElement>();
            foreach (IWebElement element in answers)
            {
                lis.Add(element);
            }
            lis[_rnd.Next(lis.Count)].Click();
            lis.Clear();
        }        
    }
}