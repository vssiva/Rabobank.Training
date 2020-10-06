using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using Rabobank.Training.ClassLibrary.Helpers;
using Rabobank.Training.ClassLibrary.ViewModels;

namespace Rabobank.Training.ClassLibrary.Builders
{
    public class PortfolioBuilder : IPortfolioBuilder
    {
        public List<FundOfMandates> ReadFundOfMandatesFile(string xmlFilePath)
        {
            XmlSchemaValidation(xmlFilePath);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            var result = XmlDeserializationHelper.Deserialize<FundsOfMandatesData>(xmlDoc.InnerXml);
            return result.FundsOfMandates.ToList();
        }

        public PortfolioViewModel GetPortfolio()
        {
            var portfolioViewModel = new PortfolioViewModel();
            var fundOfMandates = ReadFundOfMandatesFile(GetFundsOfMandatesDataXmlPath());
            portfolioViewModel.Positions.AddRange(SetupPositions());
            portfolioViewModel.Positions.ForEach(x => GetCalculatedMandates(x, fundOfMandates));

            return portfolioViewModel;
        }

        private void GetCalculatedMandates(PositionViewModel positionViewModel, List<FundOfMandates> fundOfMandates)
        {
            var list = fundOfMandates.Where(x => x.InstrumentCode == positionViewModel.Code).ToList();
            foreach (var item in list)
            {
                list.ForEach(y => y.Mandates.ToList()
                    .ForEach(z => positionViewModel.Mandates.Add(new MandateViewModel
                    {
                        Name = z.MandateName,
                        Allocation = z.Allocation,
                        Value = CalculateMandateValue(positionViewModel.Value, z.Allocation)
                    })));
                if (item.LiquidityAllocation > 0)
                    positionViewModel.Mandates.Add(new MandateViewModel
                    {
                        Name = "Liquidity",
                        Allocation = item.LiquidityAllocation,
                        Value = CalculateMandateValue(positionViewModel.Value, item.LiquidityAllocation)
                    });
            }
        }

        private decimal CalculateMandateValue(decimal positionValue, decimal madateAllocation)
        {
            return Math.Round(positionValue * madateAllocation / 100);
        }

        private List<PositionViewModel> SetupPositions()
        {
            var positionViewModels = new List<PositionViewModel>();
            positionViewModels.Add(new PositionViewModel {Code = "NL0000009165", Name = "Heineken", Value = 12345});
            positionViewModels.Add(new PositionViewModel
                {Code = "NL0000287100", Name = "Optimix Mix Fund", Value = 23456});
            positionViewModels.Add(new PositionViewModel
                {Code = "LU0035601805", Name = "DP Global Strategy L High", Value = 34567});
            positionViewModels.Add(new PositionViewModel
                {Code = "NL0000292332", Name = "Rabobank Core Aandelen Fonds T2", Value = 45678});
            positionViewModels.Add(new PositionViewModel
                {Code = "LU0042381250", Name = "Morgan Stanley Invest US Gr Fnd", Value = 56789});
            return positionViewModels;
        }

        private void XmlSchemaValidation(string filePath)
        {
            var xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add("http://amt.rnss.rabobank.nl/", GetSchemaPath());
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            xmlReaderSettings.ValidationEventHandler += ValidationEventHandler;
            var reader = XmlReader.Create(filePath, xmlReaderSettings);
            reader.Read();
        }

        private string GetSchemaPath()
        {
            return new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath +
                   "\\Schemas\\FundsOfMandatesData.xsd";
        }

        private string GetFundsOfMandatesDataXmlPath()
        {
            return new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath +
                   "\\Schemas\\FundsOfMandatesData.xml";
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}