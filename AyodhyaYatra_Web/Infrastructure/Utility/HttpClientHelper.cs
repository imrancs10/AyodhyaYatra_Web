using DataLayer;
using AyodhyaYatra_Web.Global;
using AyodhyaYatra_Web.Infrastructure.Authentication;
using AyodhyaYatra_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AyodhyaYatra_Web.Global.Enums;
using AyodhyaYatra_Web.BAL.Masters;
using AyodhyaYatra_Web.Models.Masters;
using System.Configuration;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using Newtonsoft.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Net;

namespace AyodhyaYatra_Web.Infrastructure.Utility
{
    public static class HttpClientHelper<T>
    {
        //private const string BaseURL = "https://localhost:7216/v1/";
        private static string BaseURL = ConfigurationManager.AppSettings["APIUrl"].ToString();
        //private string urlParameters = "?api_key=123";

        public static T GetAPIResponse(string apiUrl, string urlParameters)
        {
            var result1 = default(T);//string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseURL + apiUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            //HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            //if (response.IsSuccessStatusCode)
            //{
            //    // Parse the response body.
            //    var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            //    //foreach (var d in dataObjects)
            //    //{
            //    //    Console.WriteLine("{0}", d.Name);
            //    //}
            //     result1 = (T)Convert.ChangeType(dataObjects, typeof(T));

            //}

            using (var Response = client.GetAsync(urlParameters))
            {
                //Response.Wait();
                var result = Response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    //result1 = JsonConvert.DeserializeObject<dynamic>(readTask.Result);
                    if (typeof(T).Name == "String")
                        result1 = (T)Convert.ChangeType(readTask.Result, typeof(T));
                    else
                        result1 = JsonConvert.DeserializeObject<T>(readTask.Result);
                    //result1 = readTask.Result;
                }
            }
            client.Dispose();
            return result1;
            //else
            //{
            //    return response;
            //    //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}

            //result1 = JsonConvert.DeserializeObject<T>(dataObjects.Result);
            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.

        }
    }
}