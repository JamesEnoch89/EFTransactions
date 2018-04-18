using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTransactions
{
    class BankTranscation
    {
        public int ID { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Action { get; set; }
        public string AccountNumber { get; set; }
        public decimal? AmountChanged { get; set; }
        public decimal? NewAmount { get; set; }
    }
}

