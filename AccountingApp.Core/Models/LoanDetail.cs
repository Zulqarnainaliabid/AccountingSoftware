using System;

namespace AccountingApp.Core.Models
{
    public class LoanDetail
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int LoanTakerId { get; set; }
        public LoanTaker LoanTaker { get; set; }
    }
    public enum Status 
    {
        Receivable,
        Payable
    }
}