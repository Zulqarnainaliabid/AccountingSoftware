namespace AccountingApp.Api.Resources
{
    public class LoanDetailResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LoanTakerResource LoanTaker { get; set; }
    }
}