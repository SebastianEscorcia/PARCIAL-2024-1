using Parcial.BILL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.GUI
{
    public class MenuPrincipal
    {
        ServicioOP operaciones = new ServicioOP();
        List<Grupo> grupos = new List<Grupo>();

        public void manejo()
        {
            Console.SetCursorPosition(10, 9); Console.WriteLine("Parcial analogía entre Conjunto y Elementos");
            Console.SetCursorPosition(10,10); Console.Write("Ingrese la cantidad de grupos: ");
            Console.SetCursorPosition(40, 10); int Cant_Grupos = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Cant_Grupos; i++)
            {
                Console.SetCursorPosition(10, 11); Console.Write($"Ingrese el nombre del Grupo {i + 1}: ");
                Console.SetCursorPosition(41, 11); string nombreGrupo = Console.ReadLine();
                grupos.Add(new Grupo(nombreGrupo));
            }

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.CursorTop);
                Console.WriteLine("Bienvenido al sistema de grupos");
                for (int i = 0; i < grupos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Agregar estudiante a Grupo {grupos[i].NombreGrupo}");
                }
                Console.WriteLine($"{grupos.Count + 1}. Verificación pertenencia de estudiante");
                Console.WriteLine($"{grupos.Count + 2}. Verificación un grupo es subconjunto de otro");
                Console.WriteLine($"{grupos.Count + 3}. Unión de dos grupos");
                Console.WriteLine($"{grupos.Count + 4}. Intersección de dos grupos");
                Console.WriteLine($"{grupos.Count + 5}. Diferencia de dos grupos");
                Console.WriteLine($"{grupos.Count + 6}. Salir");
                Console.Write("Seleccione una opción: ");
                int op = Convert.ToInt32(Console.ReadLine());

                if (op <= grupos.Count)
                {
                    AddEstudiante(grupos[op - 1]);
                }
                else if (op == grupos.Count + 1)
                {
                    Console.Write("Ingrese el número del grupo: ");
                    int grupo = Convert.ToInt32(Console.ReadLine()) - 1;
                    VPertenencia(grupos[grupo]);
                }
                else if (op == grupos.Count + 2)
                {
                    Console.Write("Ingrese el número de los dos grupos: ");
                    int grupo1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    int grupo2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    VSubconjuntos(grupos[grupo1], grupos[grupo2]);
                }
                else if (op == grupos.Count + 3)
                {
                    Console.Write("Ingrese el número de los dos grupos que desea unir: ");
                    int grupo1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    int grupo2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Grupo union = operaciones.Union(grupos[grupo1], grupos[grupo2]);
                    AllEstudiantes(union);
                }
                else if (op == grupos.Count + 4)
                {
                    Console.Write("Ingrese el número de los dos grupos que desea intersectar: ");
                    int grupo1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    int grupo2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Grupo interseccion = operaciones.Interseccion(grupos[grupo1], grupos[grupo2]);
                    AllEstudiantes(interseccion);
                }
                else if (op == grupos.Count + 5)
                {
                    Console.Write("Ingrese el número de los dos grupos que desea diferenciar: ");
                    int grupo1 = Convert.ToInt32(Console.ReadLine()) - 1;
                    int grupo2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Grupo diferencia = operaciones.Diferencia(grupos[grupo1], grupos[grupo2]);
                    AllEstudiantes(diferencia);
                }
                else if (op == grupos.Count + 6)
                {
                    return;
                }
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void AddEstudiante(Grupo grupo)
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del estudiante: ");
            string apellido = Console.ReadLine();
            Console.Write("Ingrese la edad del estudiante: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el sexo del estudiante (F/M): ");
            string sexo = Console.ReadLine();
            while (sexo != "F" && sexo != "M")
            {
                Console.Write("Error Ingrese F para femenino o M para masculino: ");
                sexo = Console.ReadLine();
            }
            Console.Write("Ingrese la primera nota del estudiante: ");
            double nota1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la segunda nota del estudiante: ");
            double nota2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la tercera nota del estudiante: ");
            double nota3 = Convert.ToDouble(Console.ReadLine());

            Estudiante estudiante = new Estudiante(nombre, apellido, edad, sexo, nota1, nota2, nota3);
            operaciones.AddEstudiante(grupo, estudiante);
        }

        private void VPertenencia(Grupo grupo)
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del estudiante: ");
            string apellido = Console.ReadLine();
            Console.Write("Ingrese la edad del estudiante: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el sexo del estudiante (F/M): ");
            string sexo = Console.ReadLine();
            Console.Write("Ingrese el promedio de notas del estudiante: ");
            double Pnotas = Convert.ToDouble(Console.ReadLine());

            Estudiante estudiante = new Estudiante(nombre, apellido, edad, sexo, Pnotas);
            bool pertenece = operaciones.OpPertenencia(grupo, estudiante);

            if (pertenece)
            {
                Console.WriteLine("El estudiante pertenece al grupo.");
            }
            else
            {
                Console.WriteLine("El estudiante no pertenece al grupo.");
            }
        }

        private void VSubconjuntos(Grupo grupo1, Grupo grupo2)
        {
            bool esSubconjunto = operaciones.VSubconjunto(grupo1, grupo2);
            if (esSubconjunto)
            {
                Console.WriteLine("El primer grupo es un subconjunto del segundo grupo.");
            }
            else
            {
                Console.WriteLine("El primer grupo no es un subconjunto del segundo grupo.");
            }
        }

        private void AllEstudiantes(Grupo grupo)
        {
            Console.WriteLine($"Estudiantes en {grupo.NombreGrupo}:");
            foreach (Estudiante estudiante in grupo.Estudiantes)
            {
                Console.WriteLine($"Nombre: {estudiante.Nombre}, Apellido: {estudiante.Apellido}, Edad: {estudiante.Edad}, Sexo: {estudiante.Sexo}, Promedio de Notas: {estudiante.PromedioNotas}");
            }
        }
    } }