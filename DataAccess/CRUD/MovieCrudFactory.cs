using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public MovieCrudFactory()
        {
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDto)
        {
            var movie = baseDto as Movie;
            var sqlOperation = new SqlOperation() { ProcedureName = "CRE_MOVIE_PR" };

            sqlOperation.AddStringParameter("P_Title", movie.Title);
            sqlOperation.AddStringParameter("P_Description", movie.Description);
            sqlOperation.AddDateTimeParam("P_ReleaseDate", movie.RealiseDate);
            sqlOperation.AddStringParameter("P_Genre", movie.Genre);
            sqlOperation.AddStringParameter("P_Director", movie.Director);

            SqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Create(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseDTO baseDto)
        {
            var movie = baseDto as Movie;
            var sqlOperation = new SqlOperation() { ProcedureName = "DELETE_MOVIE_PR" };
            sqlOperation.AddIntParam("P_Id", movie.Id);

            SqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lsMovie = new List<T>();
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_ALL_MOVIE_PR" };
            var lstResults = SqlDao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var movie = BuildUser(row);
                    lsMovie.Add((T)Convert.ChangeType(movie, typeof(T)));
                }
            }
            return lsMovie;
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "SP_RET_MOVIE_BY_ID_PR" };
            sqlOperation.AddIntParam("@P_Id", id);
            var lstResults = SqlDao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var movie = BuildUser(row);
                return (T)Convert.ChangeType(movie, typeof(T));
            }

            return default(T);

        }

        public override T RetrieveById<T>()
        {
            throw new NotImplementedException();
        }

        public T RetrieveByTitle<T>(Movie movie)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_TITLE_MOVIE" };
            sqlOperation.AddStringParameter("@P_Title", movie.Title);
            var lstResults = SqlDao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var Mv = BuildUser(row);
                return (T)Convert.ChangeType(Mv, typeof(T));
            }

            return default(T);

        }

        public override T Retrive<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDto)
        {
            var movie = baseDto as Movie;
            var sqlOperation = new SqlOperation() { ProcedureName = "UP_MOVIE_PR" };

            sqlOperation.AddIntParam("P_Id", movie.Id);
            sqlOperation.AddStringParameter("P_Title", movie.Title);
            sqlOperation.AddStringParameter("P_Description ", movie.Description);
            sqlOperation.AddDateTimeParam("P_ReleaseDate", movie.RealiseDate);
            sqlOperation.AddStringParameter("P_Genre", movie.Genre);
            sqlOperation.AddStringParameter("P_Director", movie.Director);

            SqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        private Movie BuildUser(Dictionary<string, object> row)
        {
            return new Movie()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                // Updated = (DateTime)row["Updated"],
                Title = (String)row["Title"],
                RealiseDate = (DateTime)row["ReleaseDate"],
                Genre = (String)row["Genre"],
                Director = (String)row["Director"],
                Description = (String)row["Description"]


            };
        }
    }
}