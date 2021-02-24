using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;

namespace MBGeneratedCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration
            WebHost.CreateDefaultBuilder()
                .ConfigureServices(services => {
                    // Register Prediction Engine Pool and SentimentModel
                    services.AddPredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput>().FromFile("SentimentModel.zip");
                    services.AddSingleton<SentimentModel>(serviceProvider => {
                        var predictionEnginePool = serviceProvider.GetService<PredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput>>();
                        return SentimentModel.Create(predictionEnginePool);
                    });
                })
                .Configure(options => {
                    options.UseRouting();
                    options.UseEndpoints(routes => {
                        // Define prediction endpoint
                        routes.MapPost("/predict", PredictHandler);
                    });
                })
                .Build()
                .Run();
        }

        static async Task PredictHandler(HttpContext http)
        {
            // Get PredictionEnginePool service
            var sentimentModel = http.RequestServices.GetRequiredService<SentimentModel>();

            // Deserialize HTTP request JSON body
            var body = http.Request.Body as Stream;
            var input = await JsonSerializer.DeserializeAsync<SentimentModel.ModelInput>(body);

            // Predict
            var prediction = sentimentModel.Predict(input);

            // Return prediction as response
            await http.Response.WriteAsJsonAsync(prediction);
        }
    }
}
