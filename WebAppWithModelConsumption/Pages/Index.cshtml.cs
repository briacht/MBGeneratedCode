using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static WebAppWithModelConsumption.SentimentModel;

namespace WebAppWithModelConsumption.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SentimentModel _sentimentModel;

        [BindProperty]
        public string _comment { get; set; }

        public ModelOutput ModelOutput;
        public bool ShowPrediction { get; set; } = false;

        public IndexModel(ILogger<IndexModel> logger, SentimentModel sentimentModel)
        {
            _logger = logger;
            _sentimentModel = sentimentModel;
        }

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            ModelInput input = new ModelInput
            {
                Comment = _comment
            };
            try
            {
                ModelOutput = _sentimentModel.Predict(input);
                ShowPrediction = true;
            }
            catch (HttpRequestException)
            {
                ModelOutput = new ModelOutput { Prediction = "" };
            }
        }
    }
}
