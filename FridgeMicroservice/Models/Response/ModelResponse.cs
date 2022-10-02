namespace FridgeMicroservice.Models.Response
{
    public class ModelResponse
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
    }
}
