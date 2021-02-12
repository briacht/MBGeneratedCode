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
        private readonly SentimentModelService _sentimentModelService;

        [BindProperty]
        public string Comment { get; set; }

        public ModelOutput ModelOutput;
        public bool ShowPrediction { get; set; } = false;

        public IndexModel(ILogger<IndexModel> logger, SentimentModelService sentimentModelService)
        {
            _logger = logger;
            _sentimentModelService = sentimentModelService;
        }

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            try
            {
                ModelOutput = await _sentimentModelService.PostPrediction(Comment);
                ShowPrediction = true;
            }
            catch (HttpRequestException)
            {
                ModelOutput = new ModelOutput { Prediction = "" };
            }
        }
    }
}
