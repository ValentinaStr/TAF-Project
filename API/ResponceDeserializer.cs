using Core.Utilits;
using Newtonsoft.Json;
using RestSharp;

namespace API
{
    public static class ResponceDeserializer
    {
        public static T? DeserializeResponse<T>(RestResponse response)
        {
            try
            {
                if (response == null)
                {
                    Logger.LogInfo("Response is null.");
                    throw new ArgumentNullException(nameof(response), "Response is null.");
                }

                if (response.Content == null)
                {
                    Logger.LogInfo("Response content is null.");
                    throw new ArgumentNullException(nameof(response.Content), "Response content is null.");
                }

                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                Logger.LogInfo($"{ex}");
                throw;
            }
        }
    }
}
