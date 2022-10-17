using Repositories.Entities.Abstract;

namespace Repositories.Entities
{
    public class FridgeEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ModelId { get; set; }
        public string? Manufacturer { get; set; }
        public string? OwnerName { get; set; }
        public ModelEntity? Model { get; set; }
        public List<ProductEntity>? Products { get; set; }
        public List<FridgeProductEntity>? FridgeProducts { get; set; }
    }
}
