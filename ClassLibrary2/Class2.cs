using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Class2
    {
        public  int id = 4;
        public string token = "QpwL5tke4Pnpja7X4";
        public int expectedCodeSuccessful = 200;
        public int expectedCodeUnSuccessful = 400;
        public int statusCodeIntSuccessful;
        public int statusCodeIntUnSuccessful;

        public SuccessfulRegistration SuccessfulResultRegistration()
        {
            RestClient client = new RestClient("https://reqres.in/");

            RestRequest request = new RestRequest("api/register", Method.POST);
            Registration reg = new Registration("eve.holt@reqres.in", "pistol");
            request.AddJsonBody(reg);

            IRestResponse response = client.Post(request);
            var content = response.Content;
            var statusCodeString = response.StatusCode.ToString();
            statusCodeIntSuccessful = (int)response.StatusCode;
            var resultRegistration = JsonConvert.DeserializeObject<SuccessfulRegistration>(content);

            return resultRegistration;
        }

        public UnSuccessfulRegistration UnSuccessfulRegistration()
        {
            RestClient client = new RestClient("https://reqres.in/");

            RestRequest request = new RestRequest("api/register", Method.POST);
            Registration reg = new Registration("sydney@fife", "");
            request.AddJsonBody(reg);

            IRestResponse response = client.Post(request);
            var content = response.Content;
            var statusCodeString = response.StatusCode.ToString();
            statusCodeIntUnSuccessful = (int)response.StatusCode;
            var resultRegistration = JsonConvert.DeserializeObject<UnSuccessfulRegistration>(content);

            return resultRegistration;
        }
    }
}
