using System.ComponentModel.DataAnnotations;

public class Plat
{
    [Key]
    public required int IdPlat { get; set; }
    public required string NomPlat { get; set; }
    public string? SaveurPlat { get; set; }
    public bool EstEpicePlat { get; set; }
    public bool EstHealthy { get; set; }
    public bool EstVegetarien { get; set; }
    public string? OriginePlat { get; set; }
    public int? TempsPreparationPlat { get; set; }
    public string? RepasPlat { get; set; }
    public string? LienRecettePlat { get; set; }
    public string? LienPhotoPlat { get; set; }
    public int? NotePlat { get; set; }

    // Navigation property (optionnelle si tu veux faire des relations en C#)
    public ICollection<IngredientDansPlat>? IngredientsDansPlat { get; set; }
}
