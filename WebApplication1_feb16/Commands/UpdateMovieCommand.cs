using MediatR;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Commands
{
    public record UpdateMovieCommand(Tmovie Tmovie):IRequest<List<Tmovie>>;
   
}
