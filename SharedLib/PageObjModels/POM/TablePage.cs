using OpenQA.Selenium;
using System.Collections.Generic;

namespace PageObjModels.POM
{
    public abstract class TablePage : NavigationObjs
    {
        public TablePage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
        }

        protected List<List<string>> ConvertTable(IWebElement tableBody, int numOfRows = -1)
        {
            List<List<string>> output = new List<List<string>>();
            int rowCount = 0;
            foreach (IWebElement row in tableBody.FindElements(By.TagName("tr")))
            {
                List<string> rowLst = new List<string>();

                //gets table header cell
                rowLst.Add(row.FindElement(By.TagName("th")).Text);

                //gets the rest of the data cells from that row
                foreach (IWebElement tabelCell in row.FindElements(By.TagName("td")))
                {
                    rowLst.Add(tabelCell.Text);
                }
                output.Add(rowLst);

                rowCount++;
                if (numOfRows >= 0 && rowCount >= numOfRows)
                    break;
            }
            return output;
        }

        protected List<string> ConvertTableHeaders(IWebElement TableHeaderRow)
        {
            List<string> output = new List<string>();

            foreach(IWebElement header in TableHeaderRow.FindElements(By.TagName("th")))
            {
                output.Add(header.Text);
            }

            return output;
        }

        protected int TotalCountNumOfRows(IWebElement tableBody)
        {
            int rowCount = 0;
            foreach (IWebElement row in tableBody.FindElements(By.TagName("tr")))
            {
                rowCount++;
            }
            return rowCount;
        }
    }
}