using System;

namespace AccountingApp.Api.Resources
{
    public class SaveLoanTakerResource
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ImagePath { get; set; }
        public DateTime LoanTakerDetail { get; set; }
    }
}