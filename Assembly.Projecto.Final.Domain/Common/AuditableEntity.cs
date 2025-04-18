﻿using Assembly.Projecto.Final.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Common
{
    public class AuditableEntity<TId> : SoftDelete<TId>,IAuditableEntity<int>, ISoftDelete, IEntity<TId>
    {
        public DateTime Created { get ; protected set; }
        public int CreatedBy { get; protected set; }
        public DateTime Updated { get; protected set; }
        public int UpdatedBy { get; protected set; }

        public void Create(DateTime created)
        {
            Created = created;
            Updated = created;
        }

        public void Update(DateTime updated)
        {
            Updated = updated;
        }
    }
}
