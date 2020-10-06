using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabobank.Training.ClassLibrary.Builders;

namespace Rabobank.Training.ClassLibrary.Test
{
    [TestClass]
    public class FundOfMandatesShould
    {
        private List<FundOfMandates> _fundOfMandates;
        private readonly PortfolioBuilder _portfolioBuilder;

        public FundOfMandatesShould()
        {
            _portfolioBuilder = new PortfolioBuilder();
            _fundOfMandates = new List<FundOfMandates>();
        }

        [TestMethod]
        public void ReturnFundOfMandatesList()
        {
            var xmlFilePath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath +
                              "\\TestData\\FundsOfMandatesData.xml";
            _fundOfMandates = _portfolioBuilder.ReadFundOfMandatesFile(xmlFilePath);
            _fundOfMandates.Should().NotBeNull();
            _fundOfMandates.Should().HaveCountGreaterOrEqualTo(1);
        }
    }
}