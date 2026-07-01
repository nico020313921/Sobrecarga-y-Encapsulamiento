using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AUTOMOVIL
{
    internal class Automovil
    {
        private string _marca;
        private bool _motorEncendido;
        private int _velocidadActual;
        private bool _cajaAutomatica;
        private bool _modoCrucero;

        public Automovil(string marca, bool cajaAutomatica)
        {
            _marca = marca;
            _cajaAutomatica = cajaAutomatica;
            _motorEncendido = false;
            _velocidadActual = 0;
            _modoCrucero = false;
        }

        public string Marca => _marca;
        public bool MotorEncendido => _motorEncendido;
        public int VelocidadActual => _velocidadActual;
        public bool CajaAutomatica => _cajaAutomatica;
        public bool ModoCrucero => _modoCrucero;

        public string Identificador
        {
            get
            {
                string tipoCaja = _cajaAutomatica ? "AUTO" : "MAN";
                string tresLetras = _marca.Length >= 3 ? _marca.Substring(0, 3) : _marca;
                return $"{tresLetras.ToUpper()}-{tipoCaja}-2026";
            }
        }

        public void EncenderApagar()
        {
            _motorEncendido = !_motorEncendido;

            if (!_motorEncendido)
            {
                _velocidadActual = 0;
                _modoCrucero = false;
            }
        }

        public void Acelerar()
        {
            Acelerar(10);
        }

        public void Acelerar(int kmh)
        {
            if (!_motorEncendido)
            {
                Console.WriteLine("\n[ADVERTENCIA] No se puede acelerar: El motor está apagado.");
                return;
            }

            _velocidadActual += kmh;

            int limiteMaximo = _cajaAutomatica ? 220 : 180;
            if (_velocidadActual > limiteMaximo)
            {
                _velocidadActual = limiteMaximo;
            }
        }

        public void Frenar()
        {
            if (!_motorEncendido)
            {
                Console.WriteLine("\n[ADVERTENCIA] El motor ya está apagado.");
                return;
            }

            _velocidadActual = 0;
            _modoCrucero = false;
        }

        public void Frenar(int kmh)
        {
            if (!_motorEncendido)
            {
                Console.WriteLine("\n[ADVERTENCIA] El motor está apagado.");
                return;
            }

            _velocidadActual -= kmh;
            _modoCrucero = false;

            if (_velocidadActual < 0)
            {
                _velocidadActual = 0;
            }
        }

        public void ActivarModoCrucero()
        {
            if (!_motorEncendido)
            {
                Console.WriteLine("\n[ADVERTENCIA] El motor está apagado.");
                return;
            }

            if (_velocidadActual > 60)
            {
                _modoCrucero = true;
            }
            else
            {
                Console.WriteLine("\n[ADVERTENCIA] El modo crucero solo puede activarse a más de 60 km/h.");
            }
        }
    }
}
