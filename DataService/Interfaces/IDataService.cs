using Common;
using Microsoft.AspNetCore.Mvc;


namespace DataService.Interfaces
{
    /// <summary>
    /// Interface to read and write the dat into DB (in current implementation 1 interface, for better scaling has to be splitted into 2 separate MSs)
    /// </summary>
    public interface IDataService
    {
        public IEnumerable<DisputeDTO> GetDisputeDTOs();
        public bool ImportData(IEnumerable<DisputeDTO> disputeDTOs);

    }
}
