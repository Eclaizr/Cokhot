using Microsoft.AspNetCore.Mvc;

[Route("api/ingredientsdansplat")]
[ApiController]
public class IngredientDansPlatController(IfIngredientDansPlatDataRepository ingredientDansPlatRepository) : ControllerBase
{
    private readonly IfIngredientDansPlatDataRepository _ingredientDansPlatRepository = ingredientDansPlatRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IngredientDansPlat>>> GetAllIngredientsDansPlat()
    {
        var ingredientsDansPlat = await _ingredientDansPlatRepository.GetAllAsync();
        return Ok(ingredientsDansPlat);
    }

    [HttpGet("{idPlat}/{idIngredient}", Name = "GetIngredientDansPlatById")]
    public async Task<ActionResult<IngredientDansPlat>> GetIngredientDansPlatById(int idPlat, int idIngredient)
    {
        var ingredientDansPlat = await _ingredientDansPlatRepository.GetAsync(idPlat, idIngredient);
        if (ingredientDansPlat == null)
        {
            return NotFound();
        }
        return Ok(ingredientDansPlat);
    }

    [HttpPost]
    public async Task<ActionResult<IngredientDansPlat>> CreateIngredientDansPlat(IngredientDansPlat ingredientDansPlat)
    {
        if (ingredientDansPlat == null)
        {
            return BadRequest("IngredientDansPlat cannot be null.");
        }

        await _ingredientDansPlatRepository.AddAsync(ingredientDansPlat);
        return CreatedAtRoute(
            "GetIngredientDansPlatById",
            new { idPlat = ingredientDansPlat.IdPlat, idIngredient = ingredientDansPlat.IdIngredient },
            ingredientDansPlat
        );
    }

    [HttpPut("{idPlat}/{idIngredient}")]
    public async Task<ActionResult> UpdateIngredientDansPlat(int idPlat, int idIngredient, IngredientDansPlat ingredientDansPlat)
    {
        if (ingredientDansPlat == null || idPlat != ingredientDansPlat.IdPlat || idIngredient != ingredientDansPlat.IdIngredient)
        {
            return BadRequest("ID mismatch or null ingredientDansPlat.");
        }

        var existingIngredientDansPlat = await _ingredientDansPlatRepository.GetAsync(idPlat, idIngredient);
        if (existingIngredientDansPlat == null)
        {
            return NotFound();
        }

        await _ingredientDansPlatRepository.UpdateAsync(existingIngredientDansPlat, ingredientDansPlat);
        return NoContent();
    }

    [HttpDelete("{idPlat}/{idIngredient}")]
    public async Task<ActionResult> DeleteIngredientDansPlat(int idPlat, int idIngredient)
    {
        var ingredientDansPlat = await _ingredientDansPlatRepository.GetAsync(idPlat, idIngredient);
        if (ingredientDansPlat == null)
        {
            return NotFound();
        }

        await _ingredientDansPlatRepository.DeleteAsync(ingredientDansPlat);
        return NoContent();
    }
}