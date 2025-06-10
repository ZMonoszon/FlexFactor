using Common;
using DataService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace DataService.Controller
{
    [Route("api/[controller]/v1/disputes")]
    [ApiController]
    public class DataServiceController: ControllerBase
    {

        private readonly IDataService _dataService;

        public DataServiceController(IDataService dataService)
        {
            _dataService = dataService;
        }


        /// <summary>
        /// Get all disputes
        /// </summary>
        /// <returns>Disputes as JSON</returns>
        [HttpGet]
        public IEnumerable<DisputeDTO> Get()
        {
            return _dataService.GetDisputeDTOs();
        }

        [HttpPost]
        public IActionResult Post(IEnumerable<DisputeDTO> disputes)
        {
            try
            {

                _dataService.ImportData(disputes);
                return Ok();
                    }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return StatusCode(500, "An error occurred during import.");

            }
        }
    }
}

