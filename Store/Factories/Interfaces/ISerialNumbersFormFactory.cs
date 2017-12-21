using DataModel.Entities;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Store.Factories.Interfaces
{
    public interface ISerialNumbersFormFactory
    {
        Form CreateNew(List<SerialNumber> seriallist);
    }
}
