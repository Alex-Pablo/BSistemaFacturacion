using Microsoft.EntityFrameworkCore.Storage;
using SistemaFacturacion.DAL;

namespace SistemaFacturacion.Utils.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _myDbContext;
        private IDbContextTransaction _transaction;
        public UnitOfWork( MyDbContext myDbContext) { 
            _myDbContext = myDbContext;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction is not null)
                throw new InvalidOperationException("Una transaccion a empezado");
            _transaction = await _myDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction is null)
                throw new InvalidOperationException("No se ha empezado una transaccion");

            try
            {
                //await _myDbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
                _transaction.Dispose();
                _transaction = null;
            }
            catch (Exception)
            { 
                if (_transaction is not null)
                    await _transaction.RollbackAsync();
                throw;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _myDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
