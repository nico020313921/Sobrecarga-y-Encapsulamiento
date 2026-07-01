using _3_Microondas_digital;
using System;

namespace MICROONDAS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Microondas miMicroondas = new Microondas();
            int opcion = -1;

            while (opcion != 0)
            {
                Console.Clear();

                Console.WriteLine("==================================================");
                Console.WriteLine("          MICROONDAS DIGITAL - TABLERO            ");
                Console.WriteLine("==================================================");
                Console.WriteLine($" PANTALLA TIME:  {miMicroondas.PantallaTiempo}");
                Console.WriteLine($" Potencia:       Nivel {miMicroondas.Potencia}");
                Console.WriteLine($" Puerta:         {(miMicroondas.PuertaAbierta ? "ABIERTA" : "CERRADA")}");
                Console.WriteLine($" Estado:         {(miMicroondas.EnFuncionamiento ? "EN ACCIÓN..." : "DETENIDO")}");
                Console.WriteLine("==================================================");

                Console.WriteLine("\n PANEL DE MANDOS:");
                Console.WriteLine(" 1. Abrir / Cerrar Puerta");
                Console.WriteLine(" 2. Botón Rápido (+30 seg)");
                Console.WriteLine(" 3. Ingresar Tiempo (Segundos)");
                Console.WriteLine(" 4. Regular Potencia (1 al 10)");
                Console.WriteLine(" 5. START (Iniciar)");
                Console.WriteLine(" 6. STOP (Pausar / Borrar)");
                Console.WriteLine(" 0. Salir");
                Console.Write("\n Presione un botón: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            miMicroondas.AbrirCerrarPuerta();
                            break;

                        case 2:
                            miMicroondas.AgregarTiempo();
                            break;

                        case 3:
                            Console.Write("Ingrese cantidad de segundos: ");
                            if (int.TryParse(Console.ReadLine(), out int seg))
                            {
                                miMicroondas.AgregarTiempo(seg);
                            }
                            break;

                        case 4:
                            Console.Write("Ingrese nivel de potencia (1-10): ");
                            if (int.TryParse(Console.ReadLine(), out int pot))
                            {
                                miMicroondas.RegularPotencia(pot);
                            }
                            break;

                        case 5:
                            miMicroondas.Iniciar();
                            break;

                        case 6:
                            miMicroondas.Detener();
                            break;

                        case 0:
                            Console.WriteLine("\nTerminando simulación...");
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