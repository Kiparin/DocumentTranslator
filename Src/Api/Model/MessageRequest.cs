using Newtonsoft.Json;

namespace Api.Model
{
    public class MessageRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }
    }
}