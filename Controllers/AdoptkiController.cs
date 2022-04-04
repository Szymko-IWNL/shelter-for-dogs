using shelter_for_dogs.Models;
using shelter_for_dogs.Services;
using Microsoft.AspNetCore.Mvc;

namespace shelter_for_dogs.Controllers;

[ApiController]
[Route("[controller]")]
public class AdoptikController : ControllerBase
{
    public AdoptikController()
    {

    }

    [HttpGet]
    public ActionResult<List<Adoptik>> GetAll() =>
        AdoptikService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Adoptik> Get(int id)
    {
        var adoptik = AdoptikService.Get(id);

        if(adoptik == null)
            return NotFound();

        return adoptik;
    }

    [HttpPost]
    public IActionResult Create(Adoptik adoptik)
    {
        AdoptikService.Add(adoptik);
        return CreatedAtAction(nameof(Create), new { id = adoptik.Id }, adoptik);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Adoptik adoptik)
    {
        if (id != adoptik.Id)
            return BadRequest();

        var existingAdoptik = AdoptikService.Get(id);
        if(existingAdoptik is null)
            return NotFound();
        
        AdoptikService.Update(adoptik);

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var adoptik = AdoptikService.Get(id);

        if(adoptik is null)
            return NotFound();

        AdoptikService.Delete(id);

        return NoContent();    
    }
}
