using _2_Smart_TV;
using System;

namespace SMART_TV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CONFIGURACIÓN INICIAL DE LA SMART TV ===");
            Console.Write("Ingrese la marca de la TV: ");
            string marca = Console.ReadLine();

            Console.Write("Ingrese las pulgadas: ");
            int.TryParse(Console.ReadLine(), out int pulgadas);

            Console.Write("¿Tiene Plan Premium? (S/N): ");
            string respuestaPremium = Console.ReadLine().ToUpper();
            bool esPremium = (respuestaPremium == "S");

            SmartTV miTV = new SmartTV(marca, pulgadas, esPremium);

            int opcion = -1;

            while (opcion != 0)
            {
                Console.Clear();

                Console.WriteLine("==================================================");
                Console.WriteLine($" SMART TV - CÓDIGO: {miTV.CodigoConfig}");
                Console.WriteLine("==================================================");
                Console.WriteLine($" Estado:     {(miTV.Encendido ? "ENCENDIDO" : "APAGADO")}");

                if (miTV.Encendido)
                {
                    Console.WriteLine($" Canal:      {miTV.CanalActual}");
                    string displayVolumen = miTV.Volumen == 0 ? "MUTE" : miTV.Volumen.ToString();
                    Console.WriteLine($" Volumen:    {displayVolumen}");
                }
                else
                {
                    Console.WriteLine(" Canal:      --");
                    Console.WriteLine(" Volumen:    --");
                }
                Console.WriteLine("==================================================");

                Console.WriteLine("\n CONTROL REMOTO:");
                Console.WriteLine(" 1. Botón Power (Encender/Apagar)");
                Console.WriteLine(" 2. CH mas (Incrementar canal)");
                Console.WriteLine(" 3. CH número (Ir a canal específico)");
                Console.WriteLine(" 4. Vol mas (Subir volumen)");
                Console.WriteLine(" 5. Vol menos (Bajar volumen)");
                Console.WriteLine(" 0. Salir de la simulación");
                Console.Write("\n Seleccione un botón: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            miTV.Power();
                            break;

                        case 2:
                            miTV.CambiarCanal();
                            break;

                        case 3:
                            Console.Write("Ingrese el número de canal: ");
                            if (int.TryParse(Console.ReadLine(), out int nuevoCanal))
                            {
                                miTV.CambiarCanal(nuevoCanal);
                            }
                            break;

                        case 4:
                            miTV.RegularVolumen(true);
                            break;

                        case 5:
                            miTV.RegularVolumen(false);
                            break;

                        case 0:
                            Console.WriteLine("\nApagando simulador...");
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