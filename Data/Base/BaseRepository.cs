using Data.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data
{
    public abstract class BaseRepository<T> : SuperBaseRepository<AssesmentContext,T>
        where T : class, new()
    {

    }
}
