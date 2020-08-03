using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PageObjectModels.POM
{
    public class PollsPage : TablePage
    {
        public List<PollsKeyValues> pollsList = new List<PollsKeyValues>();
        public ReadOnlyCollection<IWebElement> thElements => _seleniumDriver.FindElements(By.CssSelector("tbody tr th"));
        public ReadOnlyCollection<IWebElement> tdElements => _seleniumDriver.FindElements(By.CssSelector("tbody tr td"));
        private IWebElement tableBody => _seleniumDriver.FindElement(By.CssSelector(".table > tbody:nth-child(2)"));

        public PollsPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = PagesConfigReader.PollsUrl;
        }

        public void GetTableContent()
        {
            var splitTds = tdElements.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 3)
                .Select(x => x.Select(v => v.Value).ToList()).ToList();

            for (int i = 0; i < thElements.Count; i++)
            {
                pollsList.Add(
                    new PollsKeyValues(
                        thElements[i].Text,
                        splitTds[i][0].Text,
                        splitTds[i][1].Text,
                        splitTds[i][2].Text
                    )
                );
            }
        }
        public List<List<string>> GetTabelData(int numOfRows = -1) => ConvertTable(tableBody, numOfRows);
    }
}
