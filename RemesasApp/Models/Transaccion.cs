using System.ComponentModel.DataAnnotations;

namespace RemesasApp.Models
{
    public class Transaccion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El remitente es requerido")]
        public string Remitente { get; set; }

        [Required(ErrorMessage = "El destinatario es requerido")]
        public string Destinatario { get; set; }

        [Required(ErrorMessage = "El país de origen es requerido")]
        public string PaisOrigen { get; set; }

        [Required(ErrorMessage = "El país de destino es requerido")]
        public string PaisDestino { get; set; }

        [Required(ErrorMessage = "El monto enviado es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0")]
        public decimal MontoEnviado { get; set; }

        [Required(ErrorMessage = "La moneda es requerida")]
        public string Moneda { get; set; }

        // Propiedad TasaCambio
        [Required(ErrorMessage = "La tasa de cambio es requerida")]
        [Range(0.000001, double.MaxValue, ErrorMessage = "La tasa de cambio debe ser mayor que 0")]
        public decimal TasaCambio { get; set; }

        // Propiedad MontoFinal
        [Required(ErrorMessage = "El monto final es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto final debe ser mayor que 0")]
        public decimal MontoFinal { get; set; }

        public string Estado { get; set; }
    }
}
