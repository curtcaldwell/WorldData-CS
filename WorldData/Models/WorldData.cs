using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
  // public class Pop
  // {
  //   private int _min;
  //   private int _max;
  //
  //   public Pop (int min, int max)
  //   {
  //     _min = min;
  //     _max = max;
  //   }
  //   public int GetMin()
  //   {
  //     return _min;
  //   }
  //   public int GetMax()
  //   {
  //     return _max;
  //   }
  // }
  public class City
  {
    private string _name;
    private int _population;
    private int _id;


    public City (string name, int population, int Id = 0)
    {
      _name = name;
      _id = Id;
      _population = population;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public int GetPopulation()
    {
      return _population;
    }
    public static List<City> GetStart(string start)
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
           conn.Open();
           MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"SELECT * FROM city WHERE Name LIKE '"+ start + "%'"+";";
           MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
           while(rdr.Read())
           {
             string cityName = rdr.GetString(1);
             int cityPopulation = rdr.GetInt32(4);
             int cityId = rdr.GetInt32(0);

             City newCity = new City(cityName, cityPopulation, cityId);
             allCities.Add(newCity);
           }
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return allCities;
    }
    public static List<City> GetByPopulation(int min, int max)
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
           conn.Open();
           MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"SELECT * FROM City WHERE Population BETWEEN "+ min +" AND "+ max +";";
           MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
           while(rdr.Read())
           {
             string cityName = rdr.GetString(1);
             int cityPopulation = rdr.GetInt32(4);
             int cityId = rdr.GetInt32(0);

             City newCity = new City(cityName, cityPopulation, cityId);
             allCities.Add(newCity);
           }
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return allCities;
    }
    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
           conn.Open();
           MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"SELECT * FROM city;";
           MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
           while(rdr.Read())
           {
             string cityName = rdr.GetString(1);
             int cityPopulation = rdr.GetInt32(4);
             int cityId = rdr.GetInt32(0);

             City newCity = new City(cityName, cityPopulation, cityId);
             allCities.Add(newCity);
           }
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return allCities;
    }
  }
}
