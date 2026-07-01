using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Smart_TV
{
    internal class SmartTV
    {
        private string _marca;
        private int _pulgadas;
        private bool _encendido;
        private int _canalActual;
        private int _volumen;
        private bool _esPremium;

        public SmartTV(string marca, int pulgadas, bool esPremium)
        {
            _marca = marca;
            _pulgadas = pulgadas;
            _esPremium = esPremium;
            _encendido = false;
            _canalActual = 1;
            _volumen = 20;
        }

        public string Marca => _marca;
        public int Pulgadas => _pulgadas;
        public bool Encendido => _encendido;
        public int CanalActual => _canalActual;
        public int Volumen => _volumen;
        public bool EsPremium => _esPremium;

        public string CodigoConfig
        {
            get
            {
                string tipoPlan = _esPremium ? "PREM" : "STD";
                return $"{_marca.ToUpper()}-{_pulgadas}-{tipoPlan}";
            }
        }

        public void Power()
        {
            _encendido = !_encendido;
        }

        public void CambiarCanal()
        {
            if (!_encendido)
            {
                Console.WriteLine("\n[ADVERTENCIA] La TV está apagada.");
                return;
            }

            _canalActual++;
            int limiteMaximo = _esPremium ? 500 : 100;

            if (_canalActual > limiteMaximo)
            {
                _canalActual = 1;
            }
        }

        public void CambiarCanal(int canal)
        {
            if (!_encendido)
            {
                Console.WriteLine("\n[ADVERTENCIA] La TV está apagada.");
                return;
            }

            int limiteMaximo = _esPremium ? 500 : 100;

            if (canal >= 1 && canal <= limiteMaximo)
            {
                _canalActual = canal;
            }
            else
            {
                Console.WriteLine($"\n[ADVERTENCIA] Canal fuera de rango para su plan (1 - {limiteMaximo}).");
            }
        }

        public void RegularVolumen(bool subir)
        {
            if (!_encendido)
            {
                Console.WriteLine("\n[ADVERTENCIA] La TV está apagada.");
                return;
            }

            if (subir)
            {
                _volumen += 2;
                if (_volumen > 100)
                {
                    _volumen = 100;
                }
            }
            else
            {
                _volumen -= 2;
                if (_volumen < 0)
                {
                    _volumen = 0;
                }
            }
        }
    }
}
