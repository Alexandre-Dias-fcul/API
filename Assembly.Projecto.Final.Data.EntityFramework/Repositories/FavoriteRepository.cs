﻿using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Repositories
{
    public class FavoriteRepository : Repository<Favorite, int>, IFavoriteRepository
    {
        public FavoriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
