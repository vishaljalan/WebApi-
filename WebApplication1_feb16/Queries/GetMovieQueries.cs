using MediatR;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Queries
{
    public record GetMovieQueries:IRequest<List<Tmovie>>
    {
    }
}
