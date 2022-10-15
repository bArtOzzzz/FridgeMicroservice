namespace FridgeMicroservice.Models.Request
{
    public class FridgeProductModelUpdate
    {
        public int ProductCount { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
    }
}
