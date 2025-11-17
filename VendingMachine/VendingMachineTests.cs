using AwesomeAssertions;

namespace VendingMachine;

public class VendingMachineTests
{
    [Fact]
    public void Cuando_InsertanUnaMonedaNickel_Debe_PantallaMostrar5()
    {
        var maquina = new VendingMachineBuilder().Build();

        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.Display.Should().Be("$ 5");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaDime_Debe_PantallaMostrar10()
    {
        var maquina = new VendingMachineBuilder().Build();

        maquina.InsertarMoneda(Moneda.Dime);

        maquina.Display.Should().Be("$ 10");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaQuarter_Debe_PantallaMostrar25()
    {
        var maquina = new VendingMachineBuilder().Build();

        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.Display.Should().Be("$ 25");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaNickelDimeYQuarter_Debe_PantallaMostrar40()
    {
        var maquina = new VendingMachineBuilder().Build();

        maquina.InsertarMoneda(Moneda.Nickel);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.Display.Should().Be("$ 40");
    }

    [Fact]
    public void Cuando_InsertanUnaMonedaPenny_Debe_PantallaSerINSERTARMONEDAYMonedaCaerEnBandejaDevolucion()
    {
        var maquina = new VendingMachineBuilder().Build();

        maquina.InsertarMoneda(Moneda.Penny);

        maquina.Display.Should().Be("INSERTAR MONEDA");
        maquina.BandejaDevolucion.Should().Contain(Moneda.Penny);
    }

    [Fact]
    public void
        Cuando_InsertanUnaMonedaPennyNickelDimeQuarterYPenny_Debe_PantallaMostrar40YBandejaDevolucionTener2Penny()
    {
        var maquina = new VendingMachineBuilder().Build();
        IEnumerable<Moneda> monedasEnBandejaEsperadas = [Moneda.Penny, Moneda.Penny];

        maquina.InsertarMoneda(Moneda.Penny);
        maquina.InsertarMoneda(Moneda.Nickel);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Penny);

        maquina.Display.Should().Be("$ 40");
        maquina.BandejaDevolucion.Should().Contain(monedasEnBandejaEsperadas);
    }

    [Fact]
    public void Cuando_NoSeHaInsertadoDineroYSeleccionanChips_Debe_PantallaMostrarPRECIO50()
    {
        var maquina = new VendingMachineBuilder().ConChips(1).Build();

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Display.Should().Be("PRECIO $50");
    }

    [Fact]
    public void Cuando_UsuarioTieneSaldo50YSeleccionanCandyQueTieneValor65_Debe_PantallaMostrarPrecioCandy()
    {
        var maquina = new VendingMachineBuilder().ConCandy(1).Build();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Display.Should().Be("PRECIO $65");
    }

    [Fact]
    public void Cuando_UsuarioTieneSaldo60YSeleccionanColaQueTieneValor100_Debe_PantallaMostrarPrecioCola()
    {
        var maquina = new VendingMachineBuilder().ConCola(1).Build();

        maquina.SeleccionarProducto(Producto.Cola);

        maquina.Display.Should().Be("PRECIO $100");
    }

    [Fact]
    public void Cuando_UsuarioInserta50YSeleccionaChips_Debe_PantallaMostrarGraciasDispensarChipsYNoEntregarCambio()
    {
        var maquina = new VendingMachineBuilder().ConChips(1).Build();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Display.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Chips);
        maquina.BandejaDevolucion.Should().BeEmpty();
    }

    [Fact]
    public void Cuando_UsuarioInserta65YSeleccionaCandy_Debe_PantallaMostrarGraciasDispensarCandyYNoEntregarCambio()
    {
        var maquina = new VendingMachineBuilder().ConCandy(1).Build();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Display.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Candy);
        maquina.BandejaDevolucion.Should().BeEmpty();
    }

    [Fact]
    public void Cuando_UsuarioInserta100YSeleccionaCola_Debe_PantallaMostrarGraciasDispensarColaYNoEntregarCambio()
    {
        var maquina = new VendingMachineBuilder().ConCola(1).Build();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);

        maquina.SeleccionarProducto(Producto.Cola);

        maquina.Display.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Cola);
        maquina.BandejaDevolucion.Should().BeEmpty();
    }

    [Fact]
    public void Cuando_UsuarioInserta70YSeleccionaCandy_Debe_PantallaMostrarGraciasDispensarCandyYEntregar5Cambio()
    {
        var maquina = new VendingMachineBuilder().ConCandy(1).ConNickel(1).Build();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Dime);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Display.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Candy);
        maquina.SaldoBandejaMonedas.Should().Be(5);
    }

    [Fact]
    public void Cuando_UsuarioInserta90YSeleccionaChips_Debe_PantallaMostrarGraciasDispensarChipsYEntregar40Cambio()
    {
        var maquina = new VendingMachineBuilder().ConChips(5).ConDime(10).Build();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Display.Should().Be("Gracias");
        maquina.BandejaProductos.Should().Contain(Producto.Chips);
        maquina.SaldoBandejaMonedas.Should().Be(40);
    }

    [Fact]
    public void Cuando_UsuarioInserta90YSeleccionaDevolverMoneda_Debe_PantallaMostrarInsertarMonedaYEntregar90Cambio()
    {
        var maquina = new VendingMachineBuilder().Build();
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.DevolverCambio();

        maquina.Display.Should().Be("INSERTAR MONEDA");
        maquina.SaldoBandejaMonedas.Should().Be(90);
    }

    [Fact]
    public void Cuando_UsuarioSeleccionaChipsYMaquinaNoTieneChips_Debe_PantallaMostrarAGOTADO()
    {
        var maquina = new VendingMachineBuilder().ConChips(0).Build();

        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Display.Should().Be("AGOTADO");
    }

    [Fact]
    public void Cuando_UsuarioSeleccionaColaYMaquinaNoTieneCola_Debe_PantallaMostrarAGOTADO()
    {
        var maquina = new VendingMachineBuilder().ConCola(0).Build();

        maquina.SeleccionarProducto(Producto.Cola);

        maquina.Display.Should().Be("AGOTADO");
    }

    [Fact]
    public void Cuando_UsuarioSeleccionaCandyYMaquinaNoTieneCandy_Debe_PantallaMostrarAGOTADO()
    {
        var maquina = new VendingMachineBuilder().ConCandy(0).Build();


        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Display.Should().Be("AGOTADO");
    }

    [Fact]
    public void Cuando_MaquinaTiene1ChipYUsuarioCompraChip2Veces_Debe_PantallaMostrarAGOTADO()
    {
        var maquina = new VendingMachineBuilder().ConChips(1).Build();


        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.SeleccionarProducto(Producto.Chips);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.SeleccionarProducto(Producto.Chips);

        maquina.Display.Should().Be("AGOTADO");
    }

    [Fact]
    public void Cuando_MaquinaNoTieneDineroUsuarioInserta70YCompraCandy_Debe_PantallaMostrarCambioExacto()
    {
        var maquina = new VendingMachineBuilder().ConCandy(1).Build();

        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Dime);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Display.Should().Be("Cambio Exacto");
    }

    [Fact]
    public void Cuando_MaquinaTiene5DineroUsuarioInserta120YCompraCola_Debe_PantallaMostrarCambioExacto()
    {
        var maquina = new VendingMachineBuilder().ConCandy(1).ConNickel(1).Build();

        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Quarter);
        maquina.InsertarMoneda(Moneda.Dime);
        maquina.InsertarMoneda(Moneda.Dime);

        maquina.SeleccionarProducto(Producto.Candy);

        maquina.Display.Should().Be("Cambio Exacto");
    }
}