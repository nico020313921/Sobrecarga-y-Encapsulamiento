using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Microondas_digital
{
        internal class Microondas
        {
            private int _potencia;
            private int _tiempoSegundos;
            private bool _puertaAbierta;
            private bool _enFuncionamiento;

            public Microondas()
            {
                _potencia = 5;
                _tiempoSegundos = 0;
                _puertaAbierta = false;
                _enFuncionamiento = false;
            }

            public int Potencia => _potencia;
            public int TiempoSegundos => _tiempoSegundos;
            public bool PuertaAbierta => _puertaAbierta;
            public bool EnFuncionamiento => _enFuncionamiento;

            public string PantallaTiempo
            {
                get
                {
                    int minutos = _tiempoSegundos / 60;
                    int segundos = _tiempoSegundos % 60;
                    return $"{minutos:D2}:{segundos:D2}";
                }
            }

            public void RegularPotencia(int nivel)
            {
                if (_enFuncionamiento)
                {
                    Console.WriteLine("\n[ADVERTENCIA] No se puede cambiar la potencia en funcionamiento.");
                    return;
                }

                if (nivel >= 1 && nivel <= 10)
                {
                    _potencia = nivel;
                }
            }

            public void AgregarTiempo()
            {
                AgregarTiempo(30);
            }

            public void AgregarTiempo(int segundos)
            {
                if (_puertaAbierta)
                {
                    Console.WriteLine("\n[ADVERTENCIA] No se puede agregar tiempo con la puerta abierta.");
                    return;
                }

                _tiempoSegundos += segundos;

                if (_tiempoSegundos > 3600)
                {
                    _tiempoSegundos = 3600;
                }
            }

            public void Iniciar()
            {
                if (_puertaAbierta)
                {
                    Console.WriteLine("\n[ADVERTENCIA] Seguridad: No se puede iniciar con la puerta abierta.");
                    return;
                }

                if (_tiempoSegundos == 0)
                {
                    Console.WriteLine("\n[ADVERTENCIA] Configure un tiempo antes de iniciar.");
                    return;
                }

                _enFuncionamiento = true;
            }

            public void Detener()
            {
                if (_enFuncionamiento)
                {
                    _enFuncionamiento = false;
                }
                else
                {
                    _tiempoSegundos = 0;
                }
            }

            public void AbrirCerrarPuerta()
            {
                _puertaAbierta = !_puertaAbierta;

                if (_puertaAbierta && _enFuncionamiento)
                {
                    _enFuncionamiento = false;
                }
            }
        }
    
}

