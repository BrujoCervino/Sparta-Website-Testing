using NUnit.Framework;
using PageObjectModels;
using PageObjModels;
using SharedTestTools;
using System.Collections.Generic;

namespace DispatchesTests
{
    public class GetTableValuesTests
    {
        private SpartaWebsite _website;
        private const int _sleepTime = 5;

        [SetUp]
        public void Setup()
        {
            _website = new SpartaWebsite("chrome", _sleepTime, _sleepTime);
        }       

        [Test]
        public void GetTableValues_ReturnValues()
        { // Fragile test, Will have to look further into it when further
            TestTools.Login(_website);
            _website.dispatchesPage.Visit();
            List<List<string>> dispatchesData = _website.dispatchesPage.GetTableData();

            Assert.That(dispatchesData[0][0], Is.EqualTo("shwetha ashwathappa"));
        }

        [TearDown]
        public void TearDown()
        {
            _website.Close();
        }
    }
}
