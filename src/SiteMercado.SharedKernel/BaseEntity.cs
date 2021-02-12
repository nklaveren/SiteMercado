namespace SiteMercado.SharedKernel
{
    public abstract class BaseEntity : BaseEntity<int>
    {
    }

    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}