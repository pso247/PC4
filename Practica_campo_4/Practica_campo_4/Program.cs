using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_campo_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            paciente[] pacientes = new paciente[5];
            int alto = 0, moderado = 0, bajo = 0;

            for (int i = 0; i < pacientes.Length; i++)
            {
                pacientes[i] = new paciente();

                Console.WriteLine($"\n--- Ingrese datos del paciente {i + 1} ---");
                Console.Write("Edad: ");
                pacientes[i].Edad = int.Parse(Console.ReadLine());

                Console.Write("Presión Sistólica: ");
                pacientes[i].PresionSistolica = int.Parse(Console.ReadLine());

                Console.Write("Presión Diastólica: ");
                pacientes[i].PresionDiastolica = int.Parse(Console.ReadLine());

                Console.Write("Nivel de Glucosa (mg/dL): ");
                pacientes[i].Glucosa = int.Parse(Console.ReadLine());

                if (pacientes[i].Edad > 60 && pacientes[i].PresionSistolica > 140 || pacientes[i].Glucosa > 180)
                {
                    pacientes[i].Riesgo = "Alto riesgo";
                    alto++;
                }
                else if ((pacientes[i].Edad >= 40 && pacientes[i].Edad <= 60) ||
                         (pacientes[i].PresionSistolica >= 120 && pacientes[i].PresionSistolica <= 139) ||
                         (pacientes[i].Glucosa >= 140 && pacientes[i].Glucosa <= 180))
                {
                    pacientes[i].Riesgo = "Riesgo moderado";
                    moderado++;
                }
                else
                {
                    pacientes[i].Riesgo = "Bajo riesgo";
                    bajo++;
                }
            }

            Console.WriteLine("\n\n--- Tabla de Clasificación ---");
            Console.WriteLine("Paciente | Edad | Presión (Sys/Dia) | Glucosa | Clasificación");
            Console.WriteLine("--------------------------------------------------------------");

            for (int i = 0; i < pacientes.Length; i++)
            {
                Console.WriteLine($"{i + 1,8} | {pacientes[i].Edad,4} | {pacientes[i].PresionSistolica}/{pacientes[i].PresionDiastolica,7} | {pacientes[i].Glucosa,7} | {pacientes[i].Riesgo}");
            }

            Console.WriteLine("\n--- Total por Categoría ---");
            Console.WriteLine($"Alto riesgo     : {alto}");
            Console.WriteLine($"Riesgo moderado: {moderado}");
            Console.WriteLine($"Bajo riesgo     : {bajo}");

            Console.ReadKey();
        }
    }
}
  
