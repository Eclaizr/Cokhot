using Microsoft.EntityFrameworkCore;

public class IngredientDansPlatsRepository(ApplicationContext context) : IfIngredientDansPlatDataRepository
{
    readonly ApplicationContext _cokhotContext = context;

    public async Task AddAsync(IngredientDansPlat ingredientDansPlat)
    {
        _cokhotContext.IngredientsDansPlat.Add(ingredientDansPlat);
        await _cokhotContext.SaveChangesAsync();
    }

    public async Task<IngredientDansPlat?> GetAsync(int idPlat, int idIngredient) => await _cokhotContext.IngredientsDansPlat.FindAsync(idPlat, idIngredient);

    public async Task UpdateAsync(IngredientDansPlat ingredientDansPlatToUpdate, IngredientDansPlat ingredientDansPlat)
    {
        ingredientDansPlatToUpdate.QuantiteIngredient = ingredientDansPlat.QuantiteIngredient;


        await _cokhotContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(IngredientDansPlat ingredientDansPlat)
    {
        _cokhotContext.Remove(ingredientDansPlat);
        await _cokhotContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<IngredientDansPlat>> GetAllAsync()
    {
        return await _cokhotContext.IngredientsDansPlat.ToListAsync<IngredientDansPlat>();
    }
}