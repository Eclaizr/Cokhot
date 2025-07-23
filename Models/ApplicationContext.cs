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
                nomPlat = "Spaghetti Bolognese",
                saveurPlat = "Savoureux",
                estEpicePlat = false,
                estHealthy = true,
                estVegetarien = false,
                originePlat = "Italie",
                tempsPreparationPlat = 30,
                repasPlat = "Dîner",
                lienRecettePlat = "",
                lienPhotoPlat = "",
                notePlat = 5
            },
            new Plat
            {
                IdPlat = 2,
                nomPlat = "Salade César",
                saveurPlat = "Frais",
                estEpicePlat = false,
                estHealthy = true,
                estVegetarien = false,
                originePlat = "États-Unis",
                tempsPreparationPlat = 15,
                repasPlat = "Déjeuner",
                lienRecettePlat = "",
                lienPhotoPlat = "",
                notePlat = 4
            }
        );

        modelBuilder.Entity<IngredientDansPlat>()
        .HasKey(ip => new { ip.IdPlat, ip.IdIngredient });
    }
}