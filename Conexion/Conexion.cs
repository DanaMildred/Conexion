using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Conexion
{
    public class ConexionDB
    {
        private readonly string connectionString;


        public ConexionDB()
        {
            connectionString = "Server=LAPTOP-8ACQMTFU\\MSSQLSERVER01;Database=Pokedex;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public string GetConnectionString()
        {
            return connectionString;
        }


        public void ProbarConexion()
        {
            try
            {
                using var conexion = new SqlConnection(connectionString);
                conexion.Open();
                Console.WriteLine("conexion exitosa a SQL Server");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"error al conectar{ex.Message}");
            }
        }


    }
}
