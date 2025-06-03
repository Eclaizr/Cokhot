using Microsoft.EntityFrameworkCore;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Plat> Plats { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientDansPlat> IngredientsDansPlat { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plat>().HasData(
            new Plat
            {
                IdPlat = 1,
                NomPlat = "Spaghetti Bolognese",
                SaveurPlat = "Savoureux",
                EstEpicePlat = false,
                EstHealthy = true,
                EstVegetarien = false,
                OriginePlat = "Italie",
                TempsPreparationPlat = 30,
                RepasPlat = "Dîner",
                LienRecettePlat = "",
                LienPhotoPlat = "",
                NotePlat = 5
            },
            new Plat
            {
                IdPlat = 2,
                NomPlat = "Salade César",
                SaveurPlat = "Frais",
                EstEpicePlat = false,
                EstHealthy = true,
                EstVegetarien = false,
                OriginePlat = "États-Unis",
                TempsPreparationPlat = 15,
                RepasPlat = "Déjeuner",
                LienRecettePlat = "",
                LienPhotoPlat = "",
                NotePlat = 4
            }
        );

        modelBuilder.Entity<IngredientDansPlat>()
        .HasKey(ip => new { ip.IdPlat, ip.IdIngredient });
    }
}