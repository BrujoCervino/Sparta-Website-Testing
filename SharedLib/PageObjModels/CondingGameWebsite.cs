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
            SleepDriver(2);
            codingGamePage.ClickTOSCheckBox();
            SleepDriver(2);
            codingGamePage.ClickbeginButton();

            for (int i = 0; i < 4; i++)
            {
                SleepDriver(2);
                codingGamePage.ClickRandomAnswer();
                SleepDriver(2);
                codingGamePage.ClicknextSubmitButton();
            }
        }
    }
}