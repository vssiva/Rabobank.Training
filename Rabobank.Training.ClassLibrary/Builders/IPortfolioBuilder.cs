using Rabobank.Training.ClassLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rabobank.Training.ClassLibrary.Builders
{
    public interface IPortfolioBuilder
    {
        List<FundOfMandates> ReadFundOfMandatesFile(string filePath);
        PortfolioViewModel GetPortfolio();
    }
}
