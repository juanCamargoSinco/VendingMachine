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
}

public class MaquinaExpendedora
{
    public int Saldo { get; set; }

    public void InsertarMoneda(Moneda moneda)
    {
        Saldo = 5;

        if (moneda.Nombre == Moneda.Dime.Nombre)
            Saldo = 10;
        else if (moneda.Nombre == Moneda.Quarter.Nombre)
            Saldo = 25;
    }   
}

public class Moneda
{
    public string Nombre { get; set; }
    public int Valor { get; set; }

    public static readonly Moneda Nickel = new() { Nombre = "Nickel", Valor = 5 };
    public static readonly Moneda Dime = new() { Nombre = "Dime", Valor = 10 };
    public static readonly Moneda Quarter = new() { Nombre = "Quarter", Valor = 25 };
}