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

        private IWebElement psychometricTableHeaders => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(4) > thead:nth-child(1) > tr:nth-child(1)"));
        private IWebElement javaTableHeaders => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(6) > thead:nth-child(1) > tr:nth-child(1)"));
        private IWebElement pythonTableHeaders => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(8) > thead:nth-child(1) > tr:nth-child(1)"));
        private IWebElement cSharpTableHeaders => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(10) > thead:nth-child(1) > tr:nth-child(1)"));
        private IWebElement pythonLearningPathTableHeaders => _seleniumDriver.FindElement(By.CssSelector("table.table:nth-child(12) > thead:nth-child(1) > tr:nth-child(1)"));

        public ResultsPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = PagesConfigReader.ResultsUrl;
        }

        public List<List<string>> GetPsychometricResults(int numOfRows = -1) => ConvertTable(psychometricTable, numOfRows);
        public List<List<string>> GetJavaResults(int numOfRows = -1) => ConvertTable(javaTable, numOfRows);
        public List<List<string>> GetPythonResults(int numOfRows = -1) => ConvertTable(pythonTable, numOfRows);
        public List<List<string>> GetCSharpResults(int numOfRows = -1) => ConvertTable(cSharpTable, numOfRows);
        public List<List<string>> GetPythonLearningPathResults(int numOfRows = -1) => ConvertTable(pythonLearningPathTable, numOfRows);

        public List<string> GetPsychometricTableHeaders() => ConvertTableHeaders(psychometricTableHeaders);
        public List<string> GetJavaTableHeaders() => ConvertTableHeaders(javaTableHeaders);
        public List<string> GetPythonTableHeaders() => ConvertTableHeaders(pythonTableHeaders);
        public List<string> GetCSharpTableHeaders() => ConvertTableHeaders(cSharpTableHeaders);
        public List<string> GetPythonLearningPathTableHeaders() => ConvertTableHeaders(pythonLearningPathTableHeaders);
    }
}