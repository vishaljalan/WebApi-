using Microsoft.AspNetCore.Mvc;
using WebApplication1_feb16.DataAccess;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.Repositories
{
    public class MovieRepository : IMovie

    {
        private readonly MoviedbContext _dbContext;

        public MovieRepository(MoviedbContext context) 
        {
            _dbContext=context;
        }
        
        public List<Tmovie> CreateNew(Tmovie tmovie)
        {
            _dbContext.Tmovies.Add(tmovie);
            _dbContext.SaveChanges();
            return _dbContext.Tmovies.ToList();
        }

        public string DeleteMovie(int id)
        {

            var movieid = _dbContext.Tmovies.Find(id);
            if(movieid != null)
            {
                _dbContext.Tmovies.Remove(movieid);
                _dbContext.SaveChanges();
                return "success";
            }
            else
            {
                return "not found";
            }
        }

        public List<Tmovie> GetMovieByType(string type)
        {
            //IList<Tmovie> movielist = null;

            var mlt = _dbContext.Tmovies.Where(x => x.Movietype == type).ToList();
            return mlt;


            //return _dbContext.Tmovies.Find(x => x.Movietype == type).ToList();
        }

        //public List<Tmovie> GetMoviesById(int id)
        //{
        //    var moviebyid=_dbContext.Tmovies.Where(f=>f.Movieid== id).ToList();
        //    return moviebyid;
        //}


        public List<Tmovie> GetMovies()
        {
            return _dbContext.Tmovies.ToList();
        }

        public List<Tmovie> UpdateMovie(Tmovie tmovie)
        {
            var getmovieid = _dbContext.Tmovies.Find(tmovie.Movieid);
            if(getmovieid != null)
            {
                try
                {
                    getmovieid.Movieid = tmovie.Movieid;
                    getmovieid.Moviename = tmovie.Moviename;
                    getmovieid.Moviedir = tmovie.Moviedir;
                    getmovieid.Movietype = tmovie.Movietype;
                }
                catch(Exception ex) { Console.WriteLine("no fields"); }
            }
            _dbContext.SaveChanges();
            return _dbContext.Tmovies.ToList() ;
        }

       
    }
}
