using DataModel.Entities;
using Interfaces.Logic;

namespace Store.Factories.Interfaces
{
    public interface ISerialNumberLogicFactory
    {
        ISerialNumberLogic CreateNew();
    }
}