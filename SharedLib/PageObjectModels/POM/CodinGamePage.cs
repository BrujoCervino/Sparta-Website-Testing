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
        private IReadOnlyCollection<IWebElement> answers => _seleniumDriver.FindElements(By.CssSelector("#root > div > div > div > div > div.Pane.vertical.Pane2 > div > div.c0185 > div > div.c0156 > div > div.c0160.c0161 > form"));
        private IWebElement nextSubmitButton => _seleniumDriver.FindElement(By.CssSelector("#root > div > div > div > div > div.Pane.vertical.Pane2 > div > div.c0185 > div > div.c0157 > button"));

        public CodinGame(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://www.codingame.com/evaluate?id=393749715f1359743d428e4f90316c0b8b5d538";
        }

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