using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabobank.Training.ClassLibrary.Builders;
using Rabobank.Training.ClassLibrary.ViewModels;

namespace Rabobank.Training.ClassLibrary.Test
{
    [TestClass]
    public class PortfolioShould
    {
        private readonly PortfolioViewModel _portfolioViewModel;
        private readonly PortfolioBuilder _portfolioBuilder;

        public PortfolioShould()
        {
            _portfolioBuilder = new PortfolioBuilder();
            _portfolioViewModel = _portfolioBuilder.GetPortfolio();
        }


        [TestMethod]
        public void ReturnPositionList()
        {
            _portfolioViewModel.Positions.Should().NotBeNull();
            _portfolioViewModel.Positions.Should().HaveCountGreaterOrEqualTo(1);
        }

        [TestMethod]
        public void HaveMatchedFundOfMandateInstrumentCode()
        {
            _portfolioViewModel.Positions.Should().NotBeNull();
            _portfolioViewModel.Positions.Find(x => x.Mandates.Count > 0).Should().NotBeNull();
        }

        [TestMethod]
        public void HaveLiquidity()
        {
            _portfolioViewModel.Positions.Should().NotBeNull();
            _portfolioViewModel.Positions.Any(x => x.Mandates.Any(y => y.Name == "Liquidity")).Should().BeTrue();
        }
    }
}