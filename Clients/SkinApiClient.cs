using System.Net.Http;
using System.Threading.Tasks;

namespace SkinApi.Gui.Clients
{
    public class SkinApiClient : ISkinApiClient
    {
        private readonly HttpClient _httpClient;

        public SkinApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CompanyRecord>> GetCompaniesAsync()
        {
            var result =  await _httpClient.GetAsync("/Company");
            return await result.Content.ReadFromJsonAsync<IEnumerable<CompanyRecord>>() ?? throw new InvalidOperationException();
        }
    }
}