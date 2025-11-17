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
    public void Cuando_InsertanUnaMonedaNickelDimeYQuarter_Debe_PantallaYSaldoMaquinaMostrar40()
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
    public void Cuando_InsertanUnaMonedaPennyNickelDimeQuarterYPenny_Debe_PantallaMostrar40YBandejaDevolucionTener2Penny()
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
}

public class VendingMachine
{
    public string Pantalla { get; private set; }
    private int Saldo { get; set; }
    public List<Moneda> BandejaDevolucion { get; private set; } = new();

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
}

public enum Moneda
{
    Nickel,
    Dime,
    Quarter,
    Penny
}