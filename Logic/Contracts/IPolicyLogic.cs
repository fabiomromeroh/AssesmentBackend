using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Contracts
{
    public interface IPolicyLogic : IBaseLogic<Policy>
    {
        List<Policy> GetByClient(string clientId);
    }
}
