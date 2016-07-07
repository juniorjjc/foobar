using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppCS
{
    class Mats
    {
        
        private int nrc;
        private string asignatura;
        private int creditos;
        private string modalidad;
        private int periodo;

        public int Nrc
        {
            get
            {
                return nrc;
            }

            set
            {
                nrc = value;
            }
        }

        public string Asignatura
        {
            get
            {
                return asignatura;
            }

            set
            {
                asignatura = value;
            }
        }

        public int Creditos
        {
            get
            {
                return creditos;
            }

            set
            {
                creditos = value;
            }
        }

        public string Modalidad
        {
            get
            {
                return modalidad;
            }

            set
            {
                modalidad = value;
            }
        }

        public int Periodo
        {
            get
            {
                return periodo;
            }

            set
            {
                periodo = value;
            }
        }
    }
}
