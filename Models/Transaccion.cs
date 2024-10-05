using System.ComponentModel.DataAnnotations;

namespace Parcial_progra.Models
{
    public class Transaccion
    {
        [Key] // Esto define la clave primaria
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
        public double MontoEnviado { get; set; }

        [Required(ErrorMessage = "La moneda es requerida")]
        public string Moneda { get; set; }

        public double TasaCambio { get; set; }

        public double MontoFinal { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public string Estado { get; set; }
    }
}
