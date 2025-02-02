﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace AzureFunctionsApp
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
            var pipeline = mlContext.Transforms.Text.FeaturizeText(@"Comment", @"Comment")      
                                    .Append(mlContext.Transforms.Concatenate(@"$_FEATURES", @"Comment"))      
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"$_FEATURES", @"$_FEATURES"))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"Sentiment", @"Sentiment"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy(historySize:88,l1Regularization:4.53754334983703F,l2Regularization:3.82157502773772F,optimizationTolerance:9.60713462533089E-07F,labelColumnName:@"Sentiment",featureColumnName:@"$_FEATURES"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(@"PredictedLabel", @"PredictedLabel"));

            return pipeline;
        }
    }
}
