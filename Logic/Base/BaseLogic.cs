using Data;
using System;

namespace Logic
{
    public abstract class BaseLogic<T, R> : IBaseLogic<T>
        where T : class, new()
        where R : IBaseRepository<T>, new()
    {

    }
}
