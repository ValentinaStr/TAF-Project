using RestSharp;

namespace API
{
    public interface IRequestBuilder
    {
        IRequestBuilder WithUrl(string url);
        IRequestBuilder WithHeader(string key, string value);
        IRequestBuilder WithBody(string body);
        IRequestBuilder WithPostData<T>(T data);
        RestResponse SendGet();
        RestResponse SendPost();
    }
}