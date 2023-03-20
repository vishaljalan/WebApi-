using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1_feb16.Commands;
using WebApplication1_feb16.Controllers;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;
using WebApplication1_feb16.Queries;
using WebApplication1_feb16.Repositories;
using Xunit;

namespace WebApplication1_feb16.Test
{
    public class MovieControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly MovieController _controller;

        public MovieControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new MovieController(_mockMediator.Object);
        }

        [Fact]
        public async Task GetMovies_ReturnsOkResult()
        {
            // Arrange
            var queryResult = new List<Tmovie>
        {
            new Tmovie { Movieid = 1, Moviename = "Movie 1", Moviedir = "Director 1", Movietype = "Drama" },
            new Tmovie { Movieid = 2, Moviename = "Movie 2", Moviedir = "Director 2", Movietype = "Action" },
            new Tmovie { Movieid = 3, Moviename = "Movie 3", Moviedir = "Director 3", Movietype = "Comedy" }
        };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetMovieQueries>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _controller.GetMovies();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Tmovie>>(actionResult.Value);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task GetMoviesByType_ReturnsOkResult()
        {
            // Arrange
            var queryResult = new List<Tmovie>
        {
            new Tmovie { Movieid = 2, Moviename = "Movie 2", Moviedir = "Director 2", Movietype = "Action" },
            new Tmovie { Movieid = 4, Moviename = "Movie 4", Moviedir = "Director 4", Movietype = "Action" }
        };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetmoviebytypeQueries>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _controller.Getmoviebytype("Action");

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Tmovie>>(actionResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task CreateNew_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<AddMovieCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Tmovie>());

            // Act
            var result = await _controller.CreateNew(new Tmovie { Moviename = "Movie 4", Moviedir = "Director 4", Movietype = "Action" });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task Update_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateMovieCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Tmovie>());
            // Act
            var result = await _controller.Update(new Tmovie
            {
                Movieid = 2,
                Moviename = "Movie 2 Updated",
                Moviedir = "Director 2 Updated",
                Movietype = "Action"
            });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task Delete_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteMovieCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("Movie deleted successfully");

            // Act
            var result = await _controller.Delete(2);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }
    }
}
