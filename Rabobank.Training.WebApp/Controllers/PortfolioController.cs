using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rabobank.Training.ClassLibrary.Builders;
using Rabobank.Training.ClassLibrary.ViewModels;

namespace Rabobank.Training.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly IPortfolioBuilder _portfolioBuilder;

        public PortfolioController(ILogger<PortfolioController> logger, IPortfolioBuilder portfolioBuilder)
        {
            _logger = logger;
            _portfolioBuilder = portfolioBuilder;
        }

        [Route("/GetPortfolio")]
        [HttpGet]
        public PortfolioViewModel GetPortfolio()
        {
            try
            {
                return _portfolioBuilder.GetPortfolio();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}