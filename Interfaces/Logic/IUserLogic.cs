using DataModel.Entities;

namespace Interfaces.Logic
{
    public interface IUserLogic : ICrudLogic<User>
    {
        User Login(string name, string password);
    }
}
