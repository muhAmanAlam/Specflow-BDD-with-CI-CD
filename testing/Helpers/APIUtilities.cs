using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using SpecFlow.Internal.Json;

namespace testing.Helpers
{
    internal class APIUtilities
    {
        static RestResponse response;
        static RestClient client;
        static RestRequest request;

        public static void SetupClient(string baseUrl) {
            var options = new RestClientOptions(baseUrl);
            client = new RestClient(options);
        }

        public static void SetupRequest(string endPoint) 
        {
            request = new RestRequest(endPoint);
        }
        

        public static void AddToHeader(string key, string value) 
        {

            request.AddHeader(key, value);
        }

        public static void AddParameterToRequest(string key, string value)
        {

            request.AddParameter(key, value);
        }
        
        public static void AddRequestBody(string body)
        {

            request.AddJsonBody(body);
        }
        
        public static void AddRequestMethod(string method)
        {

            switch (method.ToUpper())
            {
                case "GET":
                    request.Method = Method.Get;
                    break;
                case "POST":
                    request.Method = Method.Post;
                    break;
                case "PUT":
                    request.Method = Method.Put;
                    break;
                case "PATCH":
                    request.Method = Method.Patch;
                    break;
                case "DELETE":
                    request.Method = Method.Delete;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        $"The request method:\"{method}\" is not supported please use of these values: GET, POST, PUT, PATCH or DELETE."
                        );

            }
        }

        public static void ExecuteRequest()
        {
            response = client.Execute(request);
            //Console.WriteLine("Request Body:\n" + response.Content);
        }

        public static int GetResponseCode()
        {
            return (int) response.StatusCode;
        }
        
        public static string GetResponseURI()
        {
            return response.ResponseUri.ToString();
        }
        
        public static string GetResponseContent()
        {
            return response.Content;
        }


    }
}
