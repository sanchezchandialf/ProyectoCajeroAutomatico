using ProyectoCajeroAutomatico.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCajeroAutomatico
{

    class Program
    {
        static List<CuentaBancaria> cuentas = new List<CuentaBancaria>(); // Lista de cuentas

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Menú Principal ---");
                Console.WriteLine("1. Crear cuenta");
                Console.WriteLine("2. Ingresar a una cuenta");
                Console.WriteLine("3. Salir");
                Console.Write("Por favor, elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearCuenta();
                        break;
                    case "2":
                        IngresarCuenta();
                        break;
                    case "3":
                        Console.WriteLine("Gracias por usar nuestro servicio. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intenta de nuevo.");
                        break;
                }
            }
        }

        static void CrearCuenta()
        {
            Console.ReadLine();
            Console.Write("Por favor, ingresa tu DNI: ");
            string dni = Console.ReadLine();

            Console.Write("Por favor, ingresa tu nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Por favor, ingresa tu dirección: ");
            string direccion = Console.ReadLine();

            Console.Write("Por favor, ingresa tu tipo de usuario (1 para activo, 2 para jubilado): ");
            int tipoUsuario = Convert.ToInt32(Console.ReadLine());

            // Crear una nueva instancia de Usuario
            Usuario nuevoUsuario = new Usuario(dni, nombre, direccion, tipoUsuario);

            // Crear una nueva instancia de CuentaBancaria
            CuentaBancaria nuevaCuenta = new CuentaBancaria(nuevoUsuario);

            // Agregar la nueva cuenta a la lista de cuentas
            cuentas.Add(nuevaCuenta);

            Console.WriteLine("Cuenta creada exitosamente. Tu número de cuenta es: " + nuevaCuenta.nroCuenta);
        }

        static void IngresarCuenta()
        {
            Console.Write("Por favor, ingresa tu DNI: ");
            string dni = Console.ReadLine();

            // Buscar la cuenta con el DNI ingresado
            CuentaBancaria cuenta = cuentas.Find(c => c.usuario._id == dni);

            if (cuenta == null)
            {
                Console.WriteLine("No se encontró ninguna cuenta con ese DNI. Por favor, intenta de nuevo.");
            }
            else
            {
                // Si se encontró la cuenta, mostrar el menú del cajero
                MostrarMenuCajero(cuenta);
            }
        }

        static void MostrarMenuCajero(CuentaBancaria cuenta)
        {
            Interacciones interacciones = new Interacciones(); // Crear una nueva instancia de Interacciones

            while (true)
            {
                Console.WriteLine("\n--- Menú del Cajero ---");
                Console.WriteLine("1. Realizar extracción");
                Console.WriteLine("2. Ofrecer crédito preacordado");
                Console.WriteLine("3. Mostrar últimas operaciones");
                Console.WriteLine("4. Salir");
                Console.Write("Por favor, elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Por favor, ingresa el monto a extraer: ");
                        double monto = Convert.ToDouble(Console.ReadLine());
                        interacciones.Extraccion(cuenta);
                        break;
                    case "2":
                        interacciones.CreditoPreacordado(cuenta);
                        break;
                    case "3":
                        if (cuenta.Loperaciones.Count == 0)
                        {
                            Console.WriteLine("No hay operaciones para mostrar.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- Últimas Operaciones ---");
                            foreach (Operaciones operacion in cuenta.Loperaciones)
                            {
                                Console.WriteLine($"Fecha: {operacion.Fecha}");
                                Console.WriteLine($"Cajero: {operacion.cajero}");
                                Console.WriteLine($"Tipo de Operación: {string.Join(", ", operacion.tipoOperracion)}");
                                Console.WriteLine($"Monto: {operacion.monto}\n");
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("Has salido de tu cuenta. ¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intenta de nuevo.");
                        break;
                }
            }
        }
    }

}
