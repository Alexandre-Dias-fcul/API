﻿using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Core.Repositories
{
    public interface IPersonalContactRepository: IRepository<PersonalContact, int>
    {
        public PersonalContact? GetByIdWithDetail(int id);
    }
}
