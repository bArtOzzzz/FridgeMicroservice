using Repositories.Entities.Abstract;

namespace Repositories.Entities
{
    public class ModelEntity : BaseEntity
    {
        public string? Name { get; set; }
        public int ProductionYear { get; set; }
        public List<FridgeEntity>? Fridges { get; set; }
    }
}
