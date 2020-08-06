using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjModels
{
    public class PollsKeyValues
    {

        public string PollTime { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string TestId { get; set; }

        public PollsKeyValues(string pollTime, string email, string status, string testId)
        {
            PollTime = pollTime;
            Status = status;
            Email = email;
            TestId = testId;
        }
    }
}
