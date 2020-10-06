using System.Collections.Generic;

namespace Rabobank.Training.ClassLibrary.ViewModels
{
    public class PortfolioViewModel
    {
        public PortfolioViewModel()
        {
            Positions = new List<PositionViewModel>();
        }

        public List<PositionViewModel> Positions { get; set; }
    }
}