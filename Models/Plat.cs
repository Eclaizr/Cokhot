using System.ComponentModel.DataAnnotations;

public class Plat
{
    [Key]
    public int IdPlat { get; set; } = 0;
    public required string nomPlat { get; set; } = "Default";
    public string? saveurPlat { get; set; }
    public bool estEpicePlat { get; set; }
    public bool estHealthy { get; set; }
    public bool estVegetarien { get; set; }
    public string? originePlat { get; set; }
    public int? tempsPreparationPlat { get; set; }
    public string? repasPlat { get; set; }
    public string? lienRecettePlat { get; set; }
    public string? lienPhotoPlat { get; set; }
    public int? notePlat { get; set; }

    // Navigation property (optionnelle si tu veux faire des relations en C#)
    public ICollection<IngredientDansPlat>? IngredientsDansPlat { get; set; }

    public Plat()
    {
        IdPlat = 0;
        nomPlat = "Default";
    }

}
