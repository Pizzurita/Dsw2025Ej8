using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Exceptions
{
    public class CuentaNoActivaException : Exception
    {

        public  CuentaNoActivaException(string estado)
            : base ($"La cuenta no se encuentra activa, por lo tanto no se puede operar {estado}")
        {

        }

    }
}
