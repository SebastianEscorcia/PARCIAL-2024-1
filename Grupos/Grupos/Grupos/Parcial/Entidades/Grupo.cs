using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.BILL
{
    public class Grupo
    {
        public string NombreGrupo { get; set; }
        public HashSet<Estudiante> Estudiantes { get; set; }

        public Grupo(string nombreGrupo)
        {
            NombreGrupo = nombreGrupo;
            Estudiantes = new HashSet<Estudiante>();
        }
    }
}
