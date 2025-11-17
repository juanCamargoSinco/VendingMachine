namespace VendingMachine;

public class Pantalla
{
    public string Display { get; private set; } = "INSERTAR MONEDA";

    public void CambiarAInsertarMoneda() => Display = "INSERTAR MONEDA";
    public void CambiarACambioExacto() => Display = "Cambio Exacto";
    public void CambiarAGracias() => Display = "Gracias";
    public void CambiarAAgotado() => Display = "AGOTADO";
    public void CambiarASaldo(int saldo) => Display = $"$ {saldo}";
    public void CambiarAPrecio(int precio) => Display = $"PRECIO ${precio}";
}