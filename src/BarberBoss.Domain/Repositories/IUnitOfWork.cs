﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
