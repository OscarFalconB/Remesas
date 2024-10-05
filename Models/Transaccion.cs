namespace Nueva_carpeta.Models
{
    public class Transaccion
{
    public int Id { get; set; }

    public string? Remitente { get; set; }
    public string? Destinatario { get; set; }
    public string? PaisOrigen { get; set; }
    public string? PaisDestino { get; set; }

    public decimal MontoEnviado { get; set; }
    public string? Moneda { get; set; }

    public decimal? TasaCambio { get; set; }
    public decimal? MontoFinal { get; set; }
    public string? Estado { get; set; }
}
}
