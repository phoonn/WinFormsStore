using DataModel.Entities;

namespace Interfaces.Logic
{
    public interface ISerialNumberLogic : ICrudLogic<SerialNumber>
    {
        void DeleteByUnique(string serialnumber);
    }
}
