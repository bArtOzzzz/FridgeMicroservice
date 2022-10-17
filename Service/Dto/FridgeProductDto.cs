namespace Services.Dto
{
    public class FridgeProductDto
    {
        public Guid Id { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductCount { get; set; }
        public FridgeDto? Fridge { get; set; }
        public ProductDto? Product { get; set; }
    }
}
