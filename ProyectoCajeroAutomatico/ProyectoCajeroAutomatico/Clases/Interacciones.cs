using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCajeroAutomatico.Clases
{
    public class Interacciones
    {
        public  void Extraccion( CuentaBancaria cuenta) {
            if (cuenta.usuario._tipoUs == "activo")
            {
                if (cuenta.SaldoActual == 0)
                {

                    Console.WriteLine("no puede extraer dinero");
                }
                else Console.WriteLine("su saldo actual es" + cuenta.SaldoActual + "puede extraer hasta 20000");
                Int32.TryParse(Console.ReadLine(), out int extraccion);
                if (extraccion > 20000)
                {
                    Console.WriteLine("no puede extraer mas de 20000");
                }
                else
                    cuenta.RealizarExtraccion(extraccion, 1);

            }
            else if (cuenta.usuario._tipoUs == "jubilado")
            {
                if (cuenta.SaldoActual == 0)
                {

                    Console.WriteLine("no puede extraer dinero");
                }
                else Console.WriteLine("su saldo actual es" + cuenta.SaldoActual + "puede extraer hasta 20000");
                Int32.TryParse(Console.ReadLine(), out int extraccion);
                if (extraccion > 10000)
                {
                    Console.WriteLine("no puede extraer mas de 20000");
                }
                else
                    cuenta.RealizarExtraccion(extraccion, 1);
            }
        }
        public void Deposito(CuentaBancaria cuenta)
        {
            Console.WriteLine("ingrese el monto que desea ingresar");
            Int32.TryParse(Console.ReadLine(), out int deposito);
            cuenta.deposito(deposito,1);
        }
        public void CreditoPreacordado(CuentaBancaria cuenta)
        {
            double saldopromedio = cuenta.CalcularSaldoPromedio();
            if (saldopromedio > 20000)
            {
                Console.WriteLine("Se le ofrece un crédito preacordado de 80000 pesos.");
                cuenta.SaldoActual += 80000; // Aumentar el saldo actual con el crédito preacordado
            }
            else
            {
                Console.WriteLine("no pude acceder al prestamo");
            }

        }
            
    }
}
