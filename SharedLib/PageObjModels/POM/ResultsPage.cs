using OpenQA.Selenium;
using PageObjectModels;
using System.Collections.Generic;

namespace PageObjectModels.POM
{
    public class ResultsPage : TablePage
    {
        public IWebElement UsernameBox => _seleniumDriver.FindElement(By.Name("username"));
        public IWebElement PasswordBox => _seleniumDriver.FindElement(By.Name("password"));
        public IWebElement SubmitButton => _seleniumDriver.FindElement(By.Name("submit"));
        public IWebElement UpdateButton => _seleniumDriver.FindElement(By.TagName("button"));

        private IWebElement psychometricTable => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(4) > tbody:nth-child(2)"));
        private IWebElement javaTable => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(6) > tbody:nth-child(2)"));
        private IWebElement pythonTable => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(8) > tbody:nth-child(2)"));
        private IWebElement cSharpTable => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(10) > tbody:nth-child(2)"));
        private IWebElement pythonLearningPathTable => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(12) > tbody:nth-child(2)"));

        public ResultsPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = PagesConfigReader.ResultsUrl;
        }

        public List<List<string>> GetPsychometricResults(int numOfRows = -1) => ConvertTable(psychometricTable, numOfRows);
        public List<List<string>> GetJavaResults(int numOfRows = -1) => ConvertTable(javaTable, numOfRows);
        public List<List<string>> GetPythonResults(int numOfRows = -1) => ConvertTable(pythonTable, numOfRows);
        public List<List<string>> GetCSharpResults(int numOfRows = -1) => ConvertTable(cSharpTable, numOfRows);
        public List<List<string>> GetPythonLearningPathResults(int numOfRows = -1) => ConvertTable(pythonLearningPathTable, numOfRows);
    }
}