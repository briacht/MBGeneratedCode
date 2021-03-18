using System;
using System.IO;
using AzureFunctionsApp;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;


[assembly: FunctionsStartup(typeof(Startup))]
namespace AzureFunctionsApp
{
    public class Startup : FunctionsStartup
    {

        private readonly string _environment;
        private readonly string _modelPath;

        public Startup()
        {
            _environment = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT");

            if (_environment == "Development")
            {
                _modelPath = "SentimentModel.zip";
            }
            else
            {
                string deploymentPath = @"D:\home\site\wwwroot\";
                _modelPath = Path.Combine(deploymentPath, "SentimentModel.zip");
            }
        }

        public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.AddPredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput>()
                    .FromFile(modelName: "SentimentAnalysisModel", filePath: _modelPath, watchForChanges: true);
            }
    }

    
}
