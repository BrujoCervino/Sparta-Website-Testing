using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PageObjModels.POM
{
    public class DispatchesPage : TablePage
    {
        private IWebElement tableBody => _seleniumDriver.FindElement(By.CssSelector(".table > tbody:nth-child(2)"));
        private IWebElement tableHeaderRow => _seleniumDriver.FindElement(By.CssSelector(".thead-dark > tr:nth-child(1)"));
        public ReadOnlyCollection<IWebElement> thElements => _seleniumDriver.FindElements(By.CssSelector("tbody tr th"));
        public ReadOnlyCollection<IWebElement> tdElements => _seleniumDriver.FindElements(By.CssSelector("tbody tr td"));

        public DispatchesPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = PagesConfigReader.DispatchesUrl;
        }

        public List<List<string>> GetTableData(int numOfRows = -1) => ConvertTable(tableBody, numOfRows);

        public List<string> GetTableHeaders() => ConvertTableHeaders(tableHeaderRow);

        public bool CheckTestsSentOut(List<string> testNames, int numOfRowsToCompare)
        {
            List<string> testsInTable = new List<string>();
            foreach (List<string> row in GetTableData(numOfRowsToCompare))
            {
                testsInTable.Add(row[3]);
            }

            foreach (var name in testNames)
            {
                if (!testsInTable.Contains(name))
                    return false;
            }
            return true;
        }

        public bool CompareFirstRowData(Dictionary<string, string> tableData)
        {
            List<string> headers = GetTableHeaders();
            List<string> dispatchRow = GetTableData()[0];

            foreach (KeyValuePair<string, string> pair in tableData)
            {
                if (pair.Value != dispatchRow[headers.IndexOf(pair.Key)])
                    return false;
            }

            return true;
        }
    }
}