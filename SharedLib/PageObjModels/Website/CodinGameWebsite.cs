using PageObjectModels.POM;
using System;

namespace PageObjModels
{
    public class CodinGameWebsite : Website
    {
        public CodinGame codinGamePage;

        public CodinGameWebsite(string driverName, string testUrl, int pageLoadInSeconds = 5, int implicitWaitInSeconds = 5) : base(driverName, pageLoadInSeconds, implicitWaitInSeconds)
        {
            codinGamePage = new CodinGame(SeleniumDriver, testUrl);
        }

        public void DoTest()
        {
            const int sleepTime = 4, numOfQuestions = 4;

            codinGamePage.ClickstartButton();
            SleepDriver(sleepTime);
            codinGamePage.ClickTOSCheckBox();
            SleepDriver(sleepTime);
            codinGamePage.ClickbeginButton();
            SleepDriver(sleepTime);

            for (int i = 1; i <= numOfQuestions; i++)
            {
                codinGamePage.ClickQuestion(i);
                SleepDriver(sleepTime);
                codinGamePage.ClickRandomAnswer();
                SleepDriver(sleepTime);
                codinGamePage.ClicknextSubmitButton();
                SleepDriver(sleepTime);
            }

            codinGamePage.ClickEndTest();
            SleepDriver(sleepTime);
            codinGamePage.ClickConfEnd();
            SleepDriver(sleepTime);
        }

        public void StatTest()
        {
            const int sleepTime = 4;

            codinGamePage.ClickstartButton();
            SleepDriver(sleepTime);
            codinGamePage.ClickTOSCheckBox();
            SleepDriver(sleepTime);
            codinGamePage.ClickbeginButton();
            SleepDriver(sleepTime);
        }
    }
}