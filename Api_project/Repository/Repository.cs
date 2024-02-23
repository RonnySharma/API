using Api_project.Repository.IRepository;
using Newtonsoft.Json;
using System.Text;

namespace Api_project.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Repository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    
        public async Task<bool> CreateAsync(string url, T objToCreate)
        {

            var req = new HttpRequestMessage(HttpMethod.Post, url);
            if (objToCreate != null)
            {
                req.Content = new StringContent(JsonConvert.SerializeObject(objToCreate), Encoding.UTF8, "application/json");
            }
            var cls = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await cls.SendAsync(req);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return true;

            else
                return false;
        }

        public async Task<bool> DeleteAsync(string url, int id)
        {
            var req = new HttpRequestMessage(HttpMethod.Delete, url + id.ToString());
            var cls = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await cls.SendAsync(req);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url);

            var cls = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await cls.SendAsync(req);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jso = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jso);
            }

            return null;
        }

        public async Task<T> GetAsync(string url, int id)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, url + id.ToString());
            var cls = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await cls.SendAsync(req);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jso = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jso);
            }

            return null;
        }

        public async Task<bool> updateAsync(string url, T objToupdate)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, url);
            if (objToupdate != null)
            {
                req.Content = new StringContent(JsonConvert.SerializeObject(objToupdate), Encoding.UTF8, "application/json");
            }
            var cls = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await cls.SendAsync(req);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)


                return true;

            else
                return false;
        }
    }
}
