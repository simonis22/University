namespace University.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
