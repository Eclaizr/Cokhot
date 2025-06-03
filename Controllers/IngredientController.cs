using Microsoft.AspNetCore.Mvc;

[Route("api/ingredients")]
[ApiController]
public class IngredientController(IfIngredientDataRepository ingredientRepository) : ControllerBase
{
    private readonly IfIngredientDataRepository _ingredientRepository = ingredientRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetAllIngredients()
    {
        var ingredients = await _ingredientRepository.GetAllAsync();
        return Ok(ingredients);
    }

    [HttpGet("{id}", Name = "GetIngredientById")]
    public async Task<ActionResult<Ingredient>> GetIngredientById(int id)
    {
        var ingredient = await _ingredientRepository.GetAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return Ok(ingredient);
    }

    [HttpPost]
    public async Task<ActionResult<Ingredient>> CreateIngredient(Ingredient ingredient)
    {
        if (ingredient == null)
        {
            return BadRequest("Ingredient cannot be null.");
        }

        await _ingredientRepository.AddAsync(ingredient);
        return CreatedAtRoute("GetIngredientById", new { id = ingredient.IdIngredient }, ingredient);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateIngredient(int id, Ingredient ingredient)
    {
        if (ingredient == null || id != ingredient.IdIngredient)
        {
            return BadRequest("Ingredient ID mismatch or null ingredient.");
        }

        var existingIngredient = await _ingredientRepository.GetAsync(id);
        if (existingIngredient == null)
        {
            return NotFound();
        }

        await _ingredientRepository.UpdateAsync(existingIngredient, ingredient);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteIngredient(int id)
    {
        var ingredient = await _ingredientRepository.GetAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }

        await _ingredientRepository.DeleteAsync(ingredient);
        return NoContent();
    }
}