using Api.Interface;
using Api.Model;

using Newtonsoft.Json;

using Refit;

namespace Api
{
    public class ApiService
    {
        private readonly IOpenAI _userApi;

        private string bearer = $"Bearer %Enter your token%";
        private string ruSetPromt = "Переведи текст c Английского на Русский языки красиво его оформи размеи для MS WORDS c отступами, курсивами, что бы в файле красивор смотрелось. Отвечай мне Только переведенным текстом  без своих комментариев. Вот текст для перевода : ";

        public ApiService()
        {
            _userApi = RestService.For<IOpenAI>("https://api.openai.com");
        }

        public async Task<MessageResponse> SendAsync(string promt)
        {
            await Task.Delay(30000);

            var request = new MessageRequest()
            {
                Model = "gpt-4o-mini",
                Messages = new List<Message>
                {
                   new Message()
                   {
                       Role = "user",
                       Content = ruSetPromt+ "\n" + promt
                   }
                }
            };
            var json = JsonConvert.SerializeObject(request);

            var result = await _userApi.SendMessage(bearer, "application/json", json);

            return JsonConvert.DeserializeObject<MessageResponse>(result);
        }
    }
}