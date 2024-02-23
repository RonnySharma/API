using Api_project.Models;
using Api_project.Repository.IRepository;

namespace Api_project.Repository
{
    public class TrailRep : Repository<Trail>, ITrailRep
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TrailRep(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
