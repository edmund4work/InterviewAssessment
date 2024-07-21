using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace citiFM_Assessment2023.Controller
{
    public class apiCommonCode
    {
        public static string defaultApiKey = "API-11YBQ5W9BXY3RPB";
        public static string defaultApiUrl = "http://alltheclouds.com.au/api/";


        public static string callAPIPost(string urlCall, object data)
        {
            string returnData = "";
            var request = (HttpWebRequest)WebRequest.Create(defaultApiUrl + urlCall);
            request.Method = "POST";
            //request.Headers.Add("accept", "application/json");
            request.Headers.Add("api-key", defaultApiKey);
            var requestBody = JsonConvert.SerializeObject(data);
            byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var content = reader.ReadToEnd();
                        returnData = (content);
                    }
                    else
                    {
                        Console.WriteLine("Request failed with status: " + response.StatusCode);
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return returnData;
        }

        public static string callAPIGet(string urlCall)
        {
            string returnData = "";
            var request = (HttpWebRequest)WebRequest.Create(defaultApiUrl + urlCall);
            request.Method = "GET";
            request.Headers.Add("api-key", defaultApiKey);

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var content = reader.ReadToEnd();
                        returnData = (content);
                    }
                    else
                    {
                        Console.WriteLine("Request failed with status: " + response.StatusCode);
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return returnData;
        }

    }
}