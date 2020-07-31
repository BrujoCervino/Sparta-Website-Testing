using System;

namespace PageObjectModels
{
    public class DispatchesKeyValues
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Recruiter { get; set; }
        public string Assessment { get; set; }
        public string TestId { get; set; }
        public string TimeSent { get; set; }
        public string Complete { get; set; }

        public string Expired { get; set; }

        public DispatchesKeyValues(string name, string email, string recruiter, string assessment, string testId, string timeSpent, string complete, string expired)
        {
            Name = name;
            Email = email;
            Recruiter = recruiter;
            Assessment = assessment;
            TestId = testId;
            TimeSent = timeSpent;
            Complete = complete;
            Expired = expired;
        }
    }
}
