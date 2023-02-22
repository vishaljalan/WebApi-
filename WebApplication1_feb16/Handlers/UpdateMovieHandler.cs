using MediatR;
using WebApplication1_feb16.Commands;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Handlers
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, List<Tmovie>>
    {
        private readonly IMovie _movie;
        public UpdateMovieHandler(IMovie movie) => this._movie = movie;

        Task<List<Tmovie>> IRequestHandler<UpdateMovieCommand, List<Tmovie>>.Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_movie.UpdateMovie(request.Tmovie));
        }
    }
}
