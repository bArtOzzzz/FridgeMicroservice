using System.ComponentModel.DataAnnotations;

namespace FridgeMicroservice.Models.Request
{
    public class FridgeProductModelCreate
    {
        [Required]
        [Range(0, 999)]
        public int ProductCount { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
