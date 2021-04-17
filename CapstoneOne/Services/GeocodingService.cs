using CapstoneOne.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

//namespace CapstoneOne.Services
//{
//    public class GeocodingService
//    {
//        //private string GetGeoCodingURL(Customer customer)
//        //{
//        //    return $"https://maps.googleapis.com/maps/api/geocode/json?address={customer.StreetName}+{customer.City}+{customer.State}+&key="
//        //        + APIkeys.GoogleAPIKey;
//        //}

//        public async Task<Customer> GetGeoCoding(Customer customer)
//        {
//            string apiUrl = GetGeoCodingURL(customer);

//            using (HttpClient client = new HttpClient())
//            {
//                client.BaseAddress = new Uri(apiUrl);
//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));

//                HttpResponseMessage response = await client.GetAsync(apiUrl);

//                if (response.IsSuccessStatusCode)
//                {
//                    string data = await response.Content.ReadAsStringAsync();
//                    JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
//                    JToken results = jsonResults["results"][0];
//                    JToken location = results["geometry"]["location"];

//                    customer.Latitude = (double)location["lat"];
//                    customer.Longitude = (double)location["lng"];

//                }
//                return customer;
//            }
//        }
//    }
//}
