using Newtonsoft.Json;

namespace GitLabApi.Models
{
    public class User
    {
        public enum UserState
        {
            [JsonProperty("active")]
            Active,
            [JsonProperty("blocked")]
            Blocked
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public UserState State { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }
    }
}
