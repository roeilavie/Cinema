using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ex1.Models.DAL
{
    public class DataServices
    {
        // insert a movie to movies table
        public Movie Insert(Movie movie)
        {

            SqlConnection con = Connect();


            // Create Command
            SqlCommand commandMovie = CreateInsertCommand(con, movie);

            // Execute
            try
            {
                commandMovie.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                con.Close();
                return null;
            }

            // Close Connection

            con.Close();

            return movie;

        }
        
        // insert a movie id and user name to movies of companies table
        public int Insert(int id,string user_name)
        {
            SqlConnection con = Connect();


            // Create Command
            SqlCommand commandMOC = CreateInsertCommandToMOC(con, id, user_name);

            // Execute
            try
            {
                commandMOC.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                con.Close();
                return 0;
            }

            // Close Connection

            con.Close();

            return 1;
        }

        // insert a company to companies table
        public Company Insert(Company company)
        {

            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateInsertCommand(con, company, "spInsertCompany");

            // Execute
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                con.Close();
                return null;
            }

            // Close Connection

            con.Close();

            return company;

        }

        // read all the movies from the database
        public List<Movie> Read()
        {

            SqlConnection con = Connect();
            SqlCommand command = CreateReadCommand(con, "spReadMovies");
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Movie> movies = new List<Movie>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["id"]);
                string name = dr["name"].ToString();
                string description = dr["description"].ToString();
                string genere = dr["genere"].ToString();
                string release_date = dr["release_date"].ToString();
                string img = dr["img"].ToString();
                float vote_average = Convert.ToSingle(dr["vote_average"]);
                movies.Add(new Movie(id, name, description, genere, release_date, img, vote_average));

            }

            con.Close();
            return movies;

        }

        // read all the companies from the database
        public List<Company> ReadCompanies()
        {
            SqlConnection con = Connect();
            SqlCommand command = CreateReadCommand(con, "spReadCompanies");
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Company> companies = new List<Company>();

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["id"]);
                string user_name = dr["user_name"].ToString();
                string password = dr["password"].ToString();
                string company_name = dr["company_name"].ToString();
                string image_path = dr["image_path"].ToString();
                string country_name = dr["country_name"].ToString();
                string country_id = dr["country_id"].ToString();
                int year = Convert.ToInt32(dr["year"]);
                int halls_num = Convert.ToInt32(dr["halls_num"]);
                companies.Add(new Company(id,user_name, password,company_name, image_path, country_name, country_id,year,halls_num));

            }

            con.Close();
            return companies;
        }

        // read a specific movie from the database
        public Movie Read(int id)
        {

            SqlConnection con = Connect();
            SqlCommand command = CreateReadCommand(con, id);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            dr.Read();
            int data_id = Convert.ToInt32(dr["id"]);
            string name = dr["name"].ToString();
            string description = dr["description"].ToString();
            string genere = dr["genere"].ToString();
            string release_date = dr["release_date"].ToString();
            string img = dr["img"].ToString();
            float vote_average = Convert.ToSingle(dr["vote_average"]);
            Movie movie = new Movie(id, name, description, genere, release_date, img, vote_average);

            con.Close();
            return movie;

        }

        // update a company details
        public int Update(Company company)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateInsertCommand(con, company, "spUpdateCompany");
            int numaffected;
            // Execute
            try
            {
                numaffected = command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                con.Close();
                return 0;
            }

            // Close Connection

            con.Close();

            return numaffected;
        }

        // delete a company from the database
        public int Delete(string user_name)
        {
            SqlConnection con = Connect();

            // Create Command
            SqlCommand command = CreateDeleteCommand(con, user_name, "spDeleteCompany");
            int numaffected;
            // Execute
            try
            {
                numaffected = command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                con.Close();
                return 0;
            }

            // Close Connection

            con.Close();

            return numaffected;
        }

        // insert command for movie
        private SqlCommand CreateInsertCommand(SqlConnection con, Movie movie)
        {

            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@id", movie.Id);
            command.Parameters.AddWithValue("@name", movie.Name);
            command.Parameters.AddWithValue("@description", movie.Description);
            command.Parameters.AddWithValue("@genere", movie.Genere);
            command.Parameters.AddWithValue("@release_date", movie.Release_date);
            command.Parameters.AddWithValue("@img", movie.Img);
            command.Parameters.AddWithValue("@vote_average", movie.Vote_average);

            command.CommandText = "spInsertMovie";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        // insert command for movie of company
        private SqlCommand CreateInsertCommandToMOC(SqlConnection con, int id, string user_name)
        {
            //MOC = movies of companies in sql

            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@user_name", user_name);

            command.CommandText = "spUsernameAndMovieId";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        // insert command for company
        private SqlCommand CreateInsertCommand(SqlConnection con, Company company, string text)
        {

            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@user_name", company.User_name);
            command.Parameters.AddWithValue("@password", company.Password);
            command.Parameters.AddWithValue("@company_name", company.Company_name);
            command.Parameters.AddWithValue("@image_path", company.Image_path);
            command.Parameters.AddWithValue("@country_name", company.Country_name);
            command.Parameters.AddWithValue("@country_id", company.Country_id);
            command.Parameters.AddWithValue("@year", company.Year);
            command.Parameters.AddWithValue("@halls_num", company.Halls_num);

            command.CommandText = text;
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }

        // read command 
        private SqlCommand CreateReadCommand(SqlConnection con, string text)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = text;
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds
            return command;
        }

        // read command for movie
        private SqlCommand CreateReadCommand(SqlConnection con, int id)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@id", id);
            command.CommandText = "spReadMovieId";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds
            return command;
        }

        // delete command for company
        private SqlCommand CreateDeleteCommand(SqlConnection con, string user_name, string text)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@user_name", user_name);
            command.CommandText = text;
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds
            return command;
        }

        // connect 
        private SqlConnection Connect()
        {


            // read the connection string from the web.config file
            string connectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            // create the connection to the db
            SqlConnection con = new SqlConnection(connectionString);

            // open the database connection
            con.Open();

            return con;

        }
    }
}