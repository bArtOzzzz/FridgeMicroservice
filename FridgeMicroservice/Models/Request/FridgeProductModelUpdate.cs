using System.ComponentModel.DataAnnotations;

namespace FridgeMicroservice.Models.Request
{
    public class FridgeProductModelUpdate
    {
        [Required]
        [Range(0, 999)]
        public int ProductCount { get; set; }

        [Required]
        public Guid FridgeId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
