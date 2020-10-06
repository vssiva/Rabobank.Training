using FluentAssertions;
using NUnit.Framework;
using Rabobank.Training.ClassLibrary.Builders;
using System.IO;
using System;
using System.Collections.Generic;

namespace Rabobank.Training.ClassLibrary.Test
{
    public class FundOfMandatesShould
    {
        private PortfolioBuilder fundOfMandatesBuilder;
        private List<FundOfMandates> fundOfMandates;

        [SetUp]
        public void Setup()
        {
            fundOfMandatesBuilder = new PortfolioBuilder();
            fundOfMandates = new List<FundOfMandates>();
        }

        [Test]
        public void ReturnFundOfMandatesList()
        {
            var xmlFilePath = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath + "\\TestData\\FundsOfMandatesData.xml";
            fundOfMandates = fundOfMandatesBuilder.ReadFundOfMandatesFile(xmlFilePath);
            fundOfMandates.Should().NotBeNull();
            fundOfMandates.Should().HaveCountGreaterOrEqualTo(1);
        }
    }
}
