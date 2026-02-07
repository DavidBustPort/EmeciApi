using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private IDbContextTransaction? currentTransaction;
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            currentTransaction = await context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);
                if (currentTransaction is not null)
                    await currentTransaction.CommitAsync(cancellationToken);
            }
            finally
            {
                currentTransaction?.Dispose();
                currentTransaction = null;
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (currentTransaction is not null)
            {
                await currentTransaction.RollbackAsync(cancellationToken);
                currentTransaction?.Dispose();
                currentTransaction = null;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
