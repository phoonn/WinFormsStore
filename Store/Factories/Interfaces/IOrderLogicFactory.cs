using DataModel.Entities;
using Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Factories.Interfaces
{
    public interface IOrderLogicFactory
    {
        IOrderLogic<Order> CreateNew();
    }
}
