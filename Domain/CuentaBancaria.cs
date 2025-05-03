namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; set; }//Publico para pruebas
    public TipoCuenta Tipo { get; private set; }
    public string Numero { get; private set; }
    public decimal TasaDeInteres { get; set; }
    public decimal LimiteDeDescubierto { get; set; }
    public decimal Comision { get; set; }
    public string[] Titulares { get; protected set; }
    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Tipo = tipo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }

    public virtual void Depositar(decimal monto)
    {

    }

    public virtual void Retirar(decimal monto)
    {

    }
    protected void ModificarSaldo(decimal cambio)
    {
        Saldo += cambio;
    }
    

    public virtual void AplicarInteres()
    {


    }
}