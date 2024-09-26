using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Integradora_2
{
    internal class Empresa
    {
        List<Accion> la;
        List<Inversor> li;
        public Empresa()
        {
            la = new List<Accion>();
            li = new List<Inversor>();
            la.AddRange(new Accion[] {new Accion("BGAL-4148-J4T3",1500,15,200),
                                      new Accion("YERD-6556-O2M4",1700,25,155),
                                      new Accion("CSDW-8765-P9L1",800,55,432)  });
        }

        public void AgregarInversor(Inversor pInversor)
        {
            li.Add(pInversor.ClonInversor());
        }

        public void BorrarInversor(Inversor pInversor)
        {
            Inversor p = li.Find(x => x.Legajo == pInversor.Legajo);
            if (p != null) { li.Remove(p); }
            //la.ForEach(a => { if (a.RetornaDueño().DNI == pPersona.DNI) a.Dueño = null; });

        }
        public bool ValidarLegajo(Inversor pInversor) => li.Exists(x => x.Legajo == pInversor.Legajo);
        public void Asignar(Inversor pInversor, Accion pAccion)
        {
            try
            {
                var accion = la.Find(a => a.Codigo == pAccion.Codigo);
                if (accion == null) throw new Exception("No existe la accion a asignar !!!");
                if (accion.RetornaDueño() != null) throw new Exception("No se puede asignar la accion porque ya posee un dueño !!!");
                var inversor = li.Find(p => p.Legajo == pInversor.Legajo);
                if (inversor == null) throw new Exception("No existe la persona !!!");
                
                inversor.ComprarAcciones(accion);  //ASOCIACION BIDIRECCIONAL
                accion.DueñoDeAccion = inversor;       //ASOCIACION BIDIRECCIONAL
            }
            catch (Exception ex) { throw ex; }
        }
        public object ListaDeInversores()
        {
            return (from p in li select new { Legajo = p.Legajo, Nombre = p.Nombre, Apellido = p.Apellido, DNI = p.DNI }).ToList();
        }
        public object ListaDeAcciones()
        {
            return (from a in la select new { Codigo = a.Codigo, Denominacion = a.Denominacion, Cotizacion = a.Cotizacion, CantidadEmitida = a.CantidadEmitida }).ToList();

        }
        public List<Accion> ListaDeAccionesDeUnInversor(Inversor pInversor) 
        {
            try
            {
                var inversor = li.Find(p => p.Legajo == pInversor.Legajo);
                if (inversor == null) throw new Exception("No existe el inversor.");
                return inversor.ListaDeAcciones();
            }
            catch (Exception ex){throw ex;}

        }


    }
}
