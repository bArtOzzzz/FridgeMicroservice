namespace Services.Dto
{
    public class FridgeDto
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Manufacturer { get; set; }
        public string OwnerName { get; set; }
        public string ModelName { get; set; }
    }
}
