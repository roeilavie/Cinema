using ex1.Models.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex1.Models
{
    public class Movie
    {
        int id;
        string name;
        string description;
        string genere;
        string release_date;
        string img;
        float vote_average;

        public Movie() { }

        public Movie(int id, string name, string description, string genere, string release_date, string img, float vote_average)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.genere = genere;
            this.release_date = release_date;
            this.img = img;
            this.vote_average = vote_average;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Genere { get => genere; set => genere = value; }
        public string Release_date { get => release_date; set => release_date = value; }
        public string Img { get => img; set => img = value; }
        public float Vote_average { get => vote_average; set => vote_average = value; }

        public int Insert(string user_name)
        {
            DataServices dataservices = new DataServices();
            return dataservices.Insert(this.id,user_name);
        }

        public Movie Insert()
        {
            DataServices dataservices = new DataServices();
            return dataservices.Insert(this);
        }

        public List<Movie> Read()
        {
            DataServices dataservices = new DataServices();
            List<Movie> movies = dataservices.Read();
            return movies;
        }

        public Movie Read(int id)
        {
            DataServices dataservices = new DataServices();
            Movie movie = dataservices.Read(id);
            return movie;
        }

    }
}