using Common;
using FileImport.Interfaces;

namespace FileImport.Services
{
    public class FIleImportService : IFileImportService
    {
        public async Task<IEnumerable<DisputeDTO>> CsvGetDisputeDTOs(string path)
        {
            var result = new List<DisputeDTO>();

            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (line != null)
                {
            
                    var dto = CsvConverter.ConvertCsvLineToDispute(line);
                    if (dto != null)
                        result.Add(dto);
                }
            }
            return result;
        }
    }
}
