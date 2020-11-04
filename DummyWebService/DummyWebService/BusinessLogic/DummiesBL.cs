using DummyWebService.DataAccess;
using DummyWebService.Model;
using System.Collections.Generic;

namespace DummyWebService.BusinessLogic
{
    public class DummiesBL
    {
        DummiesDA data = new DummiesDA();
        internal List<Dummy> GetDummies()
        {
            return data.GetDummies();
        }

        internal Dummy GetDummyById(string id)
        {
            return data.GetDummyById(id);
        }

        internal Dummy Create(Dummy dummy)
        {
            return data.Create(dummy);
        }

        internal Dummy UpdateById(Dummy value)
        {
            return data.UpdateById(value);
        }

        internal bool DeleteDummyById(string id)
        {
            return data.DeleteDummyById(id);
        }
    }
}
