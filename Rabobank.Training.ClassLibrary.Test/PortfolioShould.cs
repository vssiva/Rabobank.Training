using FluentAssertions;
using NUnit.Framework;
using Rabobank.Training.ClassLibrary.Builders;
using System.IO;
using System;
using System.Collections.Generic;
using Rabobank.Training.ClassLibrary.ViewModels;
using System.Linq;

namespace Rabobank.Training.ClassLibrary.Test
{
    public class PortfolioShould
    {
        private PortfolioBuilder _FundOfMandatesBuilder;
        private PortfolioViewModel _PortfolioViewModel;

        [SetUp]
        public void Setup()
        {
            _FundOfMandatesBuilder = new PortfolioBuilder();
            _PortfolioViewModel = _FundOfMandatesBuilder.GetPortfolio();
        }

        [Test]
        public void ReturnPositionList()
        {
            _PortfolioViewModel.Positions.Should().NotBeNull();
            _PortfolioViewModel.Positions.Should().HaveCountGreaterOrEqualTo(1);
        }
        [Test]
        public void HaveMatchedFundOfMandateInstrumentCode()
        {
            _PortfolioViewModel.Positions.Should().NotBeNull();
            _PortfolioViewModel.Positions.Find(x => x.Mandates.Count > 0).Should().NotBeNull();
        }
        [Test]
        public void HaveLiquidity()
        {
            _PortfolioViewModel.Positions.Should().NotBeNull();
            _PortfolioViewModel.Positions.Any(x => x.Mandates.Any(y => y.Name == "Liquidity")).Should().BeTrue();
        }
    }
}
