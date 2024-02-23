using Api_project.Models;
using Api_project.Repository.IRepository;

namespace Api_project.Repository
{
    public class NationalParkRep:Repository<NationalPark>,INationalPark
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NationalParkRep(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
