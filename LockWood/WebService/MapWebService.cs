using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using LockWood.Models;
using Newtonsoft.Json;

namespace LockWood.WebService
{
    public class MapWebService
    {
        public MapWebService()
        {
        }
        public static string baseUrl = "http://192.168.254.98:80/WorkMapWebService/webapi/WebService";


        public List<CoalAnnotation> getAnnotationsFromDatabase()
        {
            var url = baseUrl + "/getAll";
            List<CoalAnnotation> annots = new List<CoalAnnotation>();
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    var content = webClient.DownloadString(url);
                    annots = JsonConvert.DeserializeObject<List<CoalAnnotation>>(content);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e);
                }
            }
            annots = ConvertAnnots(annots);
            return annots;
        }

        public List<CoalAnnotation> ConvertAnnots(List<CoalAnnotation> annots){
            List<CoalAnnotation> newAnnots = new List<CoalAnnotation>();
            foreach(CoalAnnotation a in annots){
                double id = a.GetId();
                string stockpile = a.stockpile;
                string company = a.company;
                string source = a.source;
                double latitude = a.latitude;
                double longitude = a.longitude;
                CoalAnnotation newAnnotation = new CoalAnnotation(
                    id, stockpile, company, source, latitude, longitude);

                newAnnots.Add(newAnnotation);

            }
            return newAnnots;
        }

        public async void SaveAnnotation(CoalAnnotation annotation){
            var url = baseUrl + "/addAnnot";
            var content = JsonConvert.SerializeObject(annotation, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpRequest = await httpClient.PostAsync(url, httpContent);
            }
        }
    }
}
