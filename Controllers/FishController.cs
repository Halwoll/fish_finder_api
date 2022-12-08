using FishIdentifier.Models;
using FishIdentifier.Services;
using Microsoft.AspNetCore.Mvc;

namespace FishIdentifier.Controllers;

[ApiController]
[Route("[controller]")]
public class FishController : ControllerBase
{
  public FishController()
  {
  
  }

  [HttpGet]
  public ActionResult<List<Fish>> GetAll() =>
    FishService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<Fish> Get(int id)
  {
    var fish = FishService.Get(id);
      if(fish == null)
        return NotFound();

    return fish;
  }

  [HttpPost]
  public IActionResult Create(Fish fish)
  {
    FishService.Add(fish);
    return CreatedAtAction(nameof(Create), new { id = fish.Id }, fish);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Fish fish)
  {
      if (id != fish.Id)
          return BadRequest();
            
      var existingFish = FishService.Get(id);
      if(existingFish is null)
          return NotFound();
    
      FishService.Update(fish);
    
      return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
      var pizza = FishService.Get(id);
    
      if (pizza is null)
          return NotFound();
        
      FishService.Delete(id);
    
      return NoContent();
  }


}
