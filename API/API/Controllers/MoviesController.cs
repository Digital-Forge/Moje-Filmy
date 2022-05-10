using API.DTO;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_movieService.GetMoviesList());
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_movieService.GetMovieById(id));
        }

        // POST api/<MoviesController>
        [HttpPost]
        public IActionResult Post(MovieDTO input)
        {
            if (_movieService.CreateMovie(input) > 0) return Ok();
            else                                      return BadRequest();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(MovieDTO input)
        {
            if (_movieService.UpdateMovie(input)) return Ok();
            else                                  return BadRequest();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_movieService.DeleteMovie(id)) return Ok();
            else                               return BadRequest();
        }
    }
}
