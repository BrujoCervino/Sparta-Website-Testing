using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PageObjectModels;
using RestSharp;

namespace APITestTools.SpartaAPI
{
    public class SpartaAPIManager
    {
        private readonly IRestClient client;
        public SpartaAPIManager()
        {
            client = new RestClient(PagesConfigReader.BaseUrl);
        }
        public string AuthorisationToDelete()
        {
            var request = new RestRequest("api/users/auth");
            request.AddJsonBody(new { username = LoginConfigReader.Username, password = LoginConfigReader.Password });
            var response = client.Execute(request, Method.POST);
            return response.Content;
        }
        public string DeleteDispatchesTable(string token)
        {
            var request = new RestRequest("api/dispatch");
            request.AddHeader("x-access-token", token);
            var response = client.Execute(request, Method.DELETE);
            return response.Content;
        }
    }
}
