using FinalFramework.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalFramework.APICore
{
    public class APIRequest
    {
        public HttpWebRequest request;
        public string url { get; set; }
        public string requestBody { get; set; }
        public string formData { get; set; }
        public string Method { get; set; }

        public APIRequest SetUrl(string url)
        {
            this.url = url;
            request = (HttpWebRequest)WebRequest.Create(url);
            return this;
        }

        public APIResponse Post()
        {

            throw new NotImplementedException();
        }

        public APIRequest()
        {
            url = "";
            requestBody = "";
            formData = "";
        }

        public APIRequest AddHeader(string key, string value)
        {
            request.Headers.Add(key, value);
            return this;
        }
        public APIRequest SetRequestParameter(string key, string value)
        {
            if (url.Contains("?"))
            {
                url = url + "?" + key + "=" + value;
            }
            else
            {
                url = url + "&" + key + "=" + value;
            }
            return this;
        }

        public APIRequest AddFormData(string key, string value)
        {
            if (formData.Equals("") || formData == null)
            {
                formData += key + "=" + value;
            }
            else
            {
                formData += "&" + key + "=" + value;
            }
            return this;
        }

        public APIRequest SetBody(string body)
        {
            this.requestBody = body;
            return this;
        }
        public APIResponse SendRequest()
        {
            if (request.Method == "GET")
            {
                requestBody = null;
            }
            else
            {
                if (requestBody != null)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
                if (!formData.Equals("."))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Flush();
                        dataStream.Close();
                    }
                }
            }
            try
            {
                IAsyncResult asyncResult = request.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
                var httpResponse = (HttpWebResponse)request.EndGetResponse(asyncResult);
                APIResponse response = new APIResponse(httpResponse);
                HtmlReport.CreateAPIRequestLog(this, response);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
