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
        maquina.Pantalla.Should().Be(MaquinaExpendedora.InsertarMonedaMensaje);
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
        var maquina = new MaquinaExpendedora(Moneda.Dime, Moneda.Dime, Moneda.Dime);
        var dime = Moneda.Dime;

        maquina.InsertarMoneda(dime);
        maquina.InsertarMoneda(dime);

        maquina.Importe.Should().Be(50);
    }
    
    [Fact]
    public void Cuando_ImporteMaquinaEs30UsuarioInsertaDosMonedasDimeYSolicitaDevolucionDinero_Debe_ImporteMaquinaVolverA30()
    {
        var maquina = new MaquinaExpendedora(Moneda.Dime, Moneda.Dime, Moneda.Dime);
        var dime = Moneda.Dime;
        maquina.InsertarMoneda(dime);
        maquina.InsertarMoneda(dime);
    
        maquina.DevolverMonedas();
    
        maquina.Importe.Should().Be(30);
    }
    
    [Fact]
    public void Cuando_NoSeHaInsertadoDinero_Debe_PantallaMostrarINSERTARMONEDA()
    {
        var maquina = new MaquinaExpendedora(Moneda.Dime, Moneda.Dime, Moneda.Dime);
    
        maquina.Pantalla.Should().Be(MaquinaExpendedora.InsertarMonedaMensaje);
    }
    
    [Fact]
    public void Cuando_NoHaInsertadoDineroYSeleccionanChips_Debe_PantallaMostrarPrecioChips()
    {
        var maquina = new MaquinaExpendedora(Moneda.Dime, Moneda.Dime, Moneda.Dime);
    
        maquina.SeleccionarProducto(Producto.Chips);
    
        maquina.Pantalla.Should().Be("PRECIO $50");
    }
    
    [Fact]
    public void Cuando_UsuarioInserta50YSeleccionanCandyQueTieneValor65_Debe_PantallaMostrarPrecioCandy()
    {
        var maquina = new MaquinaExpendedora(Moneda.Dime, Moneda.Dime, Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
    
        maquina.SeleccionarProducto(Producto.Candy);
    
        maquina.Pantalla.Should().Be("PRECIO $65");
    }
    
    [Fact]
    public void Cuando_NoHaInsertadoDineroYSeleccionanCola_Debe_PantallaMostrarPrecioCola()
    {
        var maquina = new MaquinaExpendedora(Moneda.Dime, Moneda.Dime, Moneda.Dime);
    
        maquina.SeleccionarProducto(Producto.Cola);
    
        maquina.Pantalla.Should().Be("PRECIO $100");
    }
    
    [Fact]
    public void Cuando_SaldoEs50YSeSeleccionaChips_Debe_PantallaMostrarGracias()
    {
        var maquina = new MaquinaExpendedora(Moneda.Dime, Moneda.Dime, Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
    
        maquina.SeleccionarProducto(Producto.Chips);
    
        maquina.Pantalla.Should().Be("THANK YOU");
    }
    
    [Fact]
    public void Cuando_SaldoEs65YSeSeleccionaCandy_Debe_PantallaMostrarGracias()
    {
        var maquina = new MaquinaExpendedora(Moneda.Dime, Moneda.Dime, Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Nickel);
    
        maquina.SeleccionarProducto(Producto.Candy);
    
        maquina.Pantalla.Should().Be("THANK YOU");
    }
    

    
}

public class MaquinaExpendedora
{
    public static readonly string InsertarMonedaMensaje = "INSERTAR MONEDA";

    public int Saldo { get; set; }
    public string Pantalla { get; set; }
    public int Importe { get; set; }

    public MaquinaExpendedora(params Moneda[] importe)
    {
        Importe = importe.Sum(moneda => moneda.Valor);
        Pantalla = InsertarMonedaMensaje;
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
        Pantalla = InsertarMonedaMensaje;
    }

    public void SeleccionarProducto(Producto producto)
    {
        if (producto.Nombre == Producto.Chips.Nombre && Saldo == 50)
            Pantalla = "THANK YOU";
        else if (producto.Nombre == Producto.Candy.Nombre && Saldo == 65)
            Pantalla = "THANK YOU";
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