using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public CuentaCorriente(string numero, decimal saldo, string[] titulares)
               : base(numero, saldo, TipoCuenta.CuentaCorriente, titulares)
        {

        }
        

        public override void Depositar(decimal monto)
        {
            
        }

        public override void Retirar(decimal monto)
        { 
            
        }

    }
}
