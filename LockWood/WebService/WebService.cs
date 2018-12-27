using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace LockWood.WebService
{
    public class WebService
    {
        public static string baseUrl = "localHost:8080/WorkWebService/webapi/WebService";
        public WebService()
        {
        }

        public List<string> getSourcesFromDatabase()
        {
            var url = baseUrl + "/getSources/";
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


    }
}
