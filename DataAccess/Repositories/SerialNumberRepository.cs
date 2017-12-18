using DataModel.Entities;
using Interfaces.Repositories;
using System.Data.Entity;
using System;
using System.Linq;

namespace DataAccess.Repositories
{
    public class SerialNumberRepository : BaseRepository<SerialNumber> ,ISerialNumberRepository<SerialNumber>
    {
        public SerialNumberRepository(IUnitOfWork unit, DbContext context) : base(unit, context)
        { }


        public SerialNumberRepository(StoreDbContext context) : base(context)
        {
        }

        public SerialNumber FindByName(string name)
        {
            return Items.FirstOrDefault(p => p.SerialNum == name);
        }
    }
}
