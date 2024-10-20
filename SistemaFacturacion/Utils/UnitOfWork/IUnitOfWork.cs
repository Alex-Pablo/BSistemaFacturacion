namespace SistemaFacturacion.Utils.UnitOfWork
{

        public interface IUnitOfWork : IDisposable
        {
            Task BeginTransactionAsync();

            Task CommitTransactionAsync();

            Task RollbackTransactionAsync();

            Task<int> SaveChangesAsync();
        }
    
}
