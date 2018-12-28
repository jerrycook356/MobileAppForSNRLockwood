using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using LockWood.Models;
using System.Net.Http;
using System.Text;

namespace LockWood.WebService
{
    public class WebService
    {
        public static string baseUrl = "http://192.168.254.98:80/WorkWebService/webapi/WebService";
        public WebService()
        {
        }

        public List<string> getSourcesFromDatabase()
        {
            var url = baseUrl + "/getSources";
            List<string> sources = new List<string>();
            using (WebClient webClient = new WebClient())
            {
                try{
                    var content = webClient.DownloadString(url);
                    sources = JsonConvert.DeserializeObject<List<string>>(content);
                }catch(Exception e)
                {
                    Console.Out.WriteLine(e);
                }
            }
           
            return sources;
        }

        public List<string> GetDestinationsFromDatabase()
        {
            var url = baseUrl + "/getDestinations";
            List<string> destinations = new List<string>();

            using (WebClient webClient = new WebClient())
            {
                try{
                    var content = webClient.DownloadString(url);
                    destinations = JsonConvert.DeserializeObject<List<string>>(content);
                }catch(Exception e)
                {
                    Console.Out.WriteLine(e);
                }

            }
            return destinations;
        }

        public List<string>GetCustomersFromDatabase()
        {
            List<string> customers = new List<string>();
            var url = baseUrl + "/getCustomers";
            using (WebClient webClient = new WebClient())
            {
                try{
                    var content = webClient.DownloadString(url);
                    customers = JsonConvert.DeserializeObject<List<string>>(content);
                }catch(Exception e)
                {
                    Console.Out.WriteLine(e);
                }
            }
            return customers;
        }
        public List<Transaction> GetTransactions(Transaction transaction)
        {
            List<Transaction> transactions = new List<Transaction>();
            var url = baseUrl + "/getBySelection";
            var content = JsonConvert.SerializeObject(transaction);
            var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
            using (var httpClient = new HttpClient())
            {
                var httpRequest =  httpClient.PostAsync(url, httpContent);
               
                Console.Out.WriteLine(httpRequest.ToString());
            }
            return transactions;
        }

       
    }
}
