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
    
}

public class MaquinaExpendedora
{
    public int Saldo { get; set; }
    public string Pantalla { get; set; }

    public void InsertarMoneda(Moneda moneda)
    {
        if(moneda.Nombre != Moneda.Penny.Nombre)
            Saldo += moneda.Valor;

        Pantalla = "$5";
    }   
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