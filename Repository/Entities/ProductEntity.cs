using Repositories.Entities.Abstract;

namespace Repositories.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string? LinkImage { get; set; }
        public List<FridgeEntity> Fridges { get; set; }
        public List<FridgeProductEntity> FridgeProducts { get; set; }
    }
}
