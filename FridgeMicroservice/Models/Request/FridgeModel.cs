using System.ComponentModel.DataAnnotations;

namespace FridgeMicroservice.Models.Request
{
    public class FridgeModel
    {
        public Guid ModelId { get; set; }

        [Required]
        [StringLength(30)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(30)]
        public string OwnerName { get; set; }
    }
}
