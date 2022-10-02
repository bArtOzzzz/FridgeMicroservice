namespace FridgeMicroservice.Models.Response
{
    public class FridgeResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Manufacturer { get; set; }
        public string OwnerName { get; set; }
        public Guid ModelId { get; set; }
        public string ModelName { get; set; }
    }
}
