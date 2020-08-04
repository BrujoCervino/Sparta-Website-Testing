using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace EmailApi
{
    public class GmailAPIManager
    {
        private static string[] Scopes = { GmailService.Scope.GmailReadonly };
        private static string ApplicationName = "Gmail API .NET Quickstart";
        private string codingameUrl = "";
        private UserCredential credential;


		public GmailAPIManager()
		{
            //Autorisation for Gmail Credentials
            using (FileStream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "GmailAPI\\credentials.json", FileMode.Open, FileAccess.Read))
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
            }
        }

        public string GetEmailUrl()
        {
            //"me" is the identifier used by google to represent authenticated user.
            Message message = CreateService().Users.Messages.Get("me", GetMostCurrentEmailID()).Execute();

            //Choose which format you want to recieve response, [0],[0] test. [0],[1] html
            string data = message.Payload.Parts[0].Parts[0].Body.Data;

			//Replace invlaid char with correct
			byte[] base64EncodedResponse = Convert.FromBase64String(data.Replace("_", "/").Replace("-","+"));

            string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(base64EncodedResponse);

			//Find the URL within the text response
			Regex pattern = new Regex(@"(https://www\.codingame\.com/evaluate)\S+");

            foreach (Match m in pattern.Matches(base64Decoded))
            {
                codingameUrl = m.Value;
            }
            return codingameUrl;
        }

        internal GmailService CreateService() 
        {
            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }

        internal string GetMostCurrentEmailID()
        {
            List<Message> emailID = ListMessages(CreateService(), "me", "");

            var firstMessageResponse = emailID[0];
            return firstMessageResponse.Id;
        }

        internal static List<Message> ListMessages(GmailService service, String userId, String query)
        {
            List<Message> result = new List<Message>();
            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
            request.Q = query;

            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(request.PageToken));

            return result;
        }


    }
}