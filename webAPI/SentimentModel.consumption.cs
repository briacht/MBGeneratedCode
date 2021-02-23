// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML.Data;
using Microsoft.Extensions.ML;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.ML;
using System.IO;

namespace MBGeneratedCode

{
    public partial class SentimentModel
    {
        /// <summary>
        /// model input class for SentimentModel.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"Comment")]
            public string Comment { get; set; }

            [ColumnName(@"Sentiment")]
            public string Sentiment { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for SentimentModel.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName("PredictedLabel")]
            public string Prediction { get; set; }

            public float[] Score { get; set; }
        }

        #endregion

        private const string DefaultModelPath = "SentimentModel.zip";
        private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine;
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        public SentimentModel(string modelPath = DefaultModelPath)
        {
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            var fullModelPath = Path.GetFullPath(modelPath);
            ITransformer mlModel = mlContext.Model.Load(fullModelPath, out var modelInputSchema);
            var predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            this._predictionEngine = predictionEngine;
        }

        public SentimentModel(PredictionEngine<SentimentModel.ModelInput, SentimentModel.ModelOutput> predictionEngine)
        {
            this._predictionEngine = predictionEngine;
        }

        public SentimentModel(PredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput> predictionEnginePool)
        {
            this._predictionEnginePool = predictionEnginePool;
        }

        public ModelOutput Predict(ModelInput input)
        {
            if (this._predictionEngine != null)
            {
                return this._predictionEngine.Predict(input);
            }
            else
            {
                return this._predictionEnginePool.Predict(input);
            }
        }

        public static void RegisterModel(IServiceCollection services, string modelPath = DefaultModelPath)
        {
            var fullModelPath = Path.GetFullPath(modelPath);
            services.AddPredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput>()
                .FromFile(fullModelPath);
            services.AddSingleton<SentimentModel>();
        }
    }
}
