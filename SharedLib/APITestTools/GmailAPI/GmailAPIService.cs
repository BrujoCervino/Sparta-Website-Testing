using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace EmailApi
{
    public class GmailAPIManager
    {
        private static string[] Scopes = { GmailService.Scope.GmailReadonly };
        private static string ApplicationName = "Gmail API .NET Quickstart";
        public string GmailUrl = "";

        public string SetUp()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            Message message = service.Users.Messages.Get("me", "173b42133cd76c1a").Execute();
            string data = message.Payload.Parts[0].Parts[0].Body.Data;
            string formatData = data.Replace("-", "+");
            var base64EncodedResponse = Convert.FromBase64String(formatData.Replace("_", "/"));

            string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(base64EncodedResponse);

            var pattern = new Regex(@"(https://www\.codingame\.com/evaluate)\S+");

            foreach (Match m in pattern.Matches(base64Decoded))
            {
                GmailUrl = m.Value;
            }
            return GmailUrl;
        }
    }
}