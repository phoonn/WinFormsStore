using DataModel.Entities;
using Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Repositories;

namespace BusinessLogic
{
    public class ProviderLogic : BaseCrudLogic<Provider>, IProviderLogic
    {
        public ProviderLogic(IRepository<Provider> Repo, IUnitOfWork Unit) : base(Repo, Unit)
        {
        }
    }
}
