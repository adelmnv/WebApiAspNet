using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAspNet.Models;

namespace WebApiAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeatherForecastsController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/WeatherForecasts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/WeatherForecasts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(int id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            var weatherForecast = await _context.TodoItems.FindAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return weatherForecast;
        }

        // PUT: api/WeatherForecasts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecast(int id, WeatherForecast weatherForecast)
        {
            if (id != weatherForecast.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherForecast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherForecasts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast)
        {
          if (_context.TodoItems == null)
          {
              return Problem("Entity set 'WeatherContext.TodoItems'  is null.");
          }
            _context.TodoItems.Add(weatherForecast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherForecast", new { id = weatherForecast.Id }, weatherForecast);
        }

        // DELETE: api/WeatherForecasts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecast(int id)
        {
            if (_context.TodoItems == null)
            {
                return NotFound();
            }
            var weatherForecast = await _context.TodoItems.FindAsync(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(weatherForecast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherForecastExists(int id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
