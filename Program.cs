using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuentas = new List<CuentaBancaria>
        {
            new CajaDeAhorro("A01", 1000m, new[] { "Zurita, Eduardo" }) { TasaDeInteres = 0.3m },
            new CajaDeAhorro("A02", 2000m, new[] { "Diaz, Ivan" }) { TasaDeInteres = 0.15m },
            new CuentaCorriente("B01", 500m, new[] { "Carabajal, Dante" }) { LimiteDeDescubierto = 500m, Comision = 0.1m },
            new CuentaCorriente("B02", 10m, new[] { "Quiroga, Laureano" }) { LimiteDeDescubierto = 50m, Comision = 0.2m }
        };

            // Forzar una cuenta inactiva para probar error
            cuentas[1].Estado = Estado.Inactiva;

            foreach (var cuenta in cuentas)
            {
                try
                {
                    Console.WriteLine($"\nCuenta: {cuenta.Numero} ({cuenta.Tipo})");

                 
                    cuenta.Depositar(500);
                    

                    //Prueba Deposito Invalido
                    if (cuenta.Numero == "A01")
                    {
                        cuenta.Depositar(-100); // Debería lanzar MontoNoValidoException
                    }


                   //Prueba suspencion de cuenta
                    if (cuenta.Numero == "B02")
                    {
                        //Aqui se suspende la cuenta
                        cuenta.Retirar(1000); 

                        cuenta.Retirar(100); 
                        // CuentaNoActivaException
                        cuenta.Depositar(500); 
                    }

                    //Aplicacion de Interes
                    if (cuenta is CajaDeAhorro ahorro)
                    {
                        ahorro.AplicarInteres();
                    }
                    Console.WriteLine($"\nSe : {cuenta.Saldo} ({cuenta.Tipo}) ({cuenta.Estado})");
                }
                catch (MontoNoValidoException ex)
                {
                    Console.WriteLine($"[Cuenta: {cuenta.Numero}] {ex.Message}");
                }
                catch (CuentaNoActivaException ex)
                {
                    Console.WriteLine($"[Cuenta: {cuenta.Numero}] - {ex.Message}");
                }
                catch (SaldoInsuficienteException ex)
                {
                    Console.WriteLine($"[Cuenta: {cuenta.Numero}] - {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Cuenta: {cuenta.Numero}] - {ex.Message}");
                }
            }

            
            Console.WriteLine("\n----------------- Resumen  Cuentas ------------------");
            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.Tipo.ToString(),
                    Saldo = cuenta.Saldo,
                    Estado = cuenta.Estado.ToString()
                };

                Console.WriteLine($"Cuenta: {resumen.Numero}, Tipo: {resumen.Tipo}, Estado: {resumen.Estado}, Saldo: {resumen.Saldo:C}");
            }

        }
    }
}
