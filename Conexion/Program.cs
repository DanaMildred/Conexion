using Conexion;

class Program
{

    static void Main()
    {
        ConexionDB conexion = new ConexionDB();
        IPokemonEntrenadorRepository repository = new PokemonEntrenadorRepository(conexion);

        while (true)
        {
            Console.WriteLine("\n🔥 MENU POKEDEX 🔥");
            Console.WriteLine("1) Agregar Entrenador");
            Console.WriteLine("2) Mostrar Entrenadores");
            Console.WriteLine("3) Actualizar Entrenador");
            Console.WriteLine("4) Eliminar Entrenador");
            Console.WriteLine("5) Salir");
            Console.Write("➡️ Elige una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    repository.Crear(new PokemonEntrenadores { Id_Entrenador = 1, NombreEntrenador = "Ash", Ciudad = "Pueblo Paleta", Pokemon = "Pikachu", Tipo = "Eléctrico" });
                    break;
                case 2:
                    repository.Leer().ForEach(e => Console.WriteLine($"{e.Id_Entrenador} - {e.NombreEntrenador} - {e.Pokemon}"));
                    break;
                case 3:
                    repository.Actualizar(new PokemonEntrenadores { Id_Entrenador = 1, Nivel = 55 });
                    break;
                case 4:
                    repository.Eliminar(1);
                    break;
                case 5:
                    return;
            }

        }
    }
}
