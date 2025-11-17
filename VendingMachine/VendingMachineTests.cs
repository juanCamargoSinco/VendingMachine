using AwesomeAssertions;

namespace VendingMachine;

public class VendingMachineTests
{
    [Fact]
    public void Cuando_InsertanUnaMonedaNickel_Debe_PantallaMostrar5()
    {
        var maquina = new VendingMachine();

        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.Pantalla.Should().Be("$ 5");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaDime_Debe_PantallaMostrar10()
    {
        var maquina = new VendingMachine();

        maquina.InsertarMoneda(Moneda.Dime);

        maquina.Pantalla.Should().Be("$ 10");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaQuarter_Debe_PantallaMostrar25()
    {
        var maquina = new VendingMachine();

        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.Pantalla.Should().Be("$ 25");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaNickelDimeYQuarter_Debe_PantallaMostrar40()
    {
        var maquina = new VendingMachine();

        maquina.InsertarMoneda(Moneda.Nickel);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.Pantalla.Should().Be("$ 40");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaPenny_Debe_PantallaSerINSERTARMONEDAYMonedaCaerEnBandejaDevolucion()
    {
        var maquina = new VendingMachine();

        maquina.InsertarMoneda(Moneda.Penny);

        maquina.Pantalla.Should().Be("INSERTAR MONEDA");
        maquina.BandejaDevolucion.Should().Contain(Moneda.Penny);
    }

    [Fact]
    public void
        Cuando_InsertanUnaMonedaPennyNickelDimeQuarterYPenny_Debe_PantallaMostrar40YBandejaDevolucionTener2Penny()
    {
        var maquina = new VendingMachine();
        IEnumerable<Moneda> monedasEnBandejaEsperadas = [Moneda.Penny, Moneda.Penny];

        maquina.InsertarMoneda(Moneda.Penny);
        maquina.InsertarMoneda(Moneda.Nickel);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Penny);

        maquina.Pantalla.Should().Be("$ 40");
        maquina.BandejaDevolucion.Should().Contain(monedasEnBandejaEsperadas);
    }

    [Fact]
    public void Cuando_NoSeHaInsertadoDineroYSeleccionanChips_Debe_PantallaMostrarPRECIO50()
    {
        var maquina = new VendingMachine();

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Pantalla.Should().Be("PRECIO $50");
    }

    [Fact]
    public void Cuando_UsuarioTieneSaldo50YSeleccionanCandyQueTieneValor65_Debe_PantallaMostrarPrecioCandy()
    {
        var maquina = new VendingMachine();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Pantalla.Should().Be("PRECIO $65");
    }

    [Fact]
    public void Cuando_UsuarioTieneSaldo60YSeleccionanColaQueTieneValor100_Debe_PantallaMostrarPrecioCola()
    {
        var maquina = new VendingMachine();

        maquina.SeleccionarProducto(Producto.Cola);

        maquina.Pantalla.Should().Be("PRECIO $100");
    }

    [Fact]
    public void Cuando_UsuarioInserta50YSeleccionaChips_Debe_PantallaMostrarGraciasDispensarChipsYNoEntregarCambio()
    {
        var maquina = new VendingMachine();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Pantalla.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Chips);
        maquina.BandejaDevolucion.Should().BeEmpty();
    }

    [Fact]
    public void Cuando_UsuarioInserta65YSeleccionaCandy_Debe_PantallaMostrarGraciasDispensarCandyYNoEntregarCambio()
    {
        var maquina = new VendingMachine();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Pantalla.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Candy);
        maquina.BandejaDevolucion.Should().BeEmpty();
    }

    [Fact]
    public void Cuando_UsuarioInserta100YSeleccionaCola_Debe_PantallaMostrarGraciasDispensarColaYNoEntregarCambio()
    {
        var maquina = new VendingMachine();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Cola);

        maquina.Pantalla.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Cola);
        maquina.BandejaDevolucion.Should().BeEmpty();
    }

    [Fact]
    public void Cuando_UsuarioInserta70YSeleccionaCandy_Debe_PantallaMostrarGraciasDispensarCandyYEntregar5Cambio()
    {
        var maquina = new VendingMachine();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Dime);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Pantalla.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Candy);
        maquina.SaldoBandeja.Should().Be(5);
    }

    [Fact]
    public void Cuando_UsuarioInserta90YSeleccionaChips_Debe_PantallaMostrarGraciasDispensarChipsYEntregar40Cambio()
    {
        var maquina = new VendingMachine();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Pantalla.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Chips);
        maquina.SaldoBandeja.Should().Be(40);
    }
}

public enum Producto
{
    Chips,
    Cola,
    Candy
}

public class VendingMachine
{
    private Dictionary<Producto, int> _productos = new()
    {
        { Producto.Cola, 100 },
        { Producto.Chips, 50 },
        { Producto.Candy, 65 }
    };

    public string Pantalla { get; private set; }
    private int Saldo { get; set; }
    public List<Moneda> BandejaDevolucion { get; private set; } = new();
    public int SaldoBandeja => BandejaDevolucion.Sum(ValuarMoneda);
    public List<Producto> BandejaProductos { get; private set; } = new();

    public void InsertarMoneda(Moneda moneda)
    {
        ValidarMonedaPermitida(moneda);

        if (Saldo > 0)
            Pantalla = $"$ {Saldo}";
        else
            Pantalla = "INSERTAR MONEDA";
    }

    private void ValidarMonedaPermitida(Moneda moneda)
    {
        if (moneda == Moneda.Penny)
        {
            BandejaDevolucion.Add(moneda);
            return;
        }

        Saldo += ValuarMoneda(moneda);
    }

    private int ValuarMoneda(Moneda moneda)
    {
        return moneda switch
        {
            Moneda.Quarter => 25,
            Moneda.Dime => 10,
            Moneda.Nickel => 5,
            _ => 0
        };
    }

    public void SeleccionarProducto(Producto producto)
    {
        var precio = _productos[producto];
        if (Saldo >= precio)
        {
            Pantalla = $"Gracias";
            BandejaProductos.Add(producto);
            var vueltas = Saldo - precio;
            if (vueltas > 0)
            {
                var listaVueltas = ObtenerCambio(vueltas);
                foreach (var moneda in listaVueltas)
                {
                    BandejaDevolucion.Add(moneda);
                }
            }
        }
        else
            Pantalla = $"PRECIO ${precio}";
    }

    public List<Moneda> ObtenerCambio(int cambio)
    {
        var monedas = new List<Moneda>();
        int saldoRestante = cambio;

        while (saldoRestante >= 25)
        {
            monedas.Add(Moneda.Quarter);
            saldoRestante -= 25;
        }

        while (saldoRestante >= 10)
        {
            monedas.Add(Moneda.Dime);
            saldoRestante -= 10;
        }

        while (saldoRestante >= 5)
        {
            monedas.Add(Moneda.Nickel);
            saldoRestante -= 5;
        }

        return monedas;
    }
}

public enum Moneda
{
    Nickel,
    Dime,
    Quarter,
    Penny
}