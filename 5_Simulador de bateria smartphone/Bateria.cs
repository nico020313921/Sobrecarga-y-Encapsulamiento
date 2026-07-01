using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Simulador_de_bateria_smartphone
{
    internal class Bateria
    {
        private int _porcentajeCarga;
        private int _saludBateria;
        private bool _conectadoCargador;
        private bool _modoAhorroEnergia;
        private int _acumuladorCargaCiclo;

        public string EstadoTexto
        {
            get
            {
                string prefijo = _conectadoCargador ? "CARGANDO - " : "";
                return $"{prefijo}BATERIA: {_porcentajeCarga}%";
            }
        }

        public int PorcentajeCarga => _porcentajeCarga;
        public int SaludBateria => _saludBateria;
        public bool ConectadoCargador => _conectadoCargador;
        public bool ModoAhorroEnergia => _modoAhorroEnergia;

        public Bateria(int porcentajeInicial, int saludInicial)
        {
            _saludBateria = Math.Clamp(saludInicial, 0, 100);
            _porcentajeCarga = Math.Clamp(porcentajeInicial, 0, _saludBateria);
            _conectadoCargador = false;
            _acumuladorCargaCiclo = 0;

            VerificarModoAhorro();
        }

        public void AlternarCargador()
        {
            _conectadoCargador = !_conectadoCargador;
        }

        public void ConsumirEnergia()
        {
            int consumo = 1;
            if (_modoAhorroEnergia)
            {
                consumo = 0;
            }

            _porcentajeCarga = Math.Max(0, _porcentajeCarga - consumo);
            VerificarModoAhorro();
        }

        public void ConsumirEnergia(int porcentaje)
        {
            int consumo = porcentaje;
            if (_modoAhorroEnergia)
            {
                consumo = porcentaje / 2;
            }

            _porcentajeCarga = Math.Max(0, _porcentajeCarga - consumo);
            VerificarModoAhorro();
        }

        public void CicloDeCarga()
        {
            if (!_conectadoCargador || _porcentajeCarga >= _saludBateria)
            {
                return;
            }

            _porcentajeCarga++;
            _acumuladorCargaCiclo++;

            if (_acumuladorCargaCiclo >= 100)
            {
                _saludBateria = Math.Max(0, _saludBateria - 1);
                _acumuladorCargaCiclo = 0;

                if (_porcentajeCarga > _saludBateria)
                {
                    _porcentajeCarga = _saludBateria;
                }
            }

            VerificarModoAhorro();
        }

        private void VerificarModoAhorro()
        {
            if (_porcentajeCarga < 20)
            {
                _modoAhorroEnergia = true;
            }
            else if (_porcentajeCarga > 50)
            {
                _modoAhorroEnergia = false;
            }
        }
    }
}

