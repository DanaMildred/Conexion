using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class PokemonEntrenadorRepository : IPokemonEntrenadorRepository

    {
        private readonly string connectionString;


        public PokemonEntrenadorRepository(ConexionDB conexion)
        {
            connectionString = conexion.GetConnectionString();
        }
        public List<PokemonEntrenadores> Leer()
        {
            List<PokemonEntrenadores> entrenadores = new List<PokemonEntrenadores>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PokemonEntrenadores";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    entrenadores.Add(new PokemonEntrenadores
                    {
                        Id_Entrenador = Convert.ToInt32(reader["Id_entrenador"]),
                        NombreEntrenador = reader["NombreEntrenador"].ToString(),
                        Ciudad = reader["Ciudad"].ToString(),
                        Pokemon = reader["Pokemon"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                        Nivel = Convert.ToInt32(reader["Nivel"]),
                        Movimiento1 = reader["Movimiento1"].ToString(),
                        Movimiento2 = reader["Movimiento2"].ToString(),
                        Movimiento3 = reader["Movimiento3"].ToString(),
                        Movimiento4 = reader["Movimiento4"].ToString(),
                        LigaGanada = reader["LigaGanada"].ToString()

                    });
                }

            }

            return entrenadores;




        }

        public void Actualizar(PokemonEntrenadores entrenador)
        {
            throw new NotImplementedException();
        }


        public void Eliminar(int idEntrenador)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PokemonEntrenadores WHERE IdEntrenador = @IdEntrenador";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdEntrenador", idEntrenador);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("✅ Entrenador eliminado exitosamente.");
        }
        public void Crear(PokemonEntrenadores entrenador)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO PokemonEntrenadores (IdEntrenador, NombreEntrenador, Ciudad, Pokemon, Tipo, Nivel, Movimiento1, Movimiento2, Movimiento3, Movimiento4, LigaGanada) " +
                               "VALUES (@IdEntrenador, @NombreEntrenador, @Ciudad, @Pokemon, @Tipo, @Nivel, @Movimiento1, @Movimiento2, @Movimiento3, @Movimiento4, @LigaGanada)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdEntrenador", entrenador.Id_Entrenador);
                cmd.Parameters.AddWithValue("@NombreEntrenador", entrenador.NombreEntrenador);
                cmd.Parameters.AddWithValue("@Ciudad", entrenador.Ciudad);
                cmd.Parameters.AddWithValue("@Pokemon", entrenador.Pokemon);
                cmd.Parameters.AddWithValue("@Tipo", entrenador.Tipo);
                cmd.Parameters.AddWithValue("@Nivel", entrenador.Nivel);
                cmd.Parameters.AddWithValue("@Movimiento1", entrenador.Movimiento1);
                cmd.Parameters.AddWithValue("@Movimiento2", entrenador.Movimiento2);
                cmd.Parameters.AddWithValue("@Movimiento3", entrenador.Movimiento3);
                cmd.Parameters.AddWithValue("@Movimiento4", entrenador.Movimiento4);
                cmd.Parameters.AddWithValue("@LigaGanada", entrenador.LigaGanada);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("✅ Entrenador creado exitosamente.");
        }

    }
}
