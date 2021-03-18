﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace webAPI
{
    public partial class SentimentModel
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
                        var pipeline = mlContext.Transforms.Conversion.MapValueToKey(@"Sentiment", @"Sentiment")                  
                                        .Append(mlContext.Transforms.Text.FeaturizeText(@"Comment_tf", @"Comment"))                  
                                        .Append(mlContext.Transforms.CopyColumns(@"Features", @"Comment_tf"))                  
                                        .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))                  
                                        .Append(mlContext.BinaryClassification.Trainers.AveragedPerceptron(labelColumnName:@"Sentiment"))                  
                                        .Append(mlContext.Transforms.Conversion.MapKeyToValue(@"PredictedLabel", @"PredictedLabel"))            ;

            return pipeline;
        }
    }
}
