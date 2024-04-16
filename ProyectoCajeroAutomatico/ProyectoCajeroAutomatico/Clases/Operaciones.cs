using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCajeroAutomatico.Clases
{
    public class Operaciones
    {
        public DateTime Fecha;
        public int cajero;
        public string[] tipoOperracion = { "deposito", "extraccion", "extraccionPreacor", "dado" };
        public double monto;
        public DateTime Fechaoperacion {  get; set; }
        public Operaciones() { }

        public Operaciones(DateTime fecha, int cajero, string tipoOperracion, double monto)
        {
            Fecha = fecha;
            this.cajero = cajero;
            this.tipoOperracion =new string[] { tipoOperracion };
            this.monto = monto;
        }
    }
}
