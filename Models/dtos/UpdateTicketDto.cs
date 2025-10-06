using System.ComponentModel.DataAnnotations;

namespace EventManagment.Models.dtos
{
    public class UpdateTicketDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public List<string>? Notes { get; set; } = new();
    }
}
