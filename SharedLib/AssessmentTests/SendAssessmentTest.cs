using NUnit.Framework;
using PageObjectModels;

namespace AssessmentTests
{
    public class AssessmentNavigationTests
    {
        private SpartaWebsite _website;
        private const int _sleepTime = 5;

        [SetUp]
        public void Setup()
        {
            _website = new SpartaWebsite("chrome", _sleepTime, _sleepTime);           
        }

        [Test]
        public void DirverWorkingTest()
        {
            _website.assessmentPage.Visit();
            Assert.That(_website.GetUrl(), Is.EqualTo("https://uat.spartaglobal.academy/"));
        }

        [TearDown]
        public void TearDown()
        {
            _website.Close();
        }
    }
}
