using Common;
using DisputeRecSystem.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DisputeRecSystem.Services
{
    public class DisputeRecSystemService : IDisputeRecSystemService
    {

        /// <summary>
        /// Paths, to call APIs, shall be defined in the separate config
        /// </summary>
        readonly string _dbServicePath = "https://localhost:7249/api/dataservice/v1/disputes";
        readonly string _fileServicePath = "https://localhost:7036/fileImport/api/v1/file";

        private readonly HttpClient _httpClient;

        public DisputeRecSystemService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

        }


        public async Task<IEnumerable<DisputeDTO>> GetDisputes()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_dbServicePath);
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();

                var disputes = await JsonSerializer.DeserializeAsync<IEnumerable<DisputeDTO>>(
                    stream,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return disputes ?? Enumerable.Empty<DisputeDTO>();
            }

            return Enumerable.Empty<DisputeDTO>();
        }

        public async Task<bool> ImportDisputes(string path)
        {
            //Create request for File service
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            var requestUrl = _fileServicePath + $"?path={Uri.EscapeDataString(path)}";

            //Get data from file service as a JSON
            var response = await _httpClient.PostAsync(requestUrl, null);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            //Push data into DB
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var dataServiceResponse = await _httpClient.PostAsync(_dbServicePath, content);

            
            return dataServiceResponse.IsSuccessStatusCode;
        }




    }
}
