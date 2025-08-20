using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
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

                    SoftDeleteEntity(entry, context);

                }
            }

            return base.SavingChanges(eventData, result);
        }

        private void SoftDeleteEntity(EntityEntry entry, DbContext context)
        {
            if (entry.Entity is not ISoftDelete entity)
                return;

            // Se já está deletado, não faz nada
            if (entity.IsDeleted)
                return;

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

            // Marca como SoftDelete
            entry.State = EntityState.Unchanged;
            entity.Delete();
            entry.Property(nameof(ISoftDelete.IsDeleted)).IsModified = true;

            // Percorre todos os relacionamentos
            foreach (var navigation in entry.Navigations)
            {
                if (navigation.CurrentValue == null)
                    continue;

                // Coleção (ex: User -> Contacts)
                if (navigation.Metadata.IsCollection)
                {
                    foreach (var related in (IEnumerable)navigation.CurrentValue)
                    {
                        if (related is ISoftDelete deletableChild)
                        {
                            var childEntry = context.Entry(deletableChild);
                            SoftDeleteEntity(childEntry, context);
                        }
                    }
                }
                // Referência (ex: User -> Account)
                else
                {
                    if (navigation.CurrentValue is ISoftDelete related)
                    {
                        var relatedEntry = context.Entry(related);
                        SoftDeleteEntity(relatedEntry, context);
                    }
                }
            }
        }
    }
}
