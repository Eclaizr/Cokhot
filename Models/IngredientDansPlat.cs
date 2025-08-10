using System.ComponentModel.DataAnnotations;

public class IngredientDansPlat
{
    public required int IdPlat { get; set; }
    public required Plat Plat { get; set; }

    public required int IdIngredient { get; set; }
    public required Ingredient Ingredient { get; set; }

    public string? QuantiteIngredient { get; set; }
}
