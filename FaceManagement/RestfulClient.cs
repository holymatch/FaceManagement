using RestfulClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FaceManagement
{
    class RestfulClient
    {
        public static HttpClient client = new HttpClient();
        private static string baseurl = "";

        public static bool setBaseAddress(string hosts)
        {
            if (hosts.ToLower().StartsWith("http://") || hosts.ToLower().StartsWith("https://"))
            {
                baseurl = hosts;
            }
            else
            {
                baseurl = "http://" + hosts + "/";
            }
            client.CancelPendingRequests();
            client.Dispose();
            client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);

            // return URI of the created resource.
            var result = HealthChech();
            return result.Equals("UP");
        }

        static async Task<String> HealthChech()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.
            var response = await client.GetStringAsync("health");
            Debug.Write("Health Check response is :" + response);
            //Console.WriteLine(response.Content);
            //Console.WriteLine("RequestMessageContect " + response.RequestMessage.Content);
            return response;
            //return await response.Content.ReadAsAsync<HealthcheckResponse>();

        }

        static async Task<Person> CreateGenAsync(String image)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "faceweb/recognize", image);
            response.EnsureSuccessStatusCode();
            Person person = null;
            if (response.IsSuccessStatusCode)
            {
                person = await response.Content.ReadAsAsync<Person>();
            }

            // return URI of the created resource.
            return person;
        }

        public static async Task<JsonResponseMessage<Person>> CreatePerson(Person person)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "faceweb/people", person);
            return await response.Content.ReadAsAsync<JsonResponseMessage<Person>>();
        }

        public static async Task<JsonResponseMessage<Person>> UpdatePerson(Person person)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                "faceweb/people/" + person.Id, person);
            return await response.Content.ReadAsAsync<JsonResponseMessage<Person>>();
        }

        public static async Task<HttpResponseMessage> RemovePerson(Person person)
        {
            HttpResponseMessage response = await client.DeleteAsync("faceweb/people/" + person.Id);
            return response;
        }

        public static async Task<JsonResponseMessage<Person>> Recognize(WebEntity.Face face)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "faceweb/recognize", face);
            Console.WriteLine(response.Content);
            Console.WriteLine("RequestMessageContect " + response.RequestMessage.Content);
            return await response.Content.ReadAsAsync<JsonResponseMessage<Person>>();
        }

        public static async Task<JsonResponseMessage<List<Person>>> ListPeople()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("faceweb/people");
            Console.WriteLine(response.Content);
            Console.WriteLine("RequestMessageContect " + response.RequestMessage.Content);
            return await response.Content.ReadAsAsync<JsonResponseMessage<List<Person>>>();
        }

        /*static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5002/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var image = Convert.ToBase64String(File.ReadAllBytes(@"TestingFace\DSC_4274_l.jpg"));

                //var result = await CreateFace(new Face(image, "tester"));
                var result = await Recognize(image);
                //Console.WriteLine(image);
                //var person = await CreateGenAsync(image);
                //Console.WriteLine($"Person Name:{person.Name} \nPerson Detail:{person.Detail}\nScore: {person.Score}");
                Console.WriteLine("Result : " + result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }*/
    }

    class JsonResponseMessage<T>
    {
        public T Content { get; set; }
        public int ReturnCode { get; set; }
        public string Message { get; set; }
    }

    class HealthcheckResponse
    {
        public string status { get; set; }
    }
}
