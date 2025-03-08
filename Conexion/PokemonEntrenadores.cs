using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
   public class PokemonEntrenadores
    {
        public int Id_Entrenador { get; set; }

        public string? NombreEntrenador { get; set; }

        public string? Ciudad { get; set; }

        public string? Pokemon { get; set; }

        public string? Tipo { get; set; }

        public int Nivel { get; set; }

        public string? Movimiento1 { get; set; }

        public string? Movimiento2 { get; set; }

        public string? Movimiento3 { get; set; }

        public string? Movimiento4 { get; set; }

        public string? LigaGanada { get; set; }
    }
}
