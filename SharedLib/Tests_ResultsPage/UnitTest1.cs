using NUnit.Framework;
using PageObjectModel_Results;

namespace Tests_ResultsPage
{
    [Author("K McEvaddy")]
    public class Tests
    {
        public SpartaWebsite spartaWebsite;

        [SetUp]
        public void Setup()
        {
            spartaWebsite = new SpartaWebsite("firefox");
        }

        [Test]
        public void Test1()
        {
            spartaWebsite.resultsPage.MaximisePage();
            Assert.Pass();
        }
    }
}