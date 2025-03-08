using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
   public interface IPokemonEntrenadorRepository
    {
        void Crear(PokemonEntrenadores entrenador);
        List<PokemonEntrenadores> Leer();

        void Actualizar(PokemonEntrenadores entrenador);

        void Eliminar(int Id_Entrenador);
    }
}
