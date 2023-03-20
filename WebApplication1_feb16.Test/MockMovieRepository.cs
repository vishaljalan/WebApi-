using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;
using WebApplication1_feb16.Repositories;

namespace WebApplication1_feb16.Test
{
    //public static Mock<IMovie> GetMoviesMockRepository()
    //{
    //    //craeting fake database
    //    var movies = new List<TmovieDTO>
    //    {
    //        new TmovieDTO
    //        {
    //            Movieid= 1,
    //            Moviename="miller",
    //            Moviedir="abcd",
    //            Movietype="action"
    //        }
    //    };

    //    //mock the student repository or the interface whichever is available. just the listings i.e. interface or definitions
    //    //mock the instance through dummy aka setup
    //    var mockRepo = new Mock<IMovie>();
    //    mockRepo.Setup(x => x.GetMovies()).Returns(movies);
    //    mockRepo.Setup(x => x.CreateNew(TmovieDTO).Returns((TmovieDTO movie) =>
    //        {
    //            movies.Add(movie);
    //            return movie;
    //        }));

    //    mockRepo.Setup(x => x.Equals(movies)).Returns(true);

    //    return mockRepo;
    //}

    public class MockMovieRepository : IMovie
    {
        private readonly List<Tmovie> _tmovies;

        public MockMovieRepository()
        {
            _tmovies = new List<Tmovie>()
        {
            new Tmovie() { Movieid = 1, Moviename = "Movie 1", Moviedir = "Director 1", Movietype = "Drama" },
            new Tmovie() { Movieid = 2, Moviename = "Movie 2", Moviedir = "Director 2", Movietype = "Action" },
            new Tmovie() { Movieid = 3, Moviename = "Movie 3", Moviedir = "Director 3", Movietype = "Comedy" }
        };
        }

        public List<Tmovie> GetMovies()
        {
            return _tmovies;
        }

        public List<Tmovie> CreateNew(Tmovie tmovie)
        {
            _tmovies.Add(tmovie);
            return _tmovies;
        }

        public List<Tmovie> UpdateMovie(Tmovie tmovie)
        {
            var existingTmovie = _tmovies.FirstOrDefault(t => t.Movieid == tmovie.Movieid);
            if (existingTmovie != null)
            {
                existingTmovie.Moviename = tmovie.Moviename;
                existingTmovie.Moviedir = tmovie.Moviedir;
                existingTmovie.Movietype = tmovie.Movietype;
            }
            return _tmovies;
        }

        public string DeleteMovie(int id)
        {
            var existingTmovie = _tmovies.FirstOrDefault(t => t.Movieid == id);
            if (existingTmovie != null)
            {
                _tmovies.Remove(existingTmovie);
                return "Movie deleted successfully";
            }
            else
            {
                return "Movie not found";
            }
        }

        public List<Tmovie> GetMovieByType(string type)
        {
            return _tmovies.Where(t => t.Movietype == type).ToList();
        }
    }
}
