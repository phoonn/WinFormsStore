using System;
using System.Collections.Generic;

namespace Interfaces.Logic
{
    public interface ICrudLogic<T> : IDisposable
    {
        List<T> Get();

        void Add(T Item);

        void Edit(T Item);

        void Delete(T Item);

        T GetById(int id);
    }
}
