using Data.Implementations;
using Entities;
using Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Implementations
{
    public class PolicyLogic : BaseLogic<Policy, PolicyRepository>, IPolicyLogic
    {
        public List<Policy> GetByClient(string clientId)
        {
            PolicyRepository policyLogic = new PolicyRepository();

            return policyLogic.GetByClientId(clientId);
        }
    }
}
