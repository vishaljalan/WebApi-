using MediatR;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;
using WebApplication1_feb16.Queries;

namespace WebApplication1_feb16.Handlers
{
    public class GetMovieHandler : IRequestHandler<GetMovieQueries, List<Tmovie>>
    {
        private readonly IMovie _movie;
        public GetMovieHandler(IMovie movie) { this._movie = movie; }

        public Task<List<Tmovie>> Handle(GetMovieQueries request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_movie.GetMovies());
        }
    }
}
