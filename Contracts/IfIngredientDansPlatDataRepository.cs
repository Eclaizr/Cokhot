public interface IfIngredientDansPlatDataRepository
{
    Task<IEnumerable<IngredientDansPlat>> GetAllAsync();
    Task<IngredientDansPlat?> GetAsync(int idPlat, int idIngredient);
    Task AddAsync(IngredientDansPlat entity);
    Task UpdateAsync(IngredientDansPlat entityToUpdate, IngredientDansPlat entity);
    Task DeleteAsync(IngredientDansPlat entity);
}