using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Interceptors
{
    internal class SoftDeleteInterceptor: SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var context = eventData.Context;

            if (context == null)
                return base.SavingChanges(eventData, result);


            foreach (var entry in context.ChangeTracker.Entries<ISoftDelete>())
            {
                if (entry.State == EntityState.Deleted)
                {     
                    
                    foreach (var prop in entry.Properties)
                    {
                        if (prop.Metadata.Name != nameof(ISoftDelete.IsDeleted))
                            prop.CurrentValue = prop.OriginalValue;
                    }

                    foreach (var reference in entry.References.Where(r => r.TargetEntry != null))
                    {
                        var owned = reference.TargetEntry;

                        if (owned.Metadata.IsOwned())
                        {
                            foreach (var p in owned.Properties)
                            {
                                p.CurrentValue = p.OriginalValue;
                            }

                            owned.State = EntityState.Unchanged;
                        }
                    }

                    entry.State = EntityState.Unchanged;

                    entry.Entity.Delete();

                    entry.Property(nameof(ISoftDelete.IsDeleted)).IsModified = true;

                }
            }

            return base.SavingChanges(eventData, result);
        }
    }
}
