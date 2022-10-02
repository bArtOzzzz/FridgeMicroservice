using System.ComponentModel.DataAnnotations;

namespace FridgeMicroservice.Models.Request
{
    public class ModelModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1913, 2022)]
        public int ProductionYear { get; set; }
    }
}
