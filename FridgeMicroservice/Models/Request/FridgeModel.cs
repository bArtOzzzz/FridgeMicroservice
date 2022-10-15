namespace FridgeMicroservice.Models.Request
{
    public class FridgeModel
    {
        public Guid ModelId { get; set; }
        public string Manufacturer { get; set; }
        public string OwnerName { get; set; }
    }
}
