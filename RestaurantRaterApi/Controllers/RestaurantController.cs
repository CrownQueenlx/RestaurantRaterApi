using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterApi.Data;

namespace RestaurantRaterApi.Controllers;

[ApiController] // Tells AspNet that it's an API controller
[Route("[controller]")] // Gets the rout from the controller name (missing brackets makes it a staic value and ended up renameing the extension)
public class RestaurantController : ControllerBase
{
    private readonly RestaurantDbContext _context;
    // Dependency Injection is what probides the DbContext Instance
    public RestaurantController(RestaurantDbContext context)
    {
        _context = context;
    }

    //Create Read Update Delete
    // POST Endpoint (action)
    [HttpPost]
    public async Task<IActionResult> PostRestauant( [FromBody] Restaurant request)
    {
            // ModelState is validation of the request model (body/parameter)
        if(ModelState.IsValid)
        {
            // if the request body is valid (meets all expectations)
            _context.Restaurants.Add(request); // Make the change to the dbContext
            await _context.SaveChangesAsync(); // Save any tracked changes to the actual database
            return Ok(request); //see what has changed
        }

        return BadRequest(ModelState); // Return a 400 with the issues that need to be corrected
    }

    //Async GET Endpoint
    [HttpGet]
    public async Task<IActionResult> GetRestaurants() //set property
    {
        List<Restaurant> restaurants = await _context.Restaurants.Include(r => r.Ratings).ToListAsync();
        return Ok(restaurants);
    }

    [HttpGet] //second endpoint needs an identifier
    [Route("{id:int}")] //defines a route template that takes a dynamic integer that is called id
    public async Task<IActionResult> GetRestaurantById(int id)
    {
        // Accessing _context which is that database context instance
        // Going into the Restaurants DbSet witch references our table
        //  Running a method called FindAsyn that returns the object with the matching Primary Key
        Restaurant? restaurant = await _context.Restaurants.FindAsync(id);

    if(restaurant is null /*Restaurant*/) //type testing or pattern matching
    {
        return NotFound();
    }
        return Ok(restaurant);
    }

    // PUT Endpoint
    [HttpPut]
    public async Task<IActionResult>PutRestaurant([FromBody] Restaurant request)
    {
        //Checking our request object to see if the body is valid
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Restaurant? restaurant = await _context.Restaurants.FindAsync(request.Id);
        if (restaurant is null)
        {
            // If the entity is not found in the database, return a 404 response
            return NotFound();
        }

        // After we find the entity, assign the request values to the entity properties.
        restaurant.Name = request.Name;
        restaurant.Location = request.Location;

        // Mark and save those changes to the database
        _context.Restaurants.Update(restaurant);
        await _context.SaveChangesAsync();
        return Ok();
    }

    // DELETE Endpoint
     [HttpDelete("{restaurantId:int}")]
    public async Task<IActionResult> DeleteResult([FromRoute] int restaurantId)
    {
        var entity = await _context.Restaurants.FindAsync(restaurantId);
        if (entity is null)
        {
            return NotFound();
        }

        // Go through the Ratings table and find all rating WHERE their RestaurantId equals the prameter
        var ratings = _context.Ratings.Where(rating => rating.RestaurantId == restaurantId);
        _context.Ratings.RemoveRange(ratings);
        await _context.SaveChangesAsync();

        _context.Restaurants.Remove(entity);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
