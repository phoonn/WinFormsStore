using DataModel.Entities;

namespace Interfaces.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    { 
        Provider FindByName(string name);
    }
}
