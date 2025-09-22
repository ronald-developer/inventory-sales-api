namespace InventorySales.Contracts
{
    public interface IOperationContext
    {
        public Guid OperationId { get; }
        public IEnumerable<string> Roles { get; }
        public Guid UserId { get; }
    }
}
