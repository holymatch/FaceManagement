using RestfulClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVTest
{
    class RestfulClient
    {
        static HttpClient client = new HttpClient();

        static RestfulClient() {
            //client.BaseAddress = new Uri("http://192.168.11.92:5002/");
            //client.BaseAddress = new Uri("http://localhost:3000/");
            //client.BaseAddress = new Uri("http://192.168.11.92:3000/");
            client.BaseAddress = new Uri("http://192.168.11.92:8080/faceweb/");
        }

        static async Task<Person> CreateGenAsync(String image)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "recognize", image);
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
                "people", person);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<JsonResponseMessage<Person>>();
        }

        public static async Task<JsonResponseMessage<Person>> Recognize(WebEntity.Face face)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "recognize", face);
            Console.WriteLine(response.Content);
            Console.WriteLine("RequestMessageContect " + response.RequestMessage.Content);
            return await response.Content.ReadAsAsync<JsonResponseMessage<Person>>();
        }

        public static async Task<JsonResponseMessage<List<Person>>> ListPeople()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("people");
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
}
