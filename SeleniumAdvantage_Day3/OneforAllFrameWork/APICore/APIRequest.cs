using System.Net;
using System.ServiceModel;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace OneforAllFrameWork
{
    public static class Helper
    {
        private static BasicHttpBinding _basicHttpBinding;
        private static RestRequest _restRequest;
        private static RestResponse _restResponse;


        public static string DeserializeResponseUsingJObject(this RestResponse restResponse, string responseObj)
        {
            var jObject = JObject.Parse(restResponse.Content);
            return jObject[responseObj]?.ToString();
        }

        public static bool IsSuccessStatusCode(this HttpStatusCode responseCode)
        {
            var numericResponse = (int)responseCode;

            const int statusCodeOk = (int)HttpStatusCode.OK;

            const int statusCodeBadRequest = (int)HttpStatusCode.BadRequest;

            return numericResponse >= statusCodeOk &&
                   numericResponse < statusCodeBadRequest;
        }

        public static RestRequest CreateGetRequest(string optionalEndPoint = null)
        {
            _restRequest = new RestRequest(optionalEndPoint, Method.Get);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public static RestRequest CreatePostRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.Post);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public static RestRequest CreatePutRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.Put);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public static RestRequest CreatePatchRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.Patch);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public static RestRequest CreateDeleteRequest()
        {
            _restRequest = new RestRequest(Method.Delete);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public static RestResponse GetResponse(RestClient restClient, RestRequest request)
        {
            return restClient.Execute(request);
        }


    }

}