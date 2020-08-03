﻿using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PageObjectModels.POM
{
    public class DispatchesPage : SuperPage
    {
        public List<DispatchesKeyValues> dispatchesList = new List<DispatchesKeyValues>();
        public ReadOnlyCollection<IWebElement> thElements => _seleniumDriver.FindElements(By.CssSelector("tbody tr th"));
        public ReadOnlyCollection<IWebElement> tdElements => _seleniumDriver.FindElements(By.CssSelector("tbody tr td"));

        public DispatchesPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = PagesConfigReader.DispatchesUrl;
        }

        public void GetTableContent()
        { // Code is temporary (Doom is Eternal), Will look towards a better approach.
            var splitTds = tdElements.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 7)
                .Select(x => x.Select(v => v.Value).ToList()).ToList();

            for (int i = 0; i < thElements.Count; i++)
            {
                dispatchesList.Add(
                    new DispatchesKeyValues(   
                        thElements[i].Text,
                        splitTds[i][0].Text,
                        splitTds[i][1].Text,
                        splitTds[i][2].Text,
                        splitTds[i][3].Text,
                        splitTds[i][4].Text,
                        splitTds[i][5].Text,
                        splitTds[i][6].Text
                    )
                );
            }
        }
    }
}