using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PageObjectModels;
using RestSharp;

namespace APITestTools.SpartaAPI
{
    public class SpartaAPIService
    {
        public SpartaAPIManager spartaManager = new SpartaAPIManager();
        public string spartaAuthData;
        public string spartaDeleteData;
        public JObject json_auth_sparta;
        public JObject json_delete_sparta;
        private string token;

        public SpartaAPIService()
        {
            spartaAuthData = spartaManager.AuthorisationToDelete();
            json_auth_sparta = JsonConvert.DeserializeObject<JObject>(spartaAuthData);
            token = json_auth_sparta["token"].ToString();
        }
        public void DeleteDispatches()
        { 
            spartaDeleteData = spartaManager.DeleteDispatchesTable(token);
            json_delete_sparta = JsonConvert.DeserializeObject<JObject>(spartaDeleteData);
        }
    }
    internal class test
    {
        [Test]
        public void testing123()
        {
            SpartaAPIService sparta = new SpartaAPIService();
            sparta.DeleteDispatches();
            Assert.That(sparta.json_delete_sparta["success"].ToString(), Is.EqualTo("True"));
        }
    }
}
