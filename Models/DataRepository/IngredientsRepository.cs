using Microsoft.EntityFrameworkCore;

public class IngredientRepository(ApplicationContext context) : IfIngredientDataRepository
{
    readonly ApplicationContext _cokhotContext = context;

    public async Task AddAsync(Ingredient Ingredient)
    {
        _cokhotContext.Ingredients.Add(Ingredient);
        await _cokhotContext.SaveChangesAsync();
    }

    public async Task<Ingredient?> GetAsync(int id) => await _cokhotContext.Ingredients.FindAsync(id);

    public async Task UpdateAsync(Ingredient ingredientToUpdate, Ingredient ingredient)
    {
        ingredientToUpdate.NomIngredient = ingredient.NomIngredient;
        ingredientToUpdate.PrixKiloIngredient = ingredient.PrixKiloIngredient;

        await _cokhotContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ingredient ingredient)
    {
        _cokhotContext.Remove(ingredient);
        await _cokhotContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Ingredient>> GetAllAsync()
    {
        return await _cokhotContext.Ingredients.ToListAsync<Ingredient>();
    }
}