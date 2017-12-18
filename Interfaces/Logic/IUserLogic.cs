using System;

namespace Interfaces.Logic
{
    public interface IUserLogic<T> : IDisposable ,ICrudLogic<T> where T:class,IBaseEntity,new()
    {
        T Login(string name, string password);
    }
}
