using AccountingApp.Api.Resources;

namespace AccountingApp.Api.Resources
{
    public class SaveLoanDetailResource
    {
        public string Amount { get; set; }
        public int LoanTakerId { get; set; }
        public Status Status { get; set; }
    }
}