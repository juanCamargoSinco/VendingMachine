namespace VendingMachine;

public class VendingMachine
{
    public VendingMachine(int cantidadChips = 0, int cantidadCola = 0, int cantidadCandy = 0, int cantidadNickel = 0,
        int cantidadDime = 0, int cantidadQuarter = 0)
    {
        _despensa = new Despensa(cantidadChips, cantidadCola, cantidadCandy);
        _monedero = new Monedero(cantidadNickel, cantidadDime, cantidadQuarter);
    }

    public string Display => _pantalla.Display;
    public IEnumerable<Producto> BandejaProductos => _despensa.BandejaProductos;
    public int SaldoBandejaMonedas => _monedero.ObtenerSaldoBandejaMonedas();
    public IEnumerable<Moneda> BandejaDevolucion => _monedero.BandejaDevolucion;
    private readonly Pantalla _pantalla = new();
    private readonly Despensa _despensa;
    private readonly Monedero _monedero;

    public void InsertarMoneda(Moneda moneda)
    {
        _monedero.ValidarMonedaPermitida(moneda);

        if (_monedero.TieneSaldo())
            _pantalla.CambiarASaldo(_monedero.Saldo);
    }

    public void SeleccionarProducto(Producto producto)
    {
        var precio = _despensa.ObtenerPrecioProducto(producto);
        var cambio = _monedero.Saldo - precio;
        var saldoSuficiente = _monedero.Saldo < precio;

        if (_despensa.ProductoEstaAgotado(producto))
            _pantalla.CambiarAAgotado();
        else if (saldoSuficiente)
            _pantalla.CambiarAPrecio(precio);
        else if (_monedero.PuedeDarCambio(cambio) == false)
            _pantalla.CambiarACambioExacto();
        else
        {
            _despensa.DispensarProducto(producto);
            _pantalla.CambiarAGracias();
            _monedero.DevolverSaldo(cambio);
        }
    }

    public void DevolverMonedas()
    {
        _monedero.DevolverSaldo(_monedero.Saldo);
        _pantalla.CambiarAInsertarMoneda();
    }
}