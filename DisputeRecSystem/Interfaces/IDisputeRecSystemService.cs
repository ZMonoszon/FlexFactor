using Common;
using Microsoft.AspNetCore.Mvc;

namespace DisputeRecSystem.Interfaces
{
    public interface IDisputeRecSystemService
    {
        /// <summary>
        /// Get all disputes from the DB, shall contain a filter
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<DisputeDTO>> GetDisputes();


        /// <summary>
        /// Put disputes from the file
        /// </summary>
        /// <param name="path"></param>
        /// <returns>success, error</returns>
        public Task<bool> ImportDisputes(string path);
    }
}
