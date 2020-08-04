using PageObjectModels.POM;

namespace PageObjModels
{
    public class CondingGameWebsite : Website
    {
        public CodinGame codingGamePage;

        public CondingGameWebsite(string driverName, string testUrl, int pageLoadInSeconds = 5, int implicitWaitInSeconds = 5) : base(driverName, pageLoadInSeconds, implicitWaitInSeconds)
        {
            codingGamePage = new CodinGame(SeleniumDriver, testUrl);
        }

        public void DoTest()
        {
            codingGamePage.ClickstartButton();
            SleepDriver(4);
            codingGamePage.ClickTOSCheckBox();
            SleepDriver(4);
            codingGamePage.ClickbeginButton();
            SleepDriver(4);
            codingGamePage.Click1Question();
            SleepDriver(4);
            codingGamePage.ClickRandomAnswer();
            SleepDriver(4);
            codingGamePage.ClicknextSubmitButton();
            SleepDriver(4);
            codingGamePage.Click2Question();
            SleepDriver(4);
            codingGamePage.ClickRandomAnswer();
            SleepDriver(4);
            codingGamePage.ClicknextSubmitButton();
            SleepDriver(4);
            codingGamePage.Click3Question();
            SleepDriver(4);
            codingGamePage.ClickRandomAnswer();
            SleepDriver(4);
            codingGamePage.ClicknextSubmitButton();
            SleepDriver(4);
            codingGamePage.Click4Question();
            SleepDriver(4);
            codingGamePage.ClickRandomAnswer();
            SleepDriver(4);
            codingGamePage.ClicknextSubmitButton();
            SleepDriver(4);
            codingGamePage.ClickEndTest();
            SleepDriver(4);
            codingGamePage.ClickConfEnd();
            SleepDriver(4);
        }
    }
}