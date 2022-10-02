using Repositories.Entities.Abstract;

namespace Repositories.Entities
{
    public class FridgeProductEntity : BaseEntity
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
        public FridgeEntity Fridge { get; set; }
        public ProductEntity Product { get; set; }
    }
}
