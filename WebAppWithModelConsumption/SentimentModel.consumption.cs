// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML.Data;
using Microsoft.Extensions.ML;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace WebAppWithModelConsumption

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

        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predEngine;

        public SentimentModel(PredictionEnginePool<ModelInput, ModelOutput> predEngine)
        {
            _predEngine = predEngine;
        }

        public ModelOutput Predict(ModelInput input)
        {
            return _predEngine.Predict(input);
        }


    }
    
    public static class SentimentModelExtensions
    {
        public static void AddSentimentModel(this IServiceCollection services)
        {
            services.AddPredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput>()
                .FromFile("SentimentModel.zip");
            services.AddSingleton<SentimentModel>();
        }
    }
}
