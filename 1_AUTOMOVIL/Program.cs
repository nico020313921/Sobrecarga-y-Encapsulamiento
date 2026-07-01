using _1_AUTOMOVIL;
using System;

namespace AUTOMOVIL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CONFIGURACIÓN INICIAL DEL AUTOMÓVIL ===");
            Console.Write("Ingrese la marca del vehículo: ");
            string marca = Console.ReadLine();

            Console.Write("¿Es caja automática? (S/N): ");
            string respuestaCaja = Console.ReadLine().ToUpper();
            bool esAutomatica = (respuestaCaja == "S");

            Automovil miAuto = new Automovil(marca, esAutomatica);

            int opcion = -1;

            while (opcion != 0)
            {
                Console.Clear();

                Console.WriteLine("==================================================");
                Console.WriteLine($" TABLERO - VEHÍCULO: {miAuto.Identificador}");
                Console.WriteLine("==================================================");
                Console.WriteLine($" Motor:      {(miAuto.MotorEncendido ? "ON" : "OFF")}");
                Console.WriteLine($" Velocidad:  {miAuto.VelocidadActual} km/h");
                Console.WriteLine($" Control Crucero: {(miAuto.ModoCrucero ? "ACTIVO" : "INACTIVO")}");
                Console.WriteLine("==================================================");

                Console.WriteLine("\n MANDOS DEL AUTOMÓVIL:");
                Console.WriteLine(" 1. Alternar Motor (Encender/Apagar)");
                Console.WriteLine(" 2. Acelerar (10 km/h)");
                Console.WriteLine(" 3. Acelerar (Ingresar cantidad)");
                Console.WriteLine(" 4. Frenado de Emergencia (Frenar a 0)");
                Console.WriteLine(" 5. Frenar (Ingresar cantidad)");
                Console.WriteLine(" 6. Activar Control de Crucero");
                Console.WriteLine(" 0. Salir de la simulación");
                Console.Write("\n Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            miAuto.EncenderApagar();
                            break;

                        case 2:
                            miAuto.Acelerar();
                            break;

                        case 3:
                            Console.Write("Ingrese cuántos km/h acelerar: ");
                            if (int.TryParse(Console.ReadLine(), out int kmhAcelerar))
                            {
                                miAuto.Acelerar(kmhAcelerar);
                            }
                            break;

                        case 4:
                            miAuto.Frenar();
                            break;

                        case 5:
                            Console.Write("Ingrese cuántos km/h disminuir: ");
                            if (int.TryParse(Console.ReadLine(), out int kmhFrenar))
                            {
                                miAuto.Frenar(kmhFrenar);
                            }
                            break;

                        case 6:
                            miAuto.ActivarModoCrucero();
                            break;

                        case 0:
                            Console.WriteLine("\nSaliendo del simulador...");
                            break;

                        default:
                            Console.WriteLine("\nOpción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPor favor, ingrese un número válido.");
                    opcion = -1;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}