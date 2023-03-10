using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public int expectedCodeInt = 200;
        public int statusCodeInt;

        public ListsOfUsers GetUsers()
        {
            RestClient client = new RestClient("https://reqres.in/");

            RestRequest request = new RestRequest("/api/users?page=2", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            var statusCodeString = response.StatusCode.ToString();
            statusCodeInt = (int)response.StatusCode;
            var users = JsonConvert.DeserializeObject<ListsOfUsers>(content);

            // вывод в консоль всех пользователей
            for (int i = 0; i < users.data.Count; i++)
            {
                Console.WriteLine(users.data[i].first_name + " " + users.data[i].last_name);

            }

            return users;


        }
    }
}
