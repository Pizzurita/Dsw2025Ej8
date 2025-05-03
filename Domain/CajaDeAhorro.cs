using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria

    {
        //Tengo que usar el constructor de la clase padre en la clase hija de la siguiente forma.
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, TipoCuenta.CajaDeAhorro, titulares)
        
        {
        }
        public override void Retirar(decimal monto)
        {

        }

        public override void Depositar(decimal monto)
        {
           
        }

        public override void AplicarInteres()
        {
            
        }
    }
}
