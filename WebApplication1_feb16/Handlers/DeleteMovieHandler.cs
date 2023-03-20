using MediatR;
using WebApplication1_feb16.Commands;
using WebApplication1_feb16.DataAccess;

namespace WebApplication1_feb16.Handlers
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, string>
    {
        private readonly IMovie _movie;
        public DeleteMovieHandler(IMovie movie) {
            _movie = movie;
        }

        public Task<string> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_movie.DeleteMovie(request.id));
           
        }
    }
}
