using MediatR;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;
using WebApplication1_feb16.Queries;

namespace WebApplication1_feb16.Handlers
{
    public class GetmoviebytypeHandler : IRequestHandler<GetmoviebytypeQueries, List<Tmovie>>
    {

        private readonly IMovie movie;
        public GetmoviebytypeHandler(IMovie movie)
        {
            this.movie = movie;
        }

        public Task<List<Tmovie>> Handle(GetmoviebytypeQueries request, CancellationToken cancellationToken)
        {
            return Task.FromResult(movie.GetMovieByType(request.type));
        }
    }
}
