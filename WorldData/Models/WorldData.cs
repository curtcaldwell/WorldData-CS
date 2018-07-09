using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;

namespace WorldData.Models
{
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
