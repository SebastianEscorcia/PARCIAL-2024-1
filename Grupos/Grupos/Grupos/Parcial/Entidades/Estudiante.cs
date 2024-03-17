using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.BILL
{
    public class Estudiante
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public double PromedioNotas { get; set; }
        public Estudiante(string nombre, string apellido, int edad, string sexo, double PromedioNotas) {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Sexo = sexo;
            this.PromedioNotas = PromedioNotas;
        }
        public Estudiante(string nombre, string apellido, int edad, string sexo, double nota1, double nota2, double nota3)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Sexo = sexo;
            PromedioNotas = (nota1 + nota2 + nota3) / 3;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Estudiante e = (Estudiante)obj;
            return (Nombre == e.Nombre) && (Apellido == e.Apellido) && (Edad == e.Edad) && (Sexo == e.Sexo) && (PromedioNotas == e.PromedioNotas);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Nombre, Apellido, Edad, Sexo, PromedioNotas).GetHashCode();
        }

    }
}