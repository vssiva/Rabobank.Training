using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Rabobank.Training.ClassLibrary.Builders;
using Rabobank.Training.ClassLibrary.ViewModels;
using Rabobank.Training.WebApp.Controllers;
using System.Collections.Generic;

namespace Rabobank.Training.WebApp.Tests
{
    [TestClass]
    public class PortfolioControllerShould
    {
        private readonly PortfolioController _PortfolioController;
        private readonly IPortfolioBuilder _PortfolioBuilder = Substitute.For<IPortfolioBuilder>();
        private readonly ILogger<PortfolioController> _Logger = Substitute.For<ILogger<PortfolioController>>();
        private PortfolioViewModel _PortfolioViewModel;
        public PortfolioControllerShould()
        {
            _PortfolioController = new PortfolioController(_Logger, _PortfolioBuilder);
            _PortfolioViewModel = new PortfolioViewModel();
            MockSetup();
        }

        [TestMethod]
        public void ReturnPortfolio()
        {
            _PortfolioController.GetPortfolio().Returns(_PortfolioViewModel);
            var portfolio = _PortfolioController.GetPortfolio();
            portfolio.Positions.Should().HaveCountGreaterOrEqualTo(1);
        }
        private void MockSetup()
        {
            var mandatesViewModel = new List<MandateViewModel>();
            mandatesViewModel.Add(new MandateViewModel { Name = "Robeco Factor Momentum Mandaat", Allocation = 38, Value = 2000 });
            mandatesViewModel.Add(new MandateViewModel { Name = "BNPP Factor Value Mandaa", Allocation = 36, Value = 1666 });

            var positionsViewModel = new List<PositionViewModel>();
            positionsViewModel.Add(new PositionViewModel { Code = "NL0000009165", Name = "Heineken", Mandates = mandatesViewModel, Value = 12345 });
            positionsViewModel.Add(new PositionViewModel { Code = "LU0035601805", Name = "DP Global Strategy L High", Value = 34567 });

            _PortfolioViewModel.Positions = positionsViewModel;
        }
    }
}
