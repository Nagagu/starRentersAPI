namespace StarRentersAPI.Models
{
    public class Review
    {
        public int Id { get; set; } // Identificador de la reseña
        public string RenterName { get; set; } // Nombre del inquilino
        public string ReviewText { get; set; } // Texto de la reseña
        public int Rating { get; set; } // Calificación (por ejemplo, de 1 a 5)
        public DateTime Date { get; set; } // Fecha de la reseña
    }
}
