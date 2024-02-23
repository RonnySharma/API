namespace Api_project.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string url, int id);
        Task<IEnumerable<T>> GetAllAsync(string url);
        Task<bool> CreateAsync(string url, T objToCreate);
        Task<bool> updateAsync(string url, T objToupdate);
        Task<bool> DeleteAsync(string url, int id);
    }
}
