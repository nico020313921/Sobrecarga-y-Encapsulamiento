using _5_Simulador_de_bateria_smartphone;
using System;

namespace SIMULADOR_BATERIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese porcentaje de carga inicial (0-100): ");
            int carga = int.Parse(Console.ReadLine());

            Console.Write("Ingrese salud de la batería inicial (0-100): ");
            int salud = int.Parse(Console.ReadLine());

            Bateria miBateria = new Bateria(carga, salud);
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine(miBateria.EstadoTexto);
                Console.WriteLine($"Modo Ahorro: {(miBateria.ModoAhorroEnergia ? "ACTIVO" : "INACTIVO")}");
                Console.WriteLine($"Salud del Hardware: {miBateria.SaludBateria}%");
                Console.WriteLine($"Cargador: {(miBateria.ConectadoCargador ? "CONECTADO" : "DESCONECTADO")}");
                Console.WriteLine("========================================");
                Console.WriteLine("1 - Alternar Cargador (Conectar/Desconectar)");
                Console.WriteLine("2 - Teléfono en reposo (Consumo base)");
                Console.WriteLine("3 - Abrir app pesada / juego");
                Console.WriteLine("4 - Simular tiempo cargando (1% de carga)");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("========================================");

                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        miBateria.AlternarCargador();
                        break;

                    case 2:
                        miBateria.ConsumirEnergia();
                        break;

                    case 3:
                        Console.Write("Ingrese el porcentaje de consumo de la app: ");
                        int consumoApp = int.Parse(Console.ReadLine());
                        miBateria.ConsumirEnergia(consumoApp);
                        break;

                    case 4:
                        if (miBateria.ConectadoCargador)
                        {
                            miBateria.CicloDeCarga();
                        }
                        else
                        {
                            Console.WriteLine("Error: Debe conectar el cargador primero.");
                            Console.ReadKey();
                        }
                        break;
                }

            } while (opcion != 0);
        }
    }
}
