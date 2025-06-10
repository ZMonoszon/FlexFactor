using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum DisputeCurrency { USD, EUR, NIS}
    public enum DisputeStatus { Open, Lost, Won }
    public enum DisputeReason {Fraud, ProductNotReceived, Unauthorized, Duplicate }

    public class DisputeDTO
    {
        public string DisputeId { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DisputeCurrency  Currency{ get; set; }
        public DisputeStatus Status { get; set; }
        public DisputeReason Reason { get; set; }
    }
}
