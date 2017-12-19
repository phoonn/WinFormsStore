using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;

namespace BusinessLogic
{
    public class SerialNumberLogic : BaseCrudLogic<SerialNumber>, ISerialNumberLogic
    {
        public SerialNumberLogic(IRepository<SerialNumber> Repo, IUnitOfWork Unit) : base(Repo, Unit)
        {
        }
    }
}
