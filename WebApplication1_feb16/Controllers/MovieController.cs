using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1_feb16.Queries;
using WebApplication1_feb16.Models;
using WebApplication1_feb16.Commands;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1_feb16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _mediator.Send(new GetMovieQueries());
            //or use this syntax
            //var movies=await _mediator.GetMovieQueries();
            //same can be used everywhere just pass the parameters if specified in the query function
            return Ok(movies);
        }
        [HttpGet]
        [Route("type")]
        public async Task<IActionResult> Getmoviebytype(string type)
        {
           var movies= await _mediator.Send(new GetmoviebytypeQueries(type));

            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([FromBody] Tmovie tmovie)
        {
            await _mediator.Send(new AddMovieCommand(tmovie));
            return StatusCode(201);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Tmovie tmovie)
        {
            await _mediator.Send(new UpdateMovieCommand(tmovie));
            return StatusCode(201);
        }
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult>Delete(int id)
        {
            await _mediator.Send(new DeleteMovieCommand(id));
            return StatusCode(201);

        }
    }
}


















