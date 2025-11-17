namespace VendingMachine;

public class Monedero
{
    public Monedero(int cantidadNickel, int cantidadDime, int cantidadQuarter)
    {
        _cajaMonedas[Moneda.Dime] = cantidadDime;
        _cajaMonedas[Moneda.Nickel] = cantidadNickel;
        _cajaMonedas[Moneda.Quarter] = cantidadQuarter;
    }
    
    public int Saldo { get; private set; }
    public List<Moneda> BandejaDevolucion { get; } = [];
    
    private readonly Dictionary<Moneda, int> _cajaMonedas = new()
    {
        { Moneda.Dime, 0 },
        { Moneda.Quarter, 0 },
        { Moneda.Nickel, 0 },
    };

    public int ObtenerSaldoBandejaMonedas() => BandejaDevolucion.Sum(ValuarMoneda);

    public void DevolverSaldo(int saldo)
    {
        var cambio = ObtenerCambio(saldo);
        foreach (var moneda in cambio)
        {
            BandejaDevolucion.Add(moneda);
        }
    }

    public void ValidarMonedaPermitida(Moneda moneda)
    {
        if (moneda == Moneda.Penny)
        {
            BandejaDevolucion.Add(moneda);
            return;
        }

        Saldo += ValuarMoneda(moneda);
    }

    public bool TieneSaldo() => Saldo > 0;

    public bool PuedeDarCambio(int cambio)
    {
        var cajaMonedasCopy = new Dictionary<Moneda, int>(_cajaMonedas);
        var cambioRestante = cambio;

        var monedas = new[] { Moneda.Quarter, Moneda.Dime, Moneda.Nickel };
        foreach (var moneda in monedas)
        {
            var valor = ValuarMoneda(moneda);
            while (cambioRestante >= valor && cajaMonedasCopy[moneda] > 0)
            {
                cajaMonedasCopy[moneda]--;
                cambioRestante -= valor;
            }
        }

        return cambioRestante == 0;
    }

    private static List<Moneda> ObtenerCambio(int cambio)
    {
        var monedas = new List<Moneda>();
        var saldoRestante = cambio;

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

    private static int ValuarMoneda(Moneda moneda)
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