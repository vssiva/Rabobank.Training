using System.Collections.Generic;

namespace Rabobank.Training.ClassLibrary.ViewModels
{
    public class PositionViewModel
    {
        public PositionViewModel()
        {
            Mandates = new List<MandateViewModel>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }


        public List<MandateViewModel> Mandates { get; set; }
    }
}