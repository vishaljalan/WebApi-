using MediatR;
using WebApplication1_feb16.Commands;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, List<Tmovie>>
    {
        private readonly IMovie _movie;
        public AddMovieHandler(IMovie movie)
        {
            _movie = movie;
        }

        public Task<List<Tmovie>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_movie.CreateNew(request.Tmovie));
        }
    }
}
