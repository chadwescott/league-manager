using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LeagueManager.Database
{
    public interface IDbContext : IDisposable
    {
        // Summary:
        //     Provides access to features of the context that deal with change tracking
        //     of entities.
        ChangeTracker ChangeTracker { get; }

        //
        // Summary:
        //     Creates a Database instance for this context that allows for creation/deletion/existence
        //     checks for the underlying database.
        DatabaseFacade Database { get; }

        //
        // Summary:
        //     Gets a System.Data.Entity.Infrastructure.DbEntityEntry object for the given
        //     entity providing access to information about the entity and the ability to
        //     perform actions on the entity.
        //
        // Parameters:
        //   entity:
        //     The entity.
        //
        // Returns:
        //     An entry for the entity.
        EntityEntry Entry(object entity);
        //
        // Summary:
        //     Gets a System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> object for
        //     the given entity providing access to information about the entity and the
        //     ability to perform actions on the entity.
        //
        // Parameters:
        //   entity:
        //     The entity.
        //
        // Type parameters:
        //   TEntity:
        //     The type of the entity.
        //
        // Returns:
        //     An entry for the entity.
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        // Summary:
        //     Saves all changes made in this context to the underlying database.
        //
        // Returns:
        //     The number of objects written to the underlying database.
        //
        // Exceptions:
        //   System.Data.Entity.Infrastructure.DbUpdateException:
        //     An error occurred sending updates to the database.
        //
        //   System.Data.Entity.Infrastructure.DbUpdateConcurrencyException:
        //     A database command did not affect the expected number of rows. This usually
        //     indicates an optimistic concurrency violation; that is, a row has been changed
        //     in the database since it was queried.
        //
        //   System.Data.Entity.Validation.DbEntityValidationException:
        //     The save was aborted because validation of entity property values failed.
        //
        //   System.NotSupportedException:
        //     An attempt was made to use unsupported behavior such as executing multiple
        //     asynchronous commands concurrently on the same context instance.
        //
        //   System.ObjectDisposedException:
        //     The context or connection have been disposed.
        //
        //   System.InvalidOperationException:
        //     Some error occurred attempting to process entities in the context either
        //     before or after sending commands to the database.
        int SaveChanges();
        //
        // Summary:
        //     Asynchronously saves all changes made in this context to the underlying database.
        //
        // Parameters:
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task
        //     to complete.
        //
        // Returns:
        //     A task that represents the asynchronous save operation.  The task result
        //     contains the number of objects written to the underlying database.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     Thrown if the context has been disposed.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported.
        //     Use 'await' to ensure that any asynchronous operations have completed before
        //     calling another method on this context.
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //
        // Summary:
        //     Returns an IDbSet instance for access to entities of the given type in the
        //     context, the ObjectStateManager, and the underlying store.
        //
        // Type parameters:
        //   TEntity:
        //     The type entity for which a set should be returned.
        //
        // Returns:
        //     A set for the given entity type.
        //
        // Remarks:
        //     See the DbSet class for more details.
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        void SetEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class;
    }
}
