using Common;
using DisputeRecSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DisputeRecSystem.Controllers
{
    [ApiController]
    [Route("disputeRecSystem/api/v1/disputes")]
    public class DisputeRecSystemController : ControllerBase
    {

        /// <summary>
        /// Disputes process orchestrator
        /// </summary>
        private readonly IDisputeRecSystemService _disputeRecSystemService;

        public DisputeRecSystemController(IDisputeRecSystemService disputeRecSystemService)
        {
            _disputeRecSystemService = disputeRecSystemService;
        }

        /// <summary>
        /// Put disputes from file to DB
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(string path)
        {
            try
            {
                var result = _disputeRecSystemService.ImportDisputes(path);
                return Ok(result);
            }
            catch (FileNotFoundException ex)
            {
                Trace.WriteLine(ex);
                return NotFound(ex.Message); // HTTP 404
            }
            catch (UnauthorizedAccessException ex)
            {
                Trace.WriteLine(ex);
                return StatusCode(403, ex.Message); // HTTP 403
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return StatusCode(500, "An unexpected error occurred: " + ex.Message); // HTTP 500
            }


        }

        /// <summary>
        /// Get all disputes from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DisputeDTO> Get()
        {
            return _disputeRecSystemService.GetDisputes().Result;
        }
    }
}
