using System;
using static _4_SIMULADOR_DE_INVERNADERO.Simulador_Invernadero;

namespace SIMULADOR_INVERNADERO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese nombre del sector: ");
            string nombreSector = Console.ReadLine();

            Console.Write("Ingrese tipo de cultivo (TROPICAL/DESERTICO): ");
            string tipoCultivo = Console.ReadLine();

            Invernadero invernadero = new Invernadero(nombreSector, tipoCultivo);

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== INVERNADERO INTELIGENTE =====");
                Console.WriteLine(invernadero.ReporteEstado);
                Console.WriteLine();

                Console.WriteLine("Temperatura: " + invernadero.TemperaturaActual + "°C");
                Console.WriteLine("Humedad: " + invernadero.HumedadSuelo + "%");
                Console.WriteLine("Riego: " + (invernadero.SistemaRiegoActivo ? "ACTIVO" : "INACTIVO"));
                Console.WriteLine("Calefacción: " + (invernadero.CalefaccionActiva ? "ACTIVA" : "INACTIVA"));
                Console.WriteLine();

                Console.WriteLine("1 - Simular paso del tiempo");
                Console.WriteLine("2 - Forzar clima");
                Console.WriteLine("3 - Ejecutar control automático");
                Console.WriteLine("0 - Salir");

                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        invernadero.SimularClima();
                        break;

                    case 2:
                        Console.Write("Ingrese humedad: ");
                        int humedad = int.Parse(Console.ReadLine());

                        Console.Write("Ingrese temperatura: ");
                        int temperatura = int.Parse(Console.ReadLine());

                        invernadero.SimularClima(humedad, temperatura);
                        break;

                    case 3:
                        invernadero.ControlAutomatico();
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 0);
        }
    }
}