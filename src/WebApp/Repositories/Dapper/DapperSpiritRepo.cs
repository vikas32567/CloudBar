using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApp.Context;

namespace WebApp.Repositories
{
    public class DapperSpiritRepo : IDapperSpiritRepo
    {
        private readonly string connectionString;

        public DapperSpiritRepo(IConfiguration _config)
        {
            connectionString = _config.GetConnectionString("SqlDatabase");
        }

        public List<Spirit> GetSpirits()
        {
            string selectSpirits = "SELECT * FROM Spirits;";
            List<Spirit> spirits;

            using (var connection = new SqlConnection(connectionString))
            {
                spirits = connection.Query<Spirit>(selectSpirits).ToList();
            }

            return spirits;
        }
    }
}