using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tietokannat_hyödyntäminen_1.Models
{
    internal class Loan
    {
        public int BookId { get; set; }
        public int LoanId { get; set; }
        public int MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        
        public DateTime ReturnDate { get; set; }

    }
}
