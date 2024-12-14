using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogos
{
    public class Catalogos
    {
        public int id { get; set; }
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? Fecha_registro { get; set; }

        public string?  Feha_Inicio{ get; set; }

        public bool Estado { get; set; }

        public string? Fecha_Actualizacion { get; set; }
    }
}