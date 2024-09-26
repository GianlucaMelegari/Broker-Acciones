using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Integradora_2
{
    internal class Accion
    {
        Inversor dueñoDeAccion;

        public Accion(string pCodigo)
        {
            Codigo = pCodigo;
        }
        public Accion(string pCodigo,int pDenominacion, decimal pCotizacion, int pCantidadEmitida)  
        {
            Codigo= pCodigo;
            Denominacion = pDenominacion;
            Cotizacion = pCotizacion;
            CantidadEmitida = pCantidadEmitida;
        }


        public string Codigo { get; set; }
        public int Denominacion { get; set; } 
        public decimal Cotizacion { get; set; }
        public int CantidadEmitida { get; set; }
        //public int ComprasDeLosInverores { get; set; }
        public Inversor DueñoDeAccion { set { dueñoDeAccion = value; } }
        public Inversor RetornaDueño() { return dueñoDeAccion; }

    }
}
