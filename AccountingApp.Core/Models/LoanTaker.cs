using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AccountingApp.Core.Models
{
    public class LoanTaker
    {
        public LoanTaker()
        {
            LoanDetails = new Collection<LoanDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }    
        public ICollection<LoanDetail> LoanDetails { get; set; }
    }
}