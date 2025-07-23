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
        platToUpdate.nomPlat = plat.nomPlat;
        platToUpdate.saveurPlat = plat.saveurPlat;
        platToUpdate.estEpicePlat = plat.estEpicePlat;
        platToUpdate.estHealthy = plat.estHealthy;
        platToUpdate.estVegetarien = plat.estVegetarien;
        platToUpdate.originePlat = plat.originePlat;
        platToUpdate.tempsPreparationPlat = plat.tempsPreparationPlat;
        platToUpdate.repasPlat = plat.repasPlat;
        platToUpdate.lienRecettePlat = plat.lienRecettePlat;
        platToUpdate.lienPhotoPlat = plat.lienPhotoPlat;
        platToUpdate.notePlat = plat.notePlat;
    
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