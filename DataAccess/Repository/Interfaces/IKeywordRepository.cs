﻿using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IKeywordRepository:IRepository<Keyword>
    {
        Task<Keyword> GetKeywordByValue(string value);
    }
}
