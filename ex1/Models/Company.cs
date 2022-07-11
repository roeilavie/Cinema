using ex1.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex1.Models
{
    public class Company
    {
        int id;
        string user_name;
        string password;
        string company_name;
        string image_path;
        string country_name;
        string country_id;
        int year;
        int halls_num;

        public Company()
        {

        }

        public Company(string user_name, string password, string company_name, string image_path, string country_name, string country_id, int year, int halls_num)
        {
            this.user_name = user_name;
            this.password = password;
            this.company_name = company_name;
            this.image_path = image_path;
            this.country_name = country_name;
            this.country_id = country_id;
            this.year = year;
            this.halls_num = halls_num;
        }

        public Company(int id, string user_name, string password, string company_name, string image_path, string country_name, string country_id, int year, int halls_num)
        {
            this.id = id;
            this.user_name = user_name;
            this.password = password;
            this.company_name = company_name;
            this.image_path = image_path;
            this.country_name = country_name;
            this.country_id = country_id;
            this.year = year;
            this.halls_num = halls_num;
        }

        public string User_name { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
        public string Company_name { get => company_name; set => company_name = value; }
        public string Image_path { get => image_path; set => image_path = value; }
        public string Country_name { get => country_name; set => country_name = value; }
        public string Country_id { get => country_id; set => country_id = value; }
        public int Year { get => year; set => year = value; }
        public int Halls_num { get => halls_num; set => halls_num = value; }
        public int Id { get => id; set => id = value; }

        public Company Insert()
        {
            DataServices ds = new DataServices();
            return ds.Insert(this);
        }

        public List<Company> Read()
        {
            DataServices ds = new DataServices();
            return ds.ReadCompanies();
        }

        public int Update()
        {
            DataServices ds = new DataServices();
            return ds.Update(this);
        }

        public int Delete(string user_name)
        {
            DataServices ds = new DataServices();
            return ds.Delete(user_name);
        }
    }
}