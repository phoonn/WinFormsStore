using DataModel.Entities;

namespace Interfaces.Repositories
{
    public interface ISerialNumberRepository : IRepository<SerialNumber>
    {
        SerialNumber FindByName(string name);
    }
}
