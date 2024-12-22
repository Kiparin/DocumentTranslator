using Refit;

namespace Api.Interface
{
    public interface IOpenAI
    {
        [Post("/v1/chat/completions")]
        Task<string> SendMessage(
            [Header("Authorization")] string authorization,
            [Header("Content-Type")] string contentType,
            [Body] string json);
    }
}