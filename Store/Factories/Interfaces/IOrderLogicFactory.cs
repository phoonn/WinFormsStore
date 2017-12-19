using Interfaces.Logic;

namespace Store.Factories.Interfaces
{
    public interface IOrderLogicFactory
    {
        IOrderLogic CreateNew();
    }
}
