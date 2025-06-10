using Common;

namespace FileImport.Interfaces
{
    public interface IFileImportService
    {
        public Task<IEnumerable<DisputeDTO>> CsvGetDisputeDTOs(string path);
    }
}
