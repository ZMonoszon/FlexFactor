using Common;

namespace DataService
{
    /// <summary>
    /// DB-Mock
    /// </summary>
    public static class TempDBData
    {

        public static IEnumerable<DisputeDTO> DBDisputes()
        {

            var internalDisputes = new List<DisputeDTO>
            {
            new DisputeDTO {

                DisputeId = "case_001",
                TransactionId = "txn_001",
                Amount = 100.00m,
                Currency = DisputeCurrency.USD,
                Status = DisputeStatus.Open,
                Reason = DisputeReason.Fraud
               },
            new DisputeDTO {
                DisputeId = "case_002",
                TransactionId = "txn_005",
                Amount = 150.00m,
                Currency = DisputeCurrency.USD,
                Status = DisputeStatus.Lost,
                Reason = DisputeReason.ProductNotReceived
                },
            new DisputeDTO
            {
                DisputeId = "case_004",
                TransactionId = "txn_007",
                Amount = 90.00m,
                Currency = DisputeCurrency.USD,
                Status = DisputeStatus.Open,
                Reason = DisputeReason.Unauthorized
                }
            };

            return internalDisputes;
        }
    }
}
