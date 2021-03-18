// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace webAPI
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

        private static string MLNetModelPath = Path.GetFullPath("SentimentModel.zip");

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>. You can use <see cref="GetSampleData"/> to create a sample <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            ModelOutput result = predEngine.Predict(input);
            return result;
        }

        /// <summary>
        /// Take the first row as sample data and return as <see cref="ModelInput"/>. The return result can be used by <see cref="Predict(ModelInput)"/> directly.
        /// </summary>
        /// <returns><see cref="ModelInput"/>.</returns>
        public static ModelInput GetSampleData()
        {
            ModelInput sampleData = new ModelInput()
            {
                Comment = @"Wow... Loved this place.",
                Sentiment = @"positive",
            };

            return sampleData;
        }
    }
}
