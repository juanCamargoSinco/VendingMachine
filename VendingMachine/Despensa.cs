namespace VendingMachine;

public class Despensa
{
    public Despensa(int cantidadChips, int cantidadCola,  int cantidadCandy)
    {
        if (cantidadChips > 0)
        {
            _inventario[Producto.Chips] = cantidadChips;
        }

        if (cantidadCola > 0)
        {
            _inventario[Producto.Cola] = cantidadCola;
        }

        if (cantidadCandy > 0)
        {
            _inventario[Producto.Candy] = cantidadCandy;
        }

    }
    private readonly Dictionary<Producto, int> _productos = new()
    {
        { Producto.Cola, 100 },
        { Producto.Chips, 50 },
        { Producto.Candy, 65 }
    };

    private readonly Dictionary<Producto, int> _inventario = new()
    {
        { Producto.Chips, 0 },
        { Producto.Cola, 0 },
        { Producto.Candy, 0 },
    };
    public List<Producto> BandejaProductos { get; } = [];

    public bool ProductoEstaAgotado(Producto producto) => _inventario[producto] == 0;
    public void DispensarProducto (Producto producto)
    {
        BandejaProductos.Add(producto);
        _inventario[producto] -= 1;
    }

    public int ObtenerPrecioProducto(Producto producto) => _productos[producto];

}