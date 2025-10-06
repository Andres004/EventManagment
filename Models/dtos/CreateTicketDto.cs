using System.ComponentModel.DataAnnotations;


namespace EventManagment.Models.dtos
{
    public record CreateTicketDto
    {

        [Required]
        public List<string>? Notes { get; set; } = new();

    }

}
