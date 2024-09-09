using Newtonsoft.Json;

namespace API.Model.RequestModels
{
    public class UserRequestModel
    {
        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("Username")]
        public string? Username { get; set; }

        public UserRequestModel(string name, string username)
        {
            Name = name;
            Username = username;
        }
    }
}
