public interface IfIngredientDataRepository
{
    Task<IEnumerable<Ingredient>> GetAllAsync();
    Task<Ingredient?> GetAsync(int id);
    Task AddAsync(Ingredient entity);
    Task UpdateAsync(Ingredient entityToUpdate, Ingredient entity);
    Task DeleteAsync(Ingredient entity);
}