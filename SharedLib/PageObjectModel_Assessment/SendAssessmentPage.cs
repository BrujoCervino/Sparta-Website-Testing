using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLib;

namespace PageObjectModel_Assessment
{
    public class SendAssessmentPage : SuperPage
    {
        public SendAssessmentPage(IwebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "https://uat.spartaglobal.academy/";
        }

    }
}
