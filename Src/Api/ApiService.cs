using Api.Interface;
using Api.Model;

using Newtonsoft.Json;

using Refit;

namespace Api
{
    public class ApiService
    {
        private readonly IOpenRouterAIApi _userApi;

        private string bearer = $"Bearer %Enter your token%";

        public ApiService()
        {
            _userApi = RestService.For<IOpenRouterAIApi>("https://openrouter.ai");

            var result = SendAsync("Переведи текст который я буду тебе присылать и красиво его оформи для MS WORDS формата .docx. Только переведенный текст"); // test
        }

        public async Task<MessageResponse> SendAsync(string promt)
        {
            var request = new MessageRequest()
            {
                Model = "openai/gpt-3.5-turbo",
                Messages = new List<Message>
                {
                   new Message()
                   { 
                       Role = "user",
                       Content = promt
                   }
                }
            };

            var json = JsonConvert.SerializeObject(request);

            var result = await _userApi.SendMessage(bearer, "application/json", json);

            return JsonConvert.DeserializeObject<MessageResponse>(result);
        }
    }
}
