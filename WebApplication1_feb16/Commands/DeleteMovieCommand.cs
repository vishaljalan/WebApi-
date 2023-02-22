using MediatR;

namespace WebApplication1_feb16.Commands
{
    public record DeleteMovieCommand(int id):IRequest<string>;
    
    
}
