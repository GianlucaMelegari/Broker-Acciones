using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Integradora_2
{
    internal class Inversor 
    {
        List<Accion> la;
        public Inversor() { la = new List<Accion>(); }

        public Inversor(string pLegajo) : this()
        {
            Legajo = pLegajo;
        }

        public Inversor(string pLegajo, string pNombre, string pApellido, string pDNI) : this(pLegajo)
        {
            Legajo = pLegajo; 
            Nombre = pNombre; 
            Apellido = pApellido; 
            DNI = pDNI;
        }

        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public int Cantidad_A_Asignar {  get; set; }

        public void ComprarAcciones(Accion pAccion)
        {
            la.Add(pAccion);
        }
        public void VenderAcciones(Accion pAccion)
        {
            la.Remove(pAccion);
        }

        public List<Accion> ListaDeAcciones() { return la; }

        public Inversor ClonInversor()
        {
            return new Inversor(Legajo, Nombre, Apellido, DNI) ;
        }
    }
}

