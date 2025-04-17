using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<facturacion> clientes = new List<facturacion>();
            string continuar;

            do
            {
                facturacion cliente = new facturacion();

                Console.Write("\nNombre del cliente: ");
                cliente.Nombre = Console.ReadLine();

                Console.Write("Edad: ");
                cliente.Edad = int.Parse(Console.ReadLine());

                Console.Write("¿Es afiliado? (sí/no): ");
                string afiliado = Console.ReadLine().Trim().ToLower();
                cliente.EsAfiliado = (afiliado == "si" || afiliado == "sí");

                Console.Write("Monto de compra: ");
                cliente.MontoCompra = double.Parse(Console.ReadLine());

                if (cliente.EsAfiliado && cliente.Edad > 65)
                    cliente.Descuento = 0.25;
                else if (cliente.EsAfiliado)
                    cliente.Descuento = 0.15;
                else if (cliente.Edad > 65)
                    cliente.Descuento = 0.10;
                else
                    cliente.Descuento = 0.0;

                cliente.TotalPagado = cliente.MontoCompra * (1 - cliente.Descuento);
                clientes.Add(cliente);

                Console.Write("¿Desea ingresar otro cliente? (s/n): ");
                continuar = Console.ReadLine().Trim().ToLower();

            } while (continuar == "s");

            Console.WriteLine("\n--- Detalle de Facturación ---");
            double totalVentas = 0, totalDescuentos = 0;

            foreach (var c in clientes)
            {
                double descuentoMonto = c.MontoCompra - c.TotalPagado;
                totalVentas += c.TotalPagado;
                totalDescuentos += descuentoMonto;

                Console.WriteLine($"\n  Cliente: {c.Nombre}");
                Console.WriteLine($"  Edad: {c.Edad}");
                Console.WriteLine($"  Afiliado: {(c.EsAfiliado ? "Sí" : "No")}");
                Console.WriteLine($"  Monto compra: S/ {c.MontoCompra:F2}");
                Console.WriteLine($"  Descuento: {c.Descuento * 100}%");
                Console.WriteLine($"  Total pagado: S/ {c.TotalPagado:F2}");
            }

            Console.WriteLine("\n--- Resumen Final ---");
            Console.WriteLine($"Total vendido: S/ {totalVentas:F2}");
            Console.WriteLine($"Total en descuentos: S/ {totalDescuentos:F2}");
            Console.WriteLine($"Número de clientes: {clientes.Count}");

            Console.ReadKey();
        }
    }
    
}
