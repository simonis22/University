namespace University.Domain.Common
{
    public interface IAuditableEntity
    {
        bool IsDeleted { get; set; }
        DateTime Created { get; set; }
        long CreatedBy { get; set; }
        DateTime? Updated { get; set; }
        long UpdatedBy { get; set; }
    }
}
