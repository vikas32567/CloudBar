using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApp.Context;

namespace WebApp.Repositories
{
    public class DapperDrinkRepo : IDapperDrinkRepo
    {
        private readonly string connectionString;

        public DapperDrinkRepo(IConfiguration _config)
        {
            connectionString = _config.GetConnectionString("ConnectionStrings:SqlDatabase");
        }

        public List<Drink> GetDrinks()
        {
            string selectDrinks = "SELECT * FROM Drinks;";
            List<Drink> drinks;

            using (var connection = new SqlConnection(connectionString))
            {
                drinks = connection.Query<Drink>(selectDrinks).ToList();
                Console.WriteLine(selectDrinks);
            }

            return drinks;
        }
    }
}