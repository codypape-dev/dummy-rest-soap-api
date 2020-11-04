using DummyWebService.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace DummyWebService.Model
{
    [ServiceContract]    
    public interface IDummyWebService
    {
        [OperationContract]
        public IEnumerable<Dummy> GetDummies();

        [OperationContract]
        public Dummy GetById(string id);

        [OperationContract]
        public Dummy CreateDummy(Dummy dummy);

        [OperationContract]
        public Dummy UpdateById(Dummy dummy);

        [OperationContract]
        public bool DeleteDummyById(string id);
    }

    public class DummiesWebService : IDummyWebService
    {
        readonly DummiesBL dummiesBL = new DummiesBL();

        public Dummy CreateDummy(Dummy dummy)
        {
            return dummiesBL.Create(dummy);
        }

        public bool DeleteDummyById(string id)
        {
            return dummiesBL.DeleteDummyById(id);
        }

        public Dummy GetById(string id)
        {
           return dummiesBL.GetDummyById(id);
        }

        public IEnumerable<Dummy> GetDummies()
        {
            return dummiesBL.GetDummies();
        }

        public Dummy UpdateById(Dummy dummy)
        {
            return dummiesBL.UpdateById(dummy);
        }
    }
}
