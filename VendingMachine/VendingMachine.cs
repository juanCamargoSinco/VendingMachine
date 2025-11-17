namespace VendingMachine;

public class VendingMachine(
    int cantidadChips,
    int cantidadCola,
    int cantidadCandy,
    int cantidadNickel,
    int cantidadDime,
    int cantidadQuarter)
{
    public string Display => _pantalla.Display;
    public IEnumerable<Producto> BandejaProductos => _despensa.BandejaProductos;
    public int SaldoBandejaMonedas => _monedero.ObtenerSaldoBandejaMonedas();
    public IEnumerable<Moneda> BandejaDevolucion => _monedero.BandejaDevolucion;
    private readonly Pantalla _pantalla = new();
    private readonly Despensa _despensa = new(cantidadChips, cantidadCola, cantidadCandy);
    private readonly Monedero _monedero = new(cantidadNickel, cantidadDime, cantidadQuarter);

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
            ProcesarCompra(producto, cambio);
    }

    private void ProcesarCompra(Producto producto, int cambio)
    {
        _despensa.DispensarProducto(producto);
        _pantalla.CambiarAGracias();
        _monedero.DevolverSaldo(cambio);
    }

    public void DevolverCambio()
    {
        _monedero.DevolverSaldo(_monedero.Saldo);
        _pantalla.CambiarAInsertarMoneda();
    }
}