﻿using Api.Model;

using Refit;

namespace Api.Interface
{
    public interface IOpenRouterAIApi
    {

        [Post("/api/v1/chat/completions")]
        Task<string> SendMessage(
            [Header("Authorization")] string authorization,
            [Header("Content-Type")] string contentType,
            [Body] string json);
    }
}
