﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountService.Application.Entities
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
    }
}
