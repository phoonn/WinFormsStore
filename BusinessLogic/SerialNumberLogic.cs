using System;
using DataModel.Entities;
using Interfaces.Logic;
using Interfaces.Repositories;

namespace BusinessLogic
{
    public class SerialNumberLogic : BaseCrudLogic<SerialNumber, ISerialNumberRepository>, ISerialNumberLogic
    {
        public SerialNumberLogic(ISerialNumberRepository Repo, IUnitOfWork Unit) : base(Repo, Unit)
        {
        }

        public void DeleteByUnique(string serialnumber)
        {
            SerialNumber serialnum = Repo.Find(s => s.SerialNum == serialnumber);
            if (serialnum !=null)
            {
                Repo.Delete(serialnum);
                Unit.SaveChanges();
            }
        }
    }
}
