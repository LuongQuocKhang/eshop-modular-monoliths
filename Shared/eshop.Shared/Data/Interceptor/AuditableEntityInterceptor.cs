using eshop.Shared.DDD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace eshop.Shared.Data.Interceptor;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    private static void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach(var entity in context.ChangeTracker.Entries<IEntity>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedBy = "test";
                entity.Entity.CreatedAt = DateTime.UtcNow;
            }

            if (entity.State == EntityState.Modified || 
                entity.State == EntityState.Added || 
                entity.HasChangedOwnEntities())
            {
                entity.Entity.LastModifiedBy = "test";
                entity.Entity.LastModified = DateTime.UtcNow;
            }
        }
    }
}

public static class Extentions
{
    public static bool HasChangedOwnEntities(this EntityEntry<IEntity> entity)
    {
        return entity.References.Any(r => r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}
