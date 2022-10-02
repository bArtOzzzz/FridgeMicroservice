namespace FridgeMicroservice.Models.Response
{
    public class FridgeProductResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductCount { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
    }
}
