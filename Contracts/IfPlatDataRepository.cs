public interface IfPlatDataRepository
{
    Task<IEnumerable<Plat>> GetAllAsync();
    Task<Plat?> GetAsync(int id);
    Task AddAsync(Plat entity);
    Task UpdateAsync(Plat entityToUpdate, Plat entity);
    Task DeleteAsync(Plat entity);
}