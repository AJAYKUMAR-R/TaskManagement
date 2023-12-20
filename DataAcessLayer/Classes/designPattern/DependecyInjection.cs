using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Classes.designPattern
{
    public class DependecyInjection
    {
        private Dictionary<Type,object> instances = new Dictionary<Type,object>();

        //here i am registering the service 
        //and Defining the Type Constarint
        public void Register<IResult, IImplementation>() where IImplementation : IResult,new()
        {
            instances[typeof(IResult)] = new IImplementation();
        }

        public TResult Resolve<TResult>()
        {
            if(instances.TryGetValue(typeof(TResult) ,out var instant))
            {
                return (TResult)instant;
            }

            throw new Exception($"Invalid Given Type {typeof(TResult)} not Registered");
        }
    }
}
