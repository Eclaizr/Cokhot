using Microsoft.EntityFrameworkCore;

public class PlatsRepository(ApplicationContext context) : IfPlatDataRepository
{
    readonly ApplicationContext _cokhotContext = context;

    public async Task AddAsync(Plat plat)
    {
        _cokhotContext.Plats.Add(plat);
        await _cokhotContext.SaveChangesAsync();
    }

    public async Task<Plat?> GetAsync(int id) => await _cokhotContext.Plats.FindAsync(id);

    public async Task UpdateAsync(Plat platToUpdate, Plat plat)
    {
        platToUpdate.NomPlat = plat.NomPlat;
        platToUpdate.SaveurPlat = plat.SaveurPlat;
        platToUpdate.EstEpicePlat = plat.EstEpicePlat;
        platToUpdate.EstHealthy = plat.EstHealthy;
        platToUpdate.EstVegetarien = plat.EstVegetarien;
        platToUpdate.OriginePlat = plat.OriginePlat;
        platToUpdate.TempsPreparationPlat = plat.TempsPreparationPlat;
        platToUpdate.RepasPlat = plat.RepasPlat;
        platToUpdate.LienRecettePlat = plat.LienRecettePlat;
        platToUpdate.LienPhotoPlat = plat.LienPhotoPlat;
        platToUpdate.NotePlat = plat.NotePlat;
    
        await _cokhotContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Plat plat)
    {
        _cokhotContext.Remove(plat);
        await _cokhotContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Plat>> GetAllAsync()
    {
        return await _cokhotContext.Plats.ToListAsync<Plat>();
    }
}