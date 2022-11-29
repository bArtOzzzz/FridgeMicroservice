namespace Repositories.Entities.Abstract
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
