using OpenQA.Selenium;
using System.Collections.Generic;

namespace PageObjectModels.POM
{
    public abstract class TablePage : SuperPage
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
    }
}