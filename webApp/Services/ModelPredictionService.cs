using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace webApp.Services
{
    public class ModelInput
    {
        public string Comment { get; set; }
        public string Sentiment { get; set; }
    }

    public class ModelOutput
    {
        public string Prediction { get; set; }
        public float[] Score { get; set; }
    }

    public class SentimentModelAPIService
    {
        private readonly HttpClient _client;

        public SentimentModelAPIService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ModelOutput> PostPrediction(ModelInput input)
        {
            var response = await _client.PostAsJsonAsync<ModelInput>("/predict", input);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ModelOutput>(responseStream);
        }
    }
    public static class SentimentModelExtensions
    {
        public static void AddSentimentModelAPI(this IServiceCollection services)
        {
            services.AddHttpClient<SentimentModelAPIService>(config =>
            {
                config.BaseAddress = new Uri("https://localhost:44349/");
                config.DefaultRequestHeaders.Add("Accept", "application/json");
                config.DefaultRequestHeaders.Add("User-Agent", "SentimentModel");
            });
        }
    }
}
