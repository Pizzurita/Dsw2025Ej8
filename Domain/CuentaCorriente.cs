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
            VerificarCuentaActiva();
            if (monto <= 0) throw new MontoNoValidoException();

            monto -= monto * Comision;
            ModificarSaldo(monto);
        }

        public override void Retirar(decimal monto)
        {
            VerificarCuentaActiva();
            if (monto <= 0)
            {

                throw new MontoNoValidoException();
            }
            if ((Saldo - monto) < -LimiteDeDescubierto)
            {
                Estado = Estado.Suspendida;
                ModificarSaldo(-monto);
                throw new SaldoInsuficienteException();
        }
            ModificarSaldo(-monto);

            
        }

    }
}
