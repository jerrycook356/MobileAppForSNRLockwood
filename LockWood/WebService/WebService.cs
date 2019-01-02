using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using LockWood.Models;
using System.Net.Http;
using System.Text;
using System.Globalization;

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
        public List<Transaction> GetSelectedTransactions(Transaction transaction)
        {
            List<Transaction> transactions = new List<Transaction>();
            //convert startdate string
            string startDate = transaction.GetStartDate();
            DateTime dt = DateTime.ParseExact(startDate, "MM/dd/yyyy",null);
            string startDateString = dt.ToString("yyyy-MM-dd", null);
           string completeStartDate = "?startDate="+ startDateString + " 00:00:00.000000";

            //convert endDate string
            string endDate = transaction.GetEndDate();
            dt = DateTime.ParseExact(endDate, "MM/dd/yyyy", null);
            string endDateString = dt.ToString("yyyy-MM-dd", null);
            string completeEndDate = "&endDate="+endDateString + " 23:59:59.000000";

            var sourceString = "&source=" + transaction.GetSource();
            var destinationString = "&destination=" + transaction.GetDestination();
            var customerString = "&customer=" + transaction.GetCustomer();
            var url = baseUrl + "/getBySelection"+completeStartDate+completeEndDate+
                sourceString+destinationString+customerString;

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    var content = webClient.DownloadString(url);
                    transactions = JsonConvert.DeserializeObject<List<Transaction>>(content);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e);
                }
            }
           
            return transactions;
        }


    }
}
