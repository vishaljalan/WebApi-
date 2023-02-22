using MediatR;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Queries
{
    public record GetmoviebytypeQueries(string type):IRequest<List<Tmovie>>
        {}
}
