using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("prediction")]
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

        public async Task<ModelOutput> PostPrediction(string comment)
        {
            var response = await _client.PostAsJsonAsync<ModelInput>("/predict", new ModelInput {Comment=comment});
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
                config.BaseAddress = new Uri("http://localhost:5000/");
                config.DefaultRequestHeaders.Add("Accept", "application/json");
                config.DefaultRequestHeaders.Add("User-Agent", "SentimentModel");
            });
        }
    }
}
