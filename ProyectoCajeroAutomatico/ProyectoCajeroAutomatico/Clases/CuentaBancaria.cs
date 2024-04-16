using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Desarrolle una aplicación en C#, para un cajero automático. 
La aplicación permitirá crear cuentas para jubilados y personas en actividad.
Los usuarios del cajero podrán depositar en su cuenta y realizar extracciones de la misma.
Si el usuario es una persona en actividad laboral podrá retirar hasta, 20000 pesos en concepto de adelanto de sueldo. Si el usuario es una persona jubilada podrá retirar en concepto de adelanto solo 10000.
Cada operación de ingreso o extracción deberá registrar la fecha, el cajero y el monto de la operación.
Los cajeros se identifican por su dirección y número de cajeros.
Si durante dos meses de operación un usuario tuvo un saldo positivo superior a 20000 pesos, se le ofrecerá un crédito pre acordado de, 80000 pesos. Con lo cual, su nuevo límite de extracción en negativo será de, 80000 pesos.
*/
namespace ProyectoCajeroAutomatico.Clases
{
    public class CuentaBancaria
    {
        public int ultimacuenta = 0;
        public int nroCuenta { get; set; }
        public double SaldoActual { get; set; }
        public DateTime fecha { get; set; }
        public List<Operaciones> Loperaciones { get; set; }
        public Usuario usuario { get; set; }


        public CuentaBancaria() { }

        public CuentaBancaria(Usuario usuario)
        {
            this.nroCuenta = ++ultimacuenta;
            SaldoActual = 0;
            this.fecha = DateTime.Now;
            this.Loperaciones = new List<Operaciones>();
            this.usuario = usuario;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public void deposito(double monto, int cajero)
        {
           
            Operaciones deposito = new Operaciones(DateTime.Now, cajero, "deposito", monto);
            Loperaciones.Add(deposito);
            SaldoActual += monto;
        }
        public void RealizarExtraccion(double monto, int cajero)
        {
            Operaciones nuevaopereta = new Operaciones(DateTime.Now, cajero, "extraccion", monto);
            Loperaciones.Add(nuevaopereta);

            //Actualizacion saldo
            SaldoActual -= monto;

        }
        public double CalcularSaldoPromedio()
        {
            DateTime fechaactual = DateTime.Now;
            DateTime fechalimite = fechaactual.AddMonths(-2);

            //filtrar ultimas operaciones
            var operacionesRecientes = Loperaciones.Where((op => op.Fechaoperacion >= fechalimite));
            if (operacionesRecientes.Count() < 2)
            {
                Console.WriteLine("La cuenta no tiene al menos dos meses de antigüedad.");
                return 0;
            }
            double saldoPromedio = operacionesRecientes.Average(op => op.monto);
            return saldoPromedio;

        }
    }
}
