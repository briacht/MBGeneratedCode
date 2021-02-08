using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using webApp.Services;

namespace webApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SentimentModelAPIService _sentimentModelService;

        [BindProperty]
        public string Comment { get; set; }

        public ModelOutput ModelOutput;
        public bool ShowPrediction { get; set; } = false;

        public IndexModel(
            ILogger<IndexModel> logger,
            SentimentModelAPIService sentimentModelService)
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
            catch(HttpRequestException)
            {
                ModelOutput = new ModelOutput { Prediction = "" };
            }
        }
    }
}
