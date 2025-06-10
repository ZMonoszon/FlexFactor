using Common;
using FileImport.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileImport.Controllers
{
    /// <summary>
    /// Controller to put the Filedata to the system and 
    /// </summary>
    [ApiController]
    [Route("fileImport/api/v1/file")]
    public class FileImportServiceController : ControllerBase
    {
        private readonly IFileImportService _fileImportService;

        public FileImportServiceController(IFileImportService fileImportService)
        {
            _fileImportService = fileImportService;
        }

        /// <summary>
        /// Get all disputes
        /// </summary>
        /// <returns>Disputes as JSON</returns>
        [HttpPost]
        public IEnumerable<DisputeDTO> PostFile(string path)
        { 
            return _fileImportService.CsvGetDisputeDTOs(path).Result;
        }


    }
}
