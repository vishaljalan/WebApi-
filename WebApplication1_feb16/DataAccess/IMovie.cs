using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.DataAccess
{
    public interface IMovie
    {

        public List<Tmovie> GetMovies();
        //inserting a new record
        public List<Tmovie> CreateNew(Tmovie tmovie);
        //update
        public List<Tmovie> UpdateMovie(Tmovie tmovie);
        //delete
        public string DeleteMovie(int id);

        public List<Tmovie> GetMovieByType(string type);
        //public List<Tmovie> GetMoviesById(int id);
       
    }
}
