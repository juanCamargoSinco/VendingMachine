using AwesomeAssertions;

namespace VendingMachine;

public class UnitTest1
{
    [Fact]
    public void Cuando_InsertanUnaMonedaNickel_Debe_SaldoMaquinaSer5()
    {
        var maquina = new MaquinaExpendedora();
        var nickel = Moneda.Nickel;

        maquina.InsertarMoneda(nickel);

        maquina.Saldo.Should().Be(5);
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaDime_Debe_SaldoMaquinaSer10()
    {
        var maquina = new MaquinaExpendedora();
        var dime = Moneda.Dime;

        maquina.InsertarMoneda(dime);

        maquina.Saldo.Should().Be(10);
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaQuarter_Debe_SaldoMaquinaSer25()
    {
        var maquina = new MaquinaExpendedora();
        var quarter = Moneda.Quarter;

        maquina.InsertarMoneda(quarter);

        maquina.Saldo.Should().Be(25);
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaNickelUnaDimeYUnaQuarter_Debe_SaldoMaquinaSer40()
    {
        var maquina = new MaquinaExpendedora();
        var nickel = Moneda.Nickel;
        var dime = Moneda.Dime;
        var quarter = Moneda.Quarter;

        maquina.InsertarMoneda(nickel);
        maquina.InsertarMoneda(dime);
        maquina.InsertarMoneda(quarter);


        maquina.Saldo.Should().Be(40);
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaNickelYUnaPenny_Debe_SaldoMaquinaSer5YNoSumarMonedaPenny()
    {
        var maquina = new MaquinaExpendedora();
        var nickel = Moneda.Nickel;
        var penny = Moneda.Penny;

        maquina.InsertarMoneda(nickel);
        maquina.InsertarMoneda(penny);

        maquina.Saldo.Should().Be(5);
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaNickel_Debe_PantallaMaquinaMostrarSaldo5()
    {
        var maquina = new MaquinaExpendedora();
        var nickel = Moneda.Nickel;

        maquina.InsertarMoneda(nickel);

        maquina.Pantalla.Should().Be("$5");
    }


    [Fact]
    public void Cuando_InsertanUnaMonedaDime_Debe_PantallaMaquinaMostrarSaldo10()
    {
        var maquina = new MaquinaExpendedora();
        var dime = Moneda.Dime;

        maquina.InsertarMoneda(dime);

        maquina.Pantalla.Should().Be("$10");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaNickelUnaDimeYUnaQuarter_Debe_PantallaMaquinaMostrarSaldo40()
    {
        var maquina = new MaquinaExpendedora();
        var nickel = Moneda.Nickel;
        var dime = Moneda.Dime;
        var quarter = Moneda.Quarter;

        maquina.InsertarMoneda(nickel);
        maquina.InsertarMoneda(dime);
        maquina.InsertarMoneda(quarter);

        maquina.Pantalla.Should().Be("$40");
    }

    [Fact]
    public void Cuando_SolicitoDevolucionMonedas_Debe_SaldoMaquinaSer0YPantallaMostrarINSERTARMONEDA()
    {
        var maquina = new MaquinaExpendedora();
        var nickel = Moneda.Nickel;
        var dime = Moneda.Dime;
        var quarter = Moneda.Quarter;
        maquina.InsertarMoneda(nickel);
        maquina.InsertarMoneda(dime);
        maquina.InsertarMoneda(quarter);

        maquina.DevolverMonedas();

        maquina.Saldo.Should().Be(0);
        maquina.Pantalla.Should().Be(MaquinaExpendedora.MensajeInsertarMoneda);
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaDime_Debe_AumentarImporteMaquinaEn10()
    {
        var maquina = new MaquinaExpendedora();
        var dime = Moneda.Dime;

        maquina.InsertarMoneda(dime);

        maquina.Importe.Should().Be(10);
    }

    [Fact]
    public void Cuando_ImporteMaquinaEs30YInsertanDosMonedasDime_Debe_AumentarImporteMaquinaEn20YSer50()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);
        var dime = Moneda.Dime;

        maquina.InsertarMoneda(dime);
        maquina.InsertarMoneda(dime);

        maquina.Importe.Should().Be(50);
    }

    [Fact]
    public void
        Cuando_ImporteMaquinaEs30UsuarioInsertaDosMonedasDimeYSolicitaDevolucionDinero_Debe_ImporteMaquinaVolverA30()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);
        var dime = Moneda.Dime;
        maquina.InsertarMoneda(dime);
        maquina.InsertarMoneda(dime);

        maquina.DevolverMonedas();

        maquina.Importe.Should().Be(30);
    }

    [Fact]
    public void Cuando_NoSeHaInsertadoDinero_Debe_PantallaMostrarINSERTARMONEDA()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);

        maquina.Pantalla.Should().Be(MaquinaExpendedora.MensajeInsertarMoneda);
    }

    [Fact]
    public void Cuando_NoHaInsertadoDineroYSeleccionanChips_Debe_PantallaMostrarPrecioChips()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Pantalla.Should().Be("PRECIO $50");
    }

