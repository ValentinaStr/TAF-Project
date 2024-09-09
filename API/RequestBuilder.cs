using Core.Utilits;
using Newtonsoft.Json;
using RestSharp;

namespace API
{
    public class RequestBuilder : IRequestBuilder, IDisposable
    {
        private readonly RestClient client;
        private RestRequest request;

        public RequestBuilder()
        {
            client = new RestClient();
            request = new RestRequest();
            Logger.LogInfo("RequestBuilder created.");
        }

        public IRequestBuilder WithUrl(string url)
        {
            request.Resource = url;
            Logger.LogInfo($"With Url {url}.");
            return this;
        }

        public IRequestBuilder WithHeader(string key, string value)
        {
            request.AddHeader(key, value);
            Logger.LogInfo($"With Header {key}: {value}.");
            return this;
        }

        public IRequestBuilder WithBody(string body)
        {
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            Logger.LogInfo($"With Body {body}.");
            return this;
        }

        public IRequestBuilder WithPostData<T>(T data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            Logger.LogInfo($"With Post Data {jsonData}.");
            return this;
        }

        public RestResponse SendGet()
        {
            request.Method = Method.Get;
            Logger.LogInfo($"Send Get.");
            return client.Execute(request);
        }

        public RestResponse SendPost()
        {
            request.Method = Method.Post;
            Logger.LogInfo($"Send Post.");
            return client.Execute(request);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
