using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    [Key]
    public required int IdIngredient { get; set; }
    public required string NomIngredient { get; set; }
    public decimal? PrixKiloIngredient { get; set; }

    // Navigation property
    public ICollection<IngredientDansPlat>? IngredientsDansPlat { get; set; }
}