    [Fact]
    public void Cuando_UsuarioInserta50YSeleccionanCandyQueTieneValor65_Debe_PantallaMostrarPrecioCandy()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Pantalla.Should().Be("PRECIO $65");
    }

    [Fact]
    public void Cuando_NoHaInsertadoDineroYSeleccionanCola_Debe_PantallaMostrarPrecioCola()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);

        maquina.SeleccionarProducto(Producto.Cola);

        maquina.Pantalla.Should().Be("PRECIO $100");
    }

    [Fact]
    public void Cuando_SaldoEs50YSeSeleccionaChips_Debe_PantallaMostrarGracias()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Pantalla.Should().Be("THANK YOU");
    }

    [Fact]
    public void Cuando_SaldoEs65YSeSeleccionaCandy_Debe_PantallaMostrarGracias()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Pantalla.Should().Be(MaquinaExpendedora.MensajeGracias);
    }

    [Fact]
    public void Cuando_SaldoEs100YSeSeleccionaCola_Debe_PantallaMostrarGracias()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Cola);

        maquina.Pantalla.Should().Be(MaquinaExpendedora.MensajeGracias);
    }

    [Fact]
    public void Cuando_SaldoEs100YSeSeleccionaChips_Debe_PantallaMostrarGracias()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Pantalla.Should().Be(MaquinaExpendedora.MensajeGracias);
    }

    [Fact]
    public void Cuando_ImporteEs30SaldoEs75YSeSeleccionaCandy_Debe_SaldoSer0YImporteser95()
    {
        var importe = new List<Moneda> { Moneda.Dime, Moneda.Dime, Moneda.Dime };
        var maquina = new MaquinaExpendedora(importe);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Saldo.Should().Be(0);
        maquina.Importe.Should().Be(95);
    }

    [Fact]
    public void Cuando_SaldoEs50YSeSeleccionaChips_Debe_DispensarChips()
    {
        var importe = new List<Moneda> { Moneda.Quarter, Moneda.Quarter };
        var inventario = new List<Producto> { Producto.Chips, Producto.Chips, Producto.Chips };
        var maquina = new MaquinaExpendedora(importe, inventario);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Saldo.Should().Be(0);
        maquina.Inventario.Count(producto => producto.Nombre == Producto.Chips.Nombre).Should().Be(2);
    }
}

public class MaquinaExpendedora
{
    public static readonly string MensajeInsertarMoneda = "INSERTAR MONEDA";
    public static readonly string MensajeGracias = "THANK YOU";

    public int Saldo { get; set; }
    public string Pantalla { get; set; }
    public int Importe { get; set; }
    public List<Producto> Inventario { get; set; }

    public MaquinaExpendedora(List<Moneda> importe = null, List<Producto> inventario = null)
    {
        Importe = (importe?.Sum(moneda => moneda.Valor)) ?? 0;
        Pantalla = MensajeInsertarMoneda;
        Inventario = inventario ?? new List<Producto>();
    }

    public void InsertarMoneda(Moneda moneda)
    {
        if (moneda.Nombre != Moneda.Penny.Nombre)
        {
            Saldo += moneda.Valor;
            Pantalla = $"${Saldo}";
            Importe += moneda.Valor;
        }
    }

    public void DevolverMonedas()
    {
        Importe -= Saldo;
        Saldo = 0;
        Pantalla = MensajeInsertarMoneda;
    }

    public void SeleccionarProducto(Producto producto)
    {
        if (Saldo >= producto.Precio)
        {
            Pantalla = MensajeGracias;
            int cambio = Saldo - producto.Precio;
            Importe -= cambio;
            Saldo = 0;
            Inventario.Remove(producto);
        }
        else
            Pantalla = EstablecerPrecio(producto.Precio);
    }

    private static string EstablecerPrecio(int precio) => $"PRECIO ${precio}";
}

public class Moneda
{
    public string Nombre { get; set; }
    public int Valor { get; set; }

    public static readonly Moneda Penny = new() { Nombre = "Penny", Valor = 1 };
    public static readonly Moneda Nickel = new() { Nombre = "Nickel", Valor = 5 };
    public static readonly Moneda Dime = new() { Nombre = "Dime", Valor = 10 };
    public static readonly Moneda Quarter = new() { Nombre = "Quarter", Valor = 25 };
}

public class Producto
{
    public string Nombre { get; set; }
    public int Precio { get; set; }

    public static readonly Producto Cola = new() { Nombre = "Cola", Precio = 100 };
    public static readonly Producto Candy = new() { Nombre = "Candy", Precio = 65 };
    public static readonly Producto Chips = new() { Nombre = "Chips", Precio = 50 };
}