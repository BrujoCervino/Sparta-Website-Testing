using NUnit.Framework;
using PageObjectModels;
using SharedTestTools;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace DispatchesTests.Steps
{
    [Binding]
    public class SendOutAssessmentSteps
    {
        private SpartaWebsite _website;

        #region Setup/Teardown
        [BeforeScenario]
        public void BeforeScenario()
        {
            _website = new SpartaWebsite("chrome");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _website.Close();
        }
        #endregion

        #region Arrange
        [Given(@"I have logged in successfully")]
        public void GivenIHaveLoggedInSuccessfully()
        {
            TestTools.Login(_website);
        }

        [Given(@"the assessment dropdown has CSharp selected")]
        public void GivenTheAssessmentDropdownHasCSharpSelected()
        {
            _website.assessmentPage.SelectAssessment("C# Assessment");
        }

        [Given(@"""(.*)"" is entered as a candidate name")]
        public void GivenIsEnteredAsACandidateName(string name)
        {
            _website.assessmentPage.EnterCandidateName(name);
        }

        [Given(@"""(.*)"" is entered as the candidate email")]
        public void GivenIsEnteredAsTheCandidateEmail(string email)
        {
            _website.assessmentPage.EnterCandidateEmail(email);
        }

        [Given(@"""(.*)"" is entered as the recruiter email")]
        public void GivenIsEnteredAsTheRecruiterEmail(string email)
        {
            _website.assessmentPage.EnterRecruiterEmail(email);
        }

        [Given(@"Non of the text boxes are in focus")]
        public void GivenNonOfTheTextBoxesAreInFocus()
        {
            _website.assessmentPage.ClickTitle();
        }
        #endregion

        #region Act
        [When(@"The submit button is clicked")]
        public void WhenTheSubmitButtonIsClicked()
        {
            _website.assessmentPage.SubmitDetails();
        }

        [When(@"I am on the dispatches page")]
        public void WhenIAmOnTheDispatchesPage()
        {
            _website.dispatchesPage.Visit();
        }

        #endregion

        #region Assert
        [Then(@"The dispatches table should have a new entry in it with the following data:")]
        public void ThenTheDispatchesTableShouldHaveANewEntryInItWithTheFollowingData(Table table)
        {
            List<string> dispatchRow = _website.dispatchesPage.GetTabelData()[0];
            Assert.That(dispatchRow[0], Is.EqualTo(table.Rows[0].Values.ToList()[1]));
            Assert.That(dispatchRow[1], Is.EqualTo(table.Rows[1].Values.ToList()[1]));
            Assert.That(dispatchRow[2], Is.EqualTo(table.Rows[2].Values.ToList()[1]));
            Assert.That(dispatchRow[3], Is.EqualTo(table.Rows[3].Values.ToList()[1]));
            Assert.That(dispatchRow[6], Is.EqualTo(table.Rows[4].Values.ToList()[1]));
            Assert.That(dispatchRow[7], Is.EqualTo(table.Rows[5].Values.ToList()[1]));
        }
        #endregion
    }
}
