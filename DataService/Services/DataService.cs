using Common;
using DataService.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using DataService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;


namespace DataServices.Services
{
    public class DataService : IDataService
    {
        /// <summary>
        /// Key to get/set data to memory cache
        /// </summary>
        private readonly string disputeDTOKey = "disputes";
        /// <summary>
        /// DB simulation, memory cache
        /// </summary>
        private readonly IMemoryCache _cache;

        public DataService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            ImportData(TempDBData.DBDisputes().ToList());
        }

        /// <summary>
        /// Getting full DB content (for tests)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DisputeDTO> GetDisputeDTOs()
        {
            if (_cache.TryGetValue(disputeDTOKey, out IEnumerable<DisputeDTO> disputeDTOs))
            {
                return disputeDTOs;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Import Data to DB, duplication check
        /// </summary>
        /// <param name="disputeDTOs"></param>
        /// <returns>Succesful imported / Not successful imported</returns>
        public bool ImportData(IEnumerable<DisputeDTO> disputeDTOs)
        {
            try
            {
                //Get data from DB
                if (!_cache.TryGetValue(disputeDTOKey, out List<DisputeDTO> existingDisputes))
                {
                    existingDisputes = new List<DisputeDTO>();
                }

                //Merge data based on transaction ID
                var merged = existingDisputes
                    .Concat(disputeDTOs)
                    .GroupBy(d => d.TransactionId)
                    .Select(g => g.First())
                    .ToList();

                _cache.Set(disputeDTOKey, merged);

                return true;
            }
            catch (Exception ex) {
                Trace.WriteLine(ex);
                return false;

            }
        }

        
    }        
    
}
