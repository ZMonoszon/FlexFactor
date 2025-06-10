using Common;
using System.Diagnostics;

namespace FileImport.Services
{
    public static class CsvConverter
    {
        public static DisputeDTO ConvertCsvLineToDispute(string line)
        {
            var parts = line.Split(',');
            try

            {
                var result = new DisputeDTO
                {
                    DisputeId = parts[0],
                    TransactionId = parts[1],
                    Amount = decimal.Parse(parts[2]),
                    Currency = Enum.Parse<DisputeCurrency>(parts[3]),
                    Status = Enum.Parse<DisputeStatus>(parts[4]),
                    Reason = Enum.Parse<DisputeReason>(parts[5].Replace(" ", ""))
                };

                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return null;
            }
        }
    }
}
