using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2
{
    internal class Program
    {
        static Queue<menu> colaUrgente = new Queue<menu>();
        static Queue<menu> colaRegular = new Queue<menu>();
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("\n--- Menú Clínica ---");
                Console.WriteLine("1. Ingresar nuevo paciente");
                Console.WriteLine("2. Atender siguiente paciente");
                Console.WriteLine("3. Ver cola de espera");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        IngresarPaciente();
                        break;
                    case 2:
                        AtenderPaciente();
                        break;
                    case 3:
                        VerCola();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 4);

            Console.ReadKey();
        }
            static void IngresarPaciente()
            {
                menu paciente = new menu();

                Console.Write("Nombre del paciente: ");
                paciente.Nombre = Console.ReadLine();

                Console.Write("Edad: ");
                paciente.Edad = int.Parse(Console.ReadLine());

                Console.Write("Tipo de atención (Urgente/Regular): ");
                paciente.TipoAtencion = Console.ReadLine().Trim().ToLower();

                if (paciente.TipoAtencion == "urgente")
                {
                    colaUrgente.Enqueue(paciente);
                    Console.WriteLine($"Paciente {paciente.Nombre} agregado a la cola URGENTE.");
                }
                else
                {
                    colaRegular.Enqueue(paciente);
                    Console.WriteLine($"Paciente {paciente.Nombre} agregado a la cola REGULAR.");
                }
            Console.ReadKey();
        }

            static void AtenderPaciente()
            {
                if (colaUrgente.Count > 0)
                {
                    menu atendido = colaUrgente.Dequeue();
                    Console.WriteLine($"Atendiendo a {atendido.Nombre} (Urgente)");
                }
                else if (colaRegular.Count > 0)
                {
                    menu atendido = colaRegular.Dequeue();
                    Console.WriteLine($"Atendiendo a {atendido.Nombre} (Regular)");
                }
                else
                {
                    Console.WriteLine("No hay pacientes en espera.");
                }
            Console.ReadKey();
        }

            static void VerCola()
            {
                Console.WriteLine("\n--- Pacientes en espera ---");

                Console.WriteLine("\nUrgentes:");
                if (colaUrgente.Count == 0)
                    Console.WriteLine("  (ninguno)");
                else
                    foreach (var p in colaUrgente)
                        Console.WriteLine($"  {p.Nombre} - Edad: {p.Edad}");

                Console.WriteLine("\nRegulares:");
                if (colaRegular.Count == 0)
                    Console.WriteLine("  (ninguno)");
                else
                    foreach (var p in colaRegular)
                        Console.WriteLine($"  {p.Nombre} - Edad: {p.Edad}");

            Console.ReadKey();


            }
        }
    }
