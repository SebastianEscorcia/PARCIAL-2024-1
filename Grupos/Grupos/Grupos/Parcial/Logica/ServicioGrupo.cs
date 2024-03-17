using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.BILL
{
    public class ServicioOP
    {
        public void AddEstudiante(Grupo grupo, Estudiante estudiante)
        {
            grupo.Estudiantes.Add(estudiante);
        }

        public bool OpPertenencia(Grupo grupo, Estudiante estudiante)
        {
            return grupo.Estudiantes.Contains(estudiante);
        }

        public bool VSubconjunto(Grupo grupo1, Grupo grupo2)
        {
            return grupo1.Estudiantes.IsSubsetOf(grupo2.Estudiantes);
        }

        public Grupo Union(Grupo grupo1, Grupo grupo2)
        {
            Grupo union = new Grupo("Union");
            union.Estudiantes.UnionWith(grupo1.Estudiantes);
            union.Estudiantes.UnionWith(grupo2.Estudiantes);
            return union;
        }

        public Grupo Interseccion(Grupo grupo1, Grupo grupo2)
        {
            Grupo interseccion = new Grupo("Interseccion");
            interseccion.Estudiantes.IntersectWith(grupo1.Estudiantes);
            interseccion.Estudiantes.IntersectWith(grupo2.Estudiantes);
            return interseccion;
        }

        public Grupo Diferencia(Grupo grupo1, Grupo grupo2)
        {
            Grupo diferencia = new Grupo("Diferencia");
            diferencia.Estudiantes = new HashSet<Estudiante>(grupo1.Estudiantes);
            diferencia.Estudiantes.ExceptWith(grupo2.Estudiantes);
            return diferencia;
        }
    }

}