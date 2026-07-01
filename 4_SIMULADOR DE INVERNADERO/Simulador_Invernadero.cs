using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_SIMULADOR_DE_INVERNADERO
{
    internal class Simulador_Invernadero
    {
        internal class Invernadero
        {
            private string _nombreSector;
            private int _temperaturaActual;
            private int _humedadSuelo;
            private bool _sistemaRiegoActivo;
            private bool _calefaccionActiva;
            private string _tipoCultivo;

            public Invernadero(string nombreSector, string tipoCultivo)
            {
                _nombreSector = nombreSector;

                string tipoUpper = tipoCultivo.ToUpper();
                if (tipoUpper == "TROPICAL" || tipoUpper == "DESERTICO")
                {
                    _tipoCultivo = tipoUpper;
                }
                else
                {
                    _tipoCultivo = "TROPICAL";
                }

                _temperaturaActual = 25;
                _humedadSuelo = 50;
                _sistemaRiegoActivo = false;
                _calefaccionActiva = false;
            }

            public string NombreSector
            {
                get { return _nombreSector; }
                set { _nombreSector = value; }
            }

            public int TemperaturaActual
            {
                get { return _temperaturaActual; }
            }

            public int HumedadSuelo
            {
                get { return _humedadSuelo; }
            }

            public bool SistemaRiegoActivo
            {
                get { return _sistemaRiegoActivo; }
            }

            public bool CalefaccionActiva
            {
                get { return _calefaccionActiva; }
            }

            public string TipoCultivo
            {
                get { return _tipoCultivo; }
            }

            public string ReporteEstado
            {
                get
                {
                    string alerta = "PARAMETROS OPTIMOS";

                    if (_tipoCultivo == "TROPICAL")
                    {
                        if (_humedadSuelo <= 60)
                        {
                            alerta = "BAJA HUMEDAD";
                        }
                        else if (_temperaturaActual < 20)
                        {
                            alerta = "TEMPERATURA BAJA";
                        }
                        else if (_temperaturaActual > 28)
                        {
                            alerta = "TEMPERATURA ALTA";
                        }
                    }
                    else if (_tipoCultivo == "DESERTICO")
                    {
                        if (_humedadSuelo >= 20)
                        {
                            alerta = "HUMEDAD EXCESIVA";
                        }
                        else if (_temperaturaActual < 25)
                        {
                            alerta = "TEMPERATURA BAJA";
                        }
                        else if (_temperaturaActual > 35)
                        {
                            alerta = "TEMPERATURA ALTA";
                        }
                    }

                    return "SECTOR: " + _nombreSector.ToUpper() +
                           " - CULTIVO: " + _tipoCultivo +
                           " - ALERTA: " + alerta;
                }
            }

            public void SimularClima()
            {
                _humedadSuelo -= 5;
                _temperaturaActual += 1;

                if (_humedadSuelo < 0)
                {
                    _humedadSuelo = 0;
                }
            }

            public void SimularClima(int humedad, int temperatura)
            {
                if (humedad >= 0 && humedad <= 100)
                {
                    _humedadSuelo = humedad;
                }

                _temperaturaActual = temperatura;
            }

            public void ControlAutomatico()
            {
                if (_tipoCultivo == "TROPICAL")
                {
                    if (_humedadSuelo <= 60)
                    {
                        if (_humedadSuelo < 100)
                        {
                            _sistemaRiegoActivo = true;
                        }
                    }
                    else
                    {
                        _sistemaRiegoActivo = false;
                    }

                    if (_temperaturaActual < 20)
                    {
                        if (_temperaturaActual <= 45)
                        {
                            _calefaccionActiva = true;
                        }
                    }
                    else
                    {
                        _calefaccionActiva = false;
                    }
                }
                else if (_tipoCultivo == "DESERTICO")
                {
                    if (_humedadSuelo >= 20)
                    {
                        _sistemaRiegoActivo = false;
                    }

                    if (_temperaturaActual < 25)
                    {
                        if (_temperaturaActual <= 45)
                        {
                            _calefaccionActiva = true;
                        }
                    }
                    else
                    {
                        _calefaccionActiva = false;
                    }
                }

                if (_humedadSuelo == 100)
                {
                    _sistemaRiegoActivo = false;
                }

                if (_temperaturaActual > 45)
                {
                    _calefaccionActiva = false;
                }
            }
        }
    }
}

