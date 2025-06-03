using Microsoft.AspNetCore.Mvc;

[Route("api/plats")]
[ApiController]
public class PlatController(IfPlatDataRepository platRepository) : ControllerBase
{
    private readonly IfPlatDataRepository _platRepository = platRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plat>>> GetAllPlats()
    {
        var plats = await _platRepository.GetAllAsync();
        return Ok(plats);
    }

    [HttpGet("{id}", Name = "GetPlatById")]
    public async Task<ActionResult<Plat>> GetPlatById(int id)
    {
        var plat = await _platRepository.GetAsync(id);
        if (plat == null)
        {
            return NotFound();
        }
        return Ok(plat);
    }

    [HttpPost]
    public async Task<ActionResult<Plat>> CreatePlat(Plat plat)
    {
        if (plat == null)
        {
            return BadRequest("Plat cannot be null.");
        }

        await _platRepository.AddAsync(plat);
        return CreatedAtRoute("GetPlatById", new { id = plat.IdPlat }, plat);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePlat(int id, Plat plat)
    {
        if (plat == null || id != plat.IdPlat)
        {
            return BadRequest("Plat ID mismatch or null plat.");
        }

        var existingPlat = await _platRepository.GetAsync(id);
        if (existingPlat == null)
        {
            return NotFound();
        }

        await _platRepository.UpdateAsync(existingPlat, plat);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlat(int id)
    {
        var plat = await _platRepository.GetAsync(id);
        if (plat == null)
        {
            return NotFound();
        }

        await _platRepository.DeleteAsync(plat);
        return NoContent();
    }
} 