using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IBaseLogic<T>
        where T: class, new()
    {
    }
}
